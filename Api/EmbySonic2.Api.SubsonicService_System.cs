using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.MediaEncoding;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.IO;
using System;
using System.Text;
using System.Text.Json;



namespace EmbySonic2.Api
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

    [Route("/rest/ping", "GET", Summary = "Ping Emby Server", Description = "Ping Emby Server")]
    public class SystemPing : SystemBase
    {
    }

    [Route("/rest/getLicense", "GET", Summary = "Returns Emby license information (Premiere)", Description = "Returns Emby license information (Premiere)")]
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

        public async Task<object> Get(SystemPing req)
        {

            String contentType = String.Empty;
            String str = String.Empty;

            
    
               
                    JsonResponse r = new JsonResponse();
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["status"] = "ok";
                    str = JsonSerializer.Serialize(r, options);
                    contentType = "text/json";
              
            

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(SystemGetLicense req)
        {
           
           String str = String.Empty;
           String contentType = String.Empty;
                    JsonResponse r = new JsonResponse();
            var lp = new License();
                    lp.valid = true;
                    lp.email = "billingsupport@emby.media";
            lp.licenseExpires = DateTime.Now;
            lp.trialExpires = DateTime.Now;
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["license"] = lp;
                    r.root["status"] = "ok";
                    str = JsonSerializer.Serialize(r, options);
                    contentType = "text/json";
                
            

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
    }
}
