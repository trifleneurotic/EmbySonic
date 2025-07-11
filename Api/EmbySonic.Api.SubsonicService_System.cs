using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.MediaEncoding;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.IO;

using System.Text;
using System.Text.Json;


namespace EmbySonic.Api
{
    public class SystemBase : IReturn<Response>
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

    [Route("/rest/ping.view", "GET", Summary = "Ping Emby Server", Description = "Ping Emby Server")]
    public class SystemPing : SystemBase
    {
    }

    [Route("/rest/getLicense.view", "GET", Summary = "Returns Emby license information (Premiere)", Description = "Returns Emby license information (Premiere)")]
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

        string musicLibId = String.Empty;

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

        private async Task<object> GetMusicLibId(SystemBase req)
        {
            // we need the unique ID for the desired music library set in the plugin configuration
            String url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
            HttpResponseMessage mes = await c.GetAsync(url);
            String hrmraw = await mes.Content.ReadAsStringAsync();
            JsonDocument j = JsonDocument.Parse(hrmraw);
            JsonElement allLibs = j.RootElement.GetProperty("Items");
            String s = String.Empty;
            String contentType = "text/xml";

            foreach (JsonElement lib in allLibs.EnumerateArray())
            {
                s = lib.GetProperty("Name").ToString();
                if (String.Equals(s, Plugin.Instance.Configuration.MusicLibraryName))
                {
                    musicLibId = lib.GetProperty("Id").ToString();
                    break;
                }
            }


            // music library does not exist under configured name
            if (String.IsNullOrEmpty(musicLibId))
            {
                if (String.IsNullOrEmpty(req.f))
                {
                    Response r = new Response();
                    Error e = new Error();
                    e.code = 0;
                    e.message = "Music library does not exist";
                    r.Item = e;
                    r.ItemElementName = EmbySonic.ItemChoiceType.error;
                    s = Serializer<Response>.Serialize(r);
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    var e = new Error();
                    e.code = 0;
                    e.message = "Music library does not exist";
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["error"] = e;
                    r.root["_status"] = "ok";
                    s = JsonSerializer.Serialize(r, options);
                    contentType = "text/json";
                }
            }

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(s), contentType, null);
        }

        private Child[] ShuffleChildren(Child[] arr, int numElements)
        {
            Random rand = new Random();

            Child[] RandomizedChildren = arr.OrderBy(x => rand.Next()).ToArray();

            return RandomizedChildren.Take(numElements).ToArray();
        }

        public static byte[] HexStringToBytes(string hexString)
        {
            if (hexString == null)
                throw new ArgumentNullException("hexString");
            if (hexString.Length % 2 != 0)
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
                byte[] bytes = EmbySonic.Api.SubsonicService.HexStringToBytes(pwHex);
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
                var subReq = new Response();
                var e = new Error();
                e.code = 0;
                e.message = "Login failed";
                subReq.status = EmbySonic.ResponseStatus.failed;
                subReq.Item = e;
                subReq.ItemElementName = EmbySonic.ItemChoiceType.error;
                subReq.version = SupportedSubsonicApiVersion;
                type = "text/xml";
                return Serializer<Response>.Serialize(subReq);
            }
            if (req.f.Equals("json"))
            {
                var subReq = new JsonResponse();
                var e = new Error();
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
                    Response r = new Response();
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["_status"] = "ok";
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
                    Response r = new Response();
                    License l = new License();
                    l.valid = true;
                    l.email = "billingsupport@emby.media";
                    r.Item = l;
                    r.ItemElementName = EmbySonic.ItemChoiceType.license;
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    var lp = new License();
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
