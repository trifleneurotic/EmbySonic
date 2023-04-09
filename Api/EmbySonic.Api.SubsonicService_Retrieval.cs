using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;

namespace EmbySonic.Api
{
    [Route("/rest/getLyrics.view", "GET", Summary = "Searches for and returns lyrics for a given song", Description = "Returns a <subsonic-response> element with a nested <lyrics> element on success. The <lyrics> element is empty if no matching lyrics was found")]
    public class RetrievalLyrics : SystemBase
    {
        [ApiMember(Name = "Artist", Description = "The artist name", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? artist { get; set; }

        [ApiMember(Name = "Title", Description = "The song title", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? title { get; set; }
    }

    [Route("/rest/getCoverArt.view", "GET", Summary = "Returns a cover art image", Description = "Returns the cover art image in binary form. ")]
    public class RetrievalCoverArt : SystemBase
    {
        [ApiMember(Name = "ID", Description = "The ID of a song, album or artist", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? id { get; set; }

        [ApiMember(Name = "Size", Description = "If specified, scale image to this size", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? size { get; set; }
    }

    [Route("/rest/getCaptions.view", "GET", Summary = "Returns captions (subtitles) for a video. Use getVideoInfo to get a list of available captions", Description = "Returns the raw video captions")]
    public class RetrievalCaptions : SystemBase
    {
        [ApiMember(Name = "ID", Description = "The ID of the video", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? id { get; set; }

        [ApiMember(Name = "Format", Description = "Preferred captions format (\"srt\" or \"vtt\")", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? format { get; set; }
    }

    [Route("/rest/getAvatar.view", "GET", Summary = "Returns the avatar (personal image) for a user", Description = "Returns the avatar image in binary form")]
    public class RetrievalAvatar : SystemBase
    {
        [ApiMember(Name = "Username", Description = "The user in question", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? username { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(Lyrics req)
        {
            return null;
        }
        public async Task<object> Get(Captions req)
        {
            return null;
        }
        public async Task<object> Get(HttpRequestMessage req)
        {
            return null;
        }
    }
}