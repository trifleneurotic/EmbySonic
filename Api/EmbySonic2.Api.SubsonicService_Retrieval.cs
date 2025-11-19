  using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.IO;
using System.Text;
using System.Text.Json;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Audio;
using System.Net.Cache;
using MediaBrowser.Model.Querying;
using MediaBrowser.Controller.Drawing;
using MediaBrowser.Controller.Entities.TV;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediaBrowser.Controller.Collections;
using MediaBrowser.Controller.Dto;
using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Controller.IO;
using MediaBrowser.Model.Extensions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EmbySonic2.Api
{
    [Route("/rest/getLyrics", "GET", Summary = "Searches for and returns lyrics for a given song.", Description = "Returns lyrics for a given song.")]
    public class RetrievalGetLyrics : SystemBase
    {
        [ApiMember(Name = "artist", Description = "The artist name.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? artist { get; set; }

        [ApiMember(Name = "title", Description = "The song title.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? title { get; set; }
    }
    [Route("/rest/stream", "GET", Summary = "Streams a given media file.", Description = "Streams a given media file.")]
    public class RetrievalStream : SystemBase
    {
        [ApiMember(Name = "id", Description = "A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? id { get; set; }

        [ApiMember(Name = "maxBitRate", Description = "(Since 1.2.0) If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? maxBitRate { get; set; }

        [ApiMember(Name = "format", Description = "(Since 1.6.0) Specifies the preferred target format (e.g., “mp3” or “flv”) in case there are multiple applicable transcodings. Starting with 1.9.0 you can use the special value “raw” to disable transcoding.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? format { get; set; }

        [ApiMember(Name = "timeOffset", Description = "By default only applicable to video streaming. If specified, start streaming at the given offset (in seconds) into the media. The Transcode Offset extension enables the parameter to music too.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? timeOffset { get; set; }

        [ApiMember(Name = "size", Description = "(Since 1.6.0) Only applicable to video streaming. Requested video size specified as WxH, for instance “640x480”.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? size { get; set; }

        [ApiMember(Name = "estimateContentLength", Description = "(Since 1.8.0). If set to “true”, the Content-Length HTTP header will be set to an estimated value for transcoded or downsampled media.", IsRequired = false, DataType = "bool", ParameterType = "query", Verb = "GET")]
        public bool? estimateContentLength { get; set; }

        [ApiMember(Name = "converted", Description = "(Since 1.14.0) Only applicable to video streaming. Servers can optimize videos for streaming by converting them to MP4. If a conversion exists for the video in question, then setting this parameter to “true” will cause the converted video to be returned instead of the original.", IsRequired = false, DataType = "bool", ParameterType = "query", Verb = "GET")]
        public bool? converted { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
         public async Task<object> Get(RetrievalGetLyrics req)
        {
            string contentType = string.Empty;
            string str = string.Empty;

            // TODO: Replace with actual user context
            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            if (string.IsNullOrEmpty(req.artist) && string.IsNullOrEmpty(req.title))
            {
                JsonResponse errorResponse = new JsonResponse();
                errorResponse.root["status"] = "failed";
                errorResponse.root["error"] = new { code = 10, message = "Missing artist or title parameter" };
                contentType = "text/json";
                str = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true });
                return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }

            // Attempt to find the song in the library
            var items = _libraryManager.GetItemList(user).Where(i =>
                (string.IsNullOrEmpty(req.artist) || (i.Artists != null && i.Artists.Any(a => a.Equals(req.artist, StringComparison.OrdinalIgnoreCase)))) &&
                (string.IsNullOrEmpty(req.title) || i.Name.Equals(req.title, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            string? lyrics = null;
            if (items.Count > 0)
            {
                var song = items.First();
                // Try to get lyrics from the song's metadata
                lyrics = song.Lyrics;
            }

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            r.root["lyrics"] = new { artist = req.artist, title = req.title, value = lyrics ?? string.Empty };
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        public async Task<object> Get(RetrievalStream req)
        {
            String contentType = req.format ?? String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var item = _libraryManager.GetItemById(req.id);

            var info = new PlaybackStartInfo
            {
                ItemId = item.Id.ToString(),
                CanSeek = false
            };

            try
            {
                await _sessionManager.OnPlaybackStart(info).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                XDocument doc = new XDocument(
            new XElement("Root",
                new XElement("Error",
                    new XAttribute("message", "Could not play stream.")
                )
            )
        );
                contentType = "text/xml";
                XmlSerializer serializer = new XmlSerializer(typeof(XDocument));
                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, doc);
                    str = textWriter.ToString();
                }
                return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }
            return ResultFactory.GetResult(Request, ReadOnlyMemory<byte>.Empty, contentType, null);
        }
    }
}
