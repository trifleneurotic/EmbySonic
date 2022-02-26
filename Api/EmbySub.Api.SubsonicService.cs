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
using Emby.ApiClient.Net;
using Emby.ApiClient.Cryptography;
using Emby.ApiClient.Data;
using Emby.ApiClient.Model;
using Emby.ApiClient;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using SocketHttpListener.Net;
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
        private const string SupportedSubsonicApiVersion = "1.16.1";
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
            var logger = new NullLogger();
            var capabilities = new ClientCapabilities();
            var device = new Device {
              DeviceName = "SubsoniciApiClient",
              DeviceId = "343247328"
            };
            string serverAndPort = String.Format("http://localhost:{0}", Plugin.Instance.Configuration.LocalEmbyPort);
            var cryptoProvider = new CryptographyProvider();
            var client = new ApiClient(logger, serverAndPort, "EmbySubsonic", device, "0.0.0.1", cryptoProvider);
            var passwordHash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes("password"));
            var authResult = await client.AuthenticateUserAsync(request.Username, request.Password);
            var subReq = new EmbySub.Response();

            if(authResult.AccessToken == null)
            {
              subReq.status = ResponseStatus.failed;
            }
            else
            {
              subReq.status = ResponseStatus.ok;
            }

            subReq.version = SupportedSubsonicApiVersion;
            string xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
            return ResultFactory.GetResult(Request, xmlString, null);
        }
    }
}
