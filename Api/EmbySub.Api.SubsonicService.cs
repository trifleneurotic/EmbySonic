using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.MediaEncoding;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using System.Linq;
using System.Threading.Tasks;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Services;

namespace EmbySub.Api
{
    [Route("/rest/ping", "GET")]
    public class PingSystem
    {
    }

    public class SubsonicService : IService, IRequiresRequest
    {
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
            return await ResultFactory.GetStaticFileResult(Request, new StaticFileResultOptions
            {
                ContentType = "application/octet-stream",
            }).ConfigureAwait(false);
        }
    }
}
