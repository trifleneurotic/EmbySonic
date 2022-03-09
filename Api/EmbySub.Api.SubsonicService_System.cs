using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.MediaEncoding;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Session;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.Users;
using MediaBrowser.Model.IO;
using MediaBrowser.Model;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml.Serialization;
using EmbySub.Configuration;
using System.Linq;

namespace EmbySub.Api
{
    public class SystemBase : IReturn<EmbySub.Response>
    {
        [ApiMember(Name = "Username", Description = "Username of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? u { get; set; }

        [ApiMember(Name = "Password", Description = "Password of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? p { get; set; }

        [ApiMember(Name = "Client", Description = "Subsonic Client ID", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? c { get; set; }

        [ApiMember(Name = "Version", Description = "Subsonic Client Version", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? v { get; set; }

        [ApiMember(Name = "Format", Description = "Format of returned data", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? f { get; set; }
    }

    [Route("/rest/ping.view", "GET", Description = "Ping Emby Server")]
    public class SystemPing : SystemBase
    {
    }

    [Route("/rest/getLicense.view", "GET", Description = "Returns Emby license information (Premiere)")]
    public class SystemGetLicense : SystemBase
    {
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        private const string SupportedSubsonicApiVersion = "1.12.0";
        private readonly ILibraryManager _libraryManager;
        private readonly IMediaEncoder _mediaEncoder;
        private readonly IFileSystem _fileSystem;
        private readonly ILogger _logger;
        private readonly IApplicationPaths _appPaths;
        private readonly ILibraryMonitor _libraryMonitor;
        public IHttpResultFactory ResultFactory { get; private set; }
        private HttpClient c;

        public IRequest? Request { get; set; }

        public SubsonicService(ILibraryManager libraryManager, IMediaEncoder mediaEncoder, IFileSystem fileSystem, ILogger logger, IApplicationPaths appPaths, ILibraryMonitor libraryMonitor, IHttpResultFactory resultFactory)
        {
            _libraryManager = libraryManager;
            _mediaEncoder = mediaEncoder;
            _fileSystem = fileSystem;
            _logger = logger;
            _appPaths = appPaths;
            _libraryMonitor = libraryMonitor;
            ResultFactory = resultFactory;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            c = new HttpClient(clientHandler);
        }

        private EmbySub.Child[] ShuffleChildren(EmbySub.Child[] arr, int numElements)
        {
          Random rand = new Random();

          EmbySub.Child[] RandomizedChildren = arr.OrderBy(x => rand.Next()).ToArray();

          return RandomizedChildren.Take(numElements).ToArray();
        }

        public static byte[] HexStringToBytes(string hexString)
        {
            if(hexString == null)
                throw new ArgumentNullException("hexString");
            if(hexString.Length % 2 != 0)
                throw new ArgumentException("hexString must have an even length", "hexString");
            var bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                string currentHex = hexString.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(currentHex, 16);
            }
            return bytes;
        }



        private async Task<HttpResponseMessage> Login(SystemBase req)
        {
          HttpClientHandler clientHandler = new HttpClientHandler();
          clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
          HttpClient client = new HttpClient(clientHandler);
          String pw;

          if (req.p.StartsWith("enc"))
          {
            String pwHex = req.p.Substring(req.p.LastIndexOf(':') + 1);
            byte[] bytes = EmbySub.Api.SubsonicService.HexStringToBytes(pwHex);
            pw = Encoding.GetEncoding("UTF-8").GetString(bytes);
          }
          else
          {
            pw = req.p;
          }

          String payload = String.Format("{{\"Username\":\"{0}\",\"Pw\":\"{1}\"}}", req.u, pw);
          StringContent body = new StringContent(payload, Encoding.UTF8, "application/json");

          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
          client.DefaultRequestHeaders.Add("X-Emby-Authorization", String.Format("Emby Client=\"{0}\", Device=\"SubsonicDevice\", DeviceId=\"0192742\", Version=\"{1}\"", req.c, req.v));

          String url = String.Format("http://localhost:{0}/emby/Users/AuthenticateByName", Plugin.Instance.Configuration.LocalEmbyPort);

          return await client.PostAsync(url, body);
        }

        private static string GetErrorObject(SystemBase req, out string type)
        {
          if (String.IsNullOrEmpty(req.f))
          {
            var subReq = new EmbySub.Response();
            var e = new EmbySub.Error();
            e.code = 0;
            e.message = "Login failed";
            subReq.status = EmbySub.ResponseStatus.failed;
            subReq.Item = e;
            subReq.ItemElementName = EmbySub.ItemChoiceType.error;
            subReq.version = SupportedSubsonicApiVersion;
            type = "text/xml";
            return Serializer<EmbySub.Response>.Serialize(subReq);
          }
          if (req.f.Equals("json"))
          {
            var subReq = new EmbySub.JsonResponse();
            var e = new EmbySub.Error();
            e.code = 0;
            e.message = "Login failed";
            subReq.root["error"] = e;
            subReq.root["_status"] = "failed";
            var options = new JsonSerializerOptions
              {
                  IgnoreNullValues = true,
                  WriteIndented = true
              };
            type = "text/json";
            return JsonSerializer.Serialize(subReq, options);
          }
          type = String.Empty;
          return null;
        }

        public async Task<object> Get(SystemPing req)
        {
          HttpResponseMessage hrm = await Login(req);
          String contentType = String.Empty;
          String str = String.Empty;

          if (!hrm.IsSuccessStatusCode)
          {
           str = GetErrorObject(req, out contentType);
          }
          else
          {
            if (String.IsNullOrEmpty(req.f))
            {
              EmbySub.Response r = new EmbySub.Response();
              str = Serializer<EmbySub.Response>.Serialize(r);
              contentType = "text/xml";
            }
            else if (req.f.Equals("json"))
            {
              EmbySub.JsonResponse r = new EmbySub.JsonResponse();
              var options = new JsonSerializerOptions
              {
                  IgnoreNullValues = true,
                  WriteIndented = true
              };
              str = JsonSerializer.Serialize(r, options);
              contentType = "text/json";
            }
          }

          return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(SystemGetLicense req)
        {
          HttpResponseMessage hrm = await Login(req);
          String contentType = String.Empty;
          String str = String.Empty;

          if (!hrm.IsSuccessStatusCode)
          {
           str = GetErrorObject(req, out contentType);
          }
          else
          {
            if (String.IsNullOrEmpty(req.f))
            {
              EmbySub.Response r = new EmbySub.Response();
              EmbySub.License l = new EmbySub.License();
              l.valid = true;
              l.email = "billingsupport@emby.media";
              r.Item = l;
              r.ItemElementName = EmbySub.ItemChoiceType.license;
              str = Serializer<EmbySub.Response>.Serialize(r);
              contentType = "text/xml";
            }
            else if (req.f.Equals("json"))
            {
              EmbySub.JsonResponse r = new EmbySub.JsonResponse();
              var lp = new EmbySub.License();
              lp.valid = true;
              lp.email = "billingsupport@emby.media";
              var options = new JsonSerializerOptions
              {
                  IgnoreNullValues = true,
                  WriteIndented = true
              };
              r.root["license"] = lp;
              r.root["_status"] = "ok";
              str = JsonSerializer.Serialize(r, options);
              contentType = "text/json";
            }
          }

          return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
         }
        }
    }
