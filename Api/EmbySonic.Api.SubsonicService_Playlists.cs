using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;

namespace EmbySonic.Api
{
    [Route("/rest/getPlaylists.view", "GET", Summary = "Returns all playlists a user is allowed to play", Description = "Returns a <subsonic-response> element with a nested <playlists> element on success")]
    public class Playlists : SystemBase
    {
        [ApiMember(Name = "Username", Description = "(Since 1.8.0) If specified, return playlists for this user rather than for the authenticated user. The authenticated user must have admin role if this parameter is used", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? username { get; set; }
    }

    [Route("/rest/getPlaylist.view", "GET", Summary = "Returns a listing of files in a saved playlist", Description = "Returns a <subsonic-response> element with a nested <playlist> element on success")]
    public class Playlist : SystemBase
    {
        [ApiMember(Name = "ID", Description = "ID of the playlist to return, as obtained by getPlaylists", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? id { get; set; }
    }

    [Route("/rest/createPlaylist.view", "GET", Summary = "Creates (or updates) a playlist", Description = "Since 1.14.0 the newly created/updated playlist is returned; In earlier versions an empty <subsonic-response> element is returned")]
    public class PlaylistCreate : SystemBase
    {
        [ApiMember(Name = "Playlist ID", Description = "The playlist ID; required if updating", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? playlistId { get; set; }

        [ApiMember(Name = "Name", Description = "The human-readable name of the playlist; required if creating", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? name { get; set; }

        [ApiMember(Name = "Song ID", Description = "ID of a song in the playlist; Use one songId parameter for each song in the playlist", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songId { get; set; }
    }

    [Route("/rest/updatePlaylist.view", "GET", Summary = "Updates a playlist; Only the owner of a playlist is allowed to update it", Description = "Returns an empty <subsonic-response> element on success")]
    public class PlaylistUpdate : SystemBase
    {
        [ApiMember(Name = "Playlist ID", Description = "The playlist ID", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? playlistId { get; set; }

        [ApiMember(Name = "Name", Description = "The human-readable name of the playlist", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? name { get; set; }

        [ApiMember(Name = "Comment", Description = "The playlist comment", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? comment { get; set; }

        [ApiMember(Name = "Public", Description = "true if the playlist should be visible to all users, false otherwise", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? pub { get; set; }

        [ApiMember(Name = "Song ID to Add", Description = "Add this song with this ID to the playlist; Multiple parameters allowed", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songIdToAdd { get; set; }

        [ApiMember(Name = "Song ID to Remove", Description = "Remove the song at this position in the playlist; Multiple parameters allowed", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? songIdToRemove { get; set; }
    }

    [Route("/rest/deletePlaylist.view", "GET", Summary = "Deletes a saved playlist", Description = "Returns an empty <subsonic-response> element on success")]
    public class PlaylistDelete : SystemBase
    {
        [ApiMember(Name = "ID", Description = "ID of the playlist to delete, as obtained by getPlaylists", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String? id { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(Playlists req)
        {
            return null;
        }
        public async Task<object> Get(Playlist req)
        {
            return null;
        }
        public async Task<object> Get(PlaylistCreate req)
        {
            return null;
        }
        public async Task<object> Get(PlaylistUpdate req)
        {
            return null;
        }
        public async Task<object> Get(PlaylistDelete req)
        {
            return null;
        }
    }
}