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
using System.Reflection;
using System.Xml.Serialization;
using EmbySub.Configuration;

namespace EmbySub.Api
{
    public class SystemBase : IReturn<EmbySub.Response>
    {
        [ApiMember(Name = "u", Description = "Username of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? Username { get; set; }

        [ApiMember(Name = "p", Description = "Password of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? Password { get; set; }
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

        private async Task<object> Login(SystemBase req)
        {
          HttpClientHandler clientHandler = new HttpClientHandler();
          clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
          HttpClient client = new HttpClient(clientHandler);

          var payload = String.Format("Username={0}\nPw={1}", req.Username, req.Password);
          StringContent body = new StringContent(payload);
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Add("Accept", "application/json");
          client.DefaultRequestHeaders.Add("X-Emby-Authorization", "MediaBrowser Client=\"SubsonicClient\", Device=\"SubsonicDevice\", DeviceId=\"0192742\", Version=\"0.0.1.7\"");

          String url = String.Format("http://localhost:{0}/emby/Users/AuthenticateByName", Plugin.Instance.Configuration.LocalEmbyPort);

          HttpResponseMessage result = await client.PostAsync(url, body);
          return result;
        }

        public async Task<object> Get(SystemPing req)
        {
          await Login(req);
          var subReq = new EmbySub.Response();
          subReq.version = SupportedSubsonicApiVersion;
          string xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
          _logger.Info(xmlString);
          return ResultFactory.GetResult(Request, xmlString, null);
        }
    }
}
