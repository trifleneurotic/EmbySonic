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

namespace EmbySub.Api
{
    [Route("/rest/ping", "GET")]
    public class PingSystem : IReturn<EmbySub.Response>
    {
        [ApiMember(Name = "u", Description = "Username of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? Username { get; set; }

        [ApiMember(Name = "p", Description = "Password of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? Password { get; set; }
    }

    public class SubsonicService : IService, IRequiresRequest
    {
        private const string SupportedSubsonicApiVersion = "1.12.0";
        private readonly ILibraryManager _libraryManager;
        private readonly IMediaEncoder _mediaEncoder;
        private readonly IFileSystem _fileSystem;
        private readonly ILogger _logger;
        private readonly IApplicationPaths _appPaths;
        private readonly ILibraryMonitor _libraryMonitor;
        public IHttpResultFactory ResultFactory { get; private set; }

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
        }

        public async Task<object> Get(PingSystem request)
        {
          HttpClientHandler clientHandler = new HttpClientHandler();
          clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
          HttpClient client = new HttpClient(clientHandler);

          var payload = String.Format("Username={0}\nPw={1}", request.Username, request.Password);
          StringContent body = new StringContent(payload);
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Add("Accept", "application/json");
          client.DefaultRequestHeaders.Add("X-Emby-Authorization", "MediaBrowser Client=\"SubsonicClient\", Device=\"SubsonicDevice\", DeviceId=\"0192742\", Version=\"0.0.1.7\"");

          HttpResponseMessage result = await client.PostAsync("http://localhost:8096/api/Users/AuthenticateByName", body);

          var subReq = new EmbySub.Response();

          _logger.Info("************ Hey! It's me! ************");
          _logger.Info(result.StatusCode.ToString());
          _logger.Info(result.Content.ToString());

          if (result.IsSuccessStatusCode)
          {
            subReq.status = ResponseStatus.ok;
          }
          else
          {
            subReq.status = ResponseStatus.failed;
          }

          subReq.version = SupportedSubsonicApiVersion;
          string xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
          _logger.Info(xmlString);
          return ResultFactory.GetResult(Request, xmlString, null);
        }
    }
}
