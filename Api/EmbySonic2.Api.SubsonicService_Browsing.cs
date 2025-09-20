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


namespace EmbySonic2.Api
{
    [Route("/rest/getArtists", "GET", Summary = "Returns all artists.", Description = "Similar to getIndexes, but organizes music according to ID3 tags.")]
    public class BrowsingGetArtists : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "If specified, only return artists in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    [Route("/rest/getArtist", "GET", Summary = "Returns details for an artist.", Description = "Returns details for an artist, including a list of albums. This method organizes music according to ID3 tags.")]
    public class BrowsingGetArtist : SystemBase
    {
        [ApiMember(Name = "Artist ID", Description = "The artist ID", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? artistId { get; set; }
    }

    [Route("/rest/getAlbum", "GET", Summary = "Returns details for an album.", Description = "Returns details for an album, including a list of songs. This method organizes music according to ID3 tags.")]
    public class BrowsingGetAlbum : SystemBase
    {
        [ApiMember(Name = "Album ID", Description = "The album ID.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? albumId { get; set; }
    }
    
    [Route("/rest/getMusicFolders", "GET", Summary = "Returns all configured top-level music folders.", Description = "Returns all configured top-level music folders. Takes no extra parameters.")]
    public class BrowsingGetMusicFolders : SystemBase
    {
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        // begin Browsing methods

        public async Task<object> Get(BrowsingGetMusicFolders req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            // var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            var query = new InternalItemsQuery(null);

            List<MusicArtist> itemsResult;
            var folders = new MusicFolders();
            List<String> folderResult = new List<String>();
            List<MusicFolder> mfResult = new List<MusicFolder>();
            itemsResult = _libraryManager.GetArtists(query).Items.Select(i => i.Item1).Cast<MusicArtist>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";

            foreach (MusicArtist item in itemsResult)
            {
                if (!folderResult.Contains(item.ContainingFolderPath))
                {
                    var mf = new MusicFolder();
                    mf.id = (int)item.ParentId;
                    mf.name = item.ContainingFolderPath;
                    mfResult.Add(mf);
                }
            }

            folders.musicFolder = mfResult.ToArray();

            r.root["musicFolders"] = folders;
            str = JsonSerializer.Serialize(r, options);
            contentType = "text/json";

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        public async Task<object> Get(BrowsingGetArtists req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            // var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            var query = new InternalItemsQuery(null);


            List<MusicArtist> itemsResult;

            if (req.musicFolderId != null)
            {
                itemsResult = _libraryManager.GetArtists(query).Items.Where(i => i.Item1.ParentId.Equals(req.musicFolderId)).Cast<MusicArtist>().ToList();
            }
            else
            {
                itemsResult = _libraryManager.GetArtists(query).Items.Select(i => i.Item1).Cast<MusicArtist>().ToList();
            }

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

        public async Task<object> Get(BrowsingGetArtist req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            // var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            var query = new InternalItemsQuery(null);


            List<MusicArtist> itemsResult;


            itemsResult = _libraryManager.GetArtists(query).Items.Where(i => i.Item1.ExternalId.Equals(req.artistId)).Cast<MusicArtist>().ToList();
            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var artistID3 = new ArtistWithAlbumsID3();
            var albumListID3 = new AlbumListID3();
            var indexArray = new List<IndexID3>();
            Dictionary<String, List<ArtistID3>> d = new Dictionary<String, List<ArtistID3>>();
            List<AlbumID3> albumList = new List<AlbumID3>();


            foreach (MusicArtist item in itemsResult)
            {
                artistID3.id = item.Id.ToString();
                artistID3.name = item.Name;
                artistID3.coverArt = item.PrimaryImagePath;

                var rc = item.GetRecursiveChildren().AsQueryable().Where(i => i is MusicAlbum).ToList();
                artistID3.albumCount = rc.Count();
                var album = new AlbumID3();

                foreach (MusicAlbum al in rc)
                {
                    album.id = item.InternalId.ToString();
                    album.name = item.Name.ToString();
                    album.songCount = item.GetRecursiveChildren().Length;
                    album.created = item.DateCreated.DateTime;
                    album.duration = (int)(item.RunTimeTicks / TimeSpan.TicksPerSecond);
                    album.playCount = item.PlayCount;
                    album.artistId = artistID3.id;
                    album.artist = artistID3.name;
                    album.year = (int)(item.ProductionYear.HasValue ? item.ProductionYear : 0);
                    albumList.Add(album);
                }

            }

            artistID3.album = albumList.ToArray();

            r.root["artist"] = artistID3;
            str = JsonSerializer.Serialize(r, options);
            contentType = "text/json";

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(BrowsingGetAlbum req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var query = new InternalItemsQuery(user);

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Where(i => i.Item1.ExternalId.Equals(req.albumId)).Cast<MusicAlbum>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var album = new AlbumWithSongsID3();

            foreach (MusicAlbum item in itemsResult)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))

                album.id = item.InternalId.ToString();
                album.name = item.Name.ToString();
                album.songCount = item.GetRecursiveChildren().Length;
                album.created = item.DateCreated.DateTime;
                album.duration = (int)(item.RunTimeTicks / TimeSpan.TicksPerSecond);
                album.playCount = item.PlayCount;
                album.artistId = item.ArtistItems.FirstOrDefault()?.Id.ToString();
                album.artist = item.AlbumArtist;
                album.year = (int)(item.ProductionYear.HasValue ? item.ProductionYear : 0);
                // album.year = (int)item.ProductionYear;
                // album.genre = item.Genres[0].ToString();
                var rc = item.GetRecursiveChildren().AsQueryable().Where(i => i is Audio);
                var songList = new List<Child>();
                foreach (Audio rc2 in rc)
                {
                    var ch = new Child();
                    ch.id = rc2.InternalId.ToString();
                    ch.parent = rc2.ParentId.ToString();
                    ch.title = rc2.Name;
                    ch.isDir = rc2.IsFolder;
                    ch.type = MediaType2.music;
                    ch.albumId = rc2.AlbumId.ToString();
                    ch.album = rc2.Album;
                    ch.artistId = album.artistId.ToString();
                    ch.duration = (int)(rc2.RunTimeTicks / TimeSpan.TicksPerSecond);
                    ch.bitRate = rc2.TotalBitrate;
                    ch.track = (int)(rc2.IndexNumber.HasValue ? rc2.IndexNumber : 0);
                    ch.year = (int)(rc2.ProductionYear.HasValue ? rc2.ProductionYear : 0);
                    // ch.genre = rc2.Genres[0];
                    ch.size = rc2.Size;
                    ch.suffix = rc2.Container;
                    songList.Add(ch);
                }
                album.song = songList.ToArray();
            }

            r.root["album"] = album;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        // end Browsing methods
    }
}
