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


namespace EmbySonic2.Api
{
    [Route("/rest/getArtists", "GET", Summary = "Similar to getIndexes, but organizes music according to ID3 tags", Description = "Returns a <subsonic-response> element with a nested <artists> element on success")]
    public class BrowsingGetArtists : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "If specified, only return artists in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        // begin Browsing methods
        public async Task<object> Get(BrowsingGetArtists req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            // var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            var query = new InternalItemsQuery(null);

            List<MusicArtist> itemsResult;

            itemsResult = _libraryManager.GetArtists(query).Items.Select(i => i.Item1).Cast<MusicArtist>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var artists = new ArtistsID3();
            var indexArray = new List<IndexID3>();
            artists.ignoredArticles = "The An A Die Das Ein Eine Les Le La";
            Dictionary<String, List<ArtistID3>> d = new Dictionary<String, List<ArtistID3>>();


            foreach (MusicArtist item in itemsResult)
            {
                var artist = new ArtistID3();
                artist.id = item.Id.ToString();
                artist.name = item.Name;
                artist.coverArt = item.PrimaryImagePath;

                var rc = item.GetRecursiveChildren().AsQueryable().Where(i => i is MusicAlbum);
                artist.albumCount = rc.Count();

                if (!d.ContainsKey(artist.name[..1]))
                {
                    d.Add(artist.name[..1], new List<ArtistID3>());
                }

                d[artist.name[..1]].Add(artist);
            }

            foreach (KeyValuePair<string, List<ArtistID3>> entry in d)
            {
                var index = new IndexID3();
                index.name = entry.Key;
                index.artist = entry.Value.ToArray();
                indexArray.Add(index);
            }

            artists.index = indexArray.ToArray();

            r.root["artists"] = artists;
            str = JsonSerializer.Serialize(r, options);
            contentType = "text/json";

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        
        // end Browsing methods
    }
}
