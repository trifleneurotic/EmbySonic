using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;

namespace EmbySonic.Api
{
    [Route("/rest/getSearch2.view", "GET", Summary = "Returns albums, artists and songs matching the given search criteria. Supports paging through the result", Description = "Returns a <subsonic-response> element with a nested <searchResult2> element on success")]
    public class Search2 : SystemBase
    {
        [ApiMember(Name = "Query", Description = "Search query", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? query { get; set; }

        [ApiMember(Name = "Artist Count", Description = "Maximum number of artists to return", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? artistCount { get; set; }

        [ApiMember(Name = "Artist Offset", Description = "Search result offset for artists; Used for paging", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? artistOffset { get; set; }

        [ApiMember(Name = "Album Count", Description = "Maximum number of albums to return", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? albumCount { get; set; }

        [ApiMember(Name = "Album Offset", Description = "Search result offset for albums; Used for paging", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? albumOffset { get; set; }
        [ApiMember(Name = "Song Count", Description = "Maximum number of songs to return", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songCount { get; set; }

        [ApiMember(Name = "Song Offset", Description = "Search result offset for songs; Used for paging", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songOffset { get; set; }
        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.12.0) Only return results from the music folder with the given ID; See getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? musicFolderId { get; set; }

    }

    [Route("/rest/getSearch3.view", "GET", Summary = "Similar to search2, but organizes music according to ID3 tags", Description = "Returns a <subsonic-response> element with a nested <searchResult3> element on success")]
    public class Search3 : SystemBase
    {
        [ApiMember(Name = "Query", Description = "Search query", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? query { get; set; }

        [ApiMember(Name = "Artist Count", Description = "Maximum number of artists to return", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? artistCount { get; set; }

        [ApiMember(Name = "Artist Offset", Description = "Search result offset for artists; Used for paging", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? artistOffset { get; set; }

        [ApiMember(Name = "Album Count", Description = "Maximum number of albums to return", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? albumCount { get; set; }

        [ApiMember(Name = "Album Offset", Description = "Search result offset for albums; Used for paging", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? albumOffset { get; set; }
        [ApiMember(Name = "Song Count", Description = "Maximum number of songs to return", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songCount { get; set; }

        [ApiMember(Name = "Song Offset", Description = "Search result offset for songs; Used for paging", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songOffset { get; set; }
        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.12.0) Only return results from the music folder with the given ID", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? musicFolderId { get; set; }

    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(Search2 req)
        {
            return null;
        }
        public async Task<object> Get(Search3 req)
        {
            return null;
        }
    }
}