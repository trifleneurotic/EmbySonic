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
    }

    [Route("/rest/ping", "GET", Description = "Ping Emby Server")]
    public class SystemPing : SystemBase
    {
    }

    [Route("/rest/getLicense", "GET", Description = "Returns Emby license information (Premiere)")]
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

        private async Task<HttpResponseMessage> Login(SystemBase req)
        {
          HttpClientHandler clientHandler = new HttpClientHandler();
          clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
          HttpClient client = new HttpClient(clientHandler);

          String payload = String.Format("{{\"Username\":\"{0}\",\"Pw\":\"{1}\"}}", req.u, req.p);
          StringContent body = new StringContent(payload, Encoding.UTF8, "application/json");

          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
          client.DefaultRequestHeaders.Add("X-Emby-Authorization", "Emby Client=\"SubsonicClient\", Device=\"SubsonicDevice\", DeviceId=\"0192742\", Version=\"0.1.0.1\"");

          String url = String.Format("http://localhost:{0}/emby/Users/AuthenticateByName", Plugin.Instance.Configuration.LocalEmbyPort);

          return await client.PostAsync(url, body);
        }

        public async Task<object> Get(SystemPing req)
        {
          HttpResponseMessage hrm = await Login(req);
          var subReq = new EmbySub.Response();
          subReq.version = SupportedSubsonicApiVersion;

          if (!hrm.IsSuccessStatusCode)
          {
            var e = new EmbySub.Error();
            e.code = 0;
            e.message = "Login failed";
            subReq.status = EmbySub.ResponseStatus.failed;
            subReq.Item = e;
            subReq.ItemElementName = EmbySub.ItemChoiceType.error;
          }

          string xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
          string xmlStringUnescaped = Regex.Unescape(xmlString);
          return ResultFactory.GetResult(Request, xmlStringUnescaped, null);
        }

        public async Task<object> Get(SystemGetLicense req)
        {
          HttpResponseMessage hrm = await Login(req);
          var subReq = new EmbySub.Response();
          subReq.version = SupportedSubsonicApiVersion;

          if (!hrm.IsSuccessStatusCode)
          {
            var e = new EmbySub.Error();
            e.code = 0;
            e.message = "Login failed";
            subReq.status = EmbySub.ResponseStatus.failed;
            subReq.Item = e;
            subReq.ItemElementName = EmbySub.ItemChoiceType.error;
          }

          EmbySub.License l = new EmbySub.License();
          l.valid = true;
          l.email = "billingsupport@emby.media";

          subReq.Item = l;
          subReq.ItemElementName = EmbySub.ItemChoiceType.license;

          string xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
          string xmlStringUnescaped = Regex.Unescape(xmlString);
          return ResultFactory.GetResult(Request, xmlStringUnescaped, null);
        }
    }
}
