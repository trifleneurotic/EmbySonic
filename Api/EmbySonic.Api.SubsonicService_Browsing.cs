using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;
using SQLite;
using System.Collections.Generic;
using System.Collections;

namespace EmbySonic.Api
{
    [Route("/rest/getAlbum.view", "GET", Summary = "Returns details for an album, including a list of songs; this method organizes music according to ID3 tags.", Description = "Returns a <subsonic-response> element with a nested <album> element on success")]
    public class BrowsingGetAlbum : SystemBase
    {
        [ApiMember(Name = "Album ID", Description = "The album ID", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? id { get; set; }
    }

    [Route("/rest/getArtists.view", "GET", Summary = "Similar to getIndexes, but organizes music according to ID3 tags", Description = "Returns a <subsonic-response> element with a nested <artists> element on success")]
    public class BrowsingGetArtists : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "If specified, only return artists in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    [Route("/rest/getArtist.view", "GET", Summary = "Returns details for an artist, including a list of albums; this method organizes music according to ID3 tags", Description = "Returns a <subsonic-response> element with a nested <artist> element on success")]
    public class BrowsingGetArtist : SystemBase
    {
        [ApiMember(Name = "Artist ID", Description = "The artist ID", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? id { get; set; }
    }

    [Route("/rest/getIndexes.view", "GET", Summary = "Returns an indexed structure of all artists", Description = "Returns a <subsonic-response> element with a nested <indexes> element on success")]
    public class BrowsingGetIndexes : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "If specified, only return artists in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }

        [ApiMember(Name = "If Modified Since", Description = "If specified, only return a result if the artist collection has changed since the given time (in milliseconds since 1 Jan 1970)", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? ifModifiedSince { get; set; }
    }

    [Route("/rest/getMusicFolders.view", "GET", Summary = "Returns all configured top-level music folders; takes no extra parameters", Description = "Returns a <subsonic-response> element with a nested <musicFolders> element on success")]
    public class BrowsingGetMusicFolders : SystemBase
    {
    }

    [Route("/rest/getMusicDirectory.view", "GET", Summary = "Returns a listing of all files in a music directory; typically used to get list of albums for an artist, or list of songs for an album", Description = "Returns a <subsonic-response> element with a nested <directory> element on success")]
    public class BrowsingGetMusicDirectory : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "A string which uniquely identifies the music folder; obtained by calls to getIndexes or getMusicDirectory", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? id { get; set; }
    }

    public class ArtistPackage
    {
        public HashSet<String> albums { get; set; }
        public String artistName { get; set; }
        public String artistId { get; set; }
    }

    public static class IEnumerableExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
           => self.Select((item, index) => (item, index));
    }

    [Table("MediaItems")]
    public class MediaItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid guid { get; set; }
        public int type { get; set; }
        public int ParentId { get; set; }
        public string Path { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public bool IsMovie { get; set; }
        public bool IsKids { get; set; }
        public bool IsSports { get; set; }
        public bool IsNews { get; set; }
        public float CommunityRating { get; set; }
        public string CustomRating { get; set; }
        public int IndexNumber { get; set; }
        public bool IsLocked { get; set; }
        public string Name { get; set; }
        public string OfficialRating { get; set; }
        public string Overview { get; set; }
        public int ParentIndexNumber { get; set; }
        public int PremiereDate { get; set; }
        public int ProductionYear { get; set; }
        public string SortName { get; set; }
        public long RunTimeTicks { get; set; }
        public int DateCreated { get; set; }
        public int DateModified { get; set; }
        public bool IsSeries { get; set; }
        public bool IsRepeat { get; set; }
        public string PreferredMetadataLanguage { get; set; }
        public string PreferredMetadataCountryCode { get; set; }
        public int DateLastRefreshed { get; set; }
        public int DateLastSaved { get; set; }
        public bool IsInMixedFolder { get; set; }
        public string LockedFields { get; set; }
        public int InheritedParentalRatingValue { get; set; }
        public int TopParentId { get; set; }
        public float CriticRating { get; set; }
        public string PresentationUniqueKey { get; set; }
        public string OriginalTitle { get; set; }
        public string SeriesName { get; set; }
        public string Album { get; set; }
        public int AlbumId { get; set; }
        public int SeriesId { get; set; }
        public string Tagline { get; set; }
        public string ProviderIds { get; set; }
        public string Images { get; set; }
        public string ProductionLocations { get; set; }
        public int TotalBitrate { get; set; }
        public int ExtraType { get; set; }
        public string SeriesPresentationUniqueKey { get; set; }
        public string ExternalId { get; set; }
        public int OwnerId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public string Container { get; set; }
        public int Status { get; set; }
        public int DisplayOrder { get; set; }
        public int ThreeDFormat { get; set; }
        public int UserDataKeyId { get; set; }
        public int SortIndexNumber { get; set; }
        public int SortParentIndexNumber { get; set; }
        public int IndexNumberEnd { get; set; }
        public string ChannelNumber { get; set; }
        public string RemoteTrailers { get; set; }
        public int IsPublic { get; set; }
        public bool IsNew { get; set; }
        public bool IsPremiere { get; set; }
        public bool IsLive { get; set; }

        //TODO: foreign key constraints
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(BrowsingGetMusicDirectory req)
        {
            BrowsingGetIndexes bgi = new BrowsingGetIndexes();
            bgi.musicFolderId = req.id;
            bgi.u = req.u;
            bgi.p = req.p;
            bgi.c = req.c;
            bgi.v = req.v;

            if (!String.IsNullOrEmpty(req.f))
            {
                bgi.f = req.f;
            }
            return await this.Get(bgi);
        }

        public async Task<object> Get(BrowsingGetArtist req)
        {
            HttpResponseMessage hrm = await Login(req);
            String contentType = String.Empty;
            String str = String.Empty;
            String hrmraw = String.Empty;
            String s = String.Empty;
            String url = String.Empty;
            if (!hrm.IsSuccessStatusCode)
            {
                str = GetErrorObject(req, out contentType);
            }
            else
            {
                hrmraw = await hrm.Content.ReadAsStringAsync();
                JsonDocument doc = JsonDocument.Parse(hrmraw);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("X-Emby-Token", doc.RootElement.GetProperty("AccessToken").ToString());

                // let's get a list of all ID3 albums
                url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=MusicAlbum&Recursive=true", Plugin.Instance.Configuration.LocalEmbyPort);
                HttpResponseMessage mes = await c.GetAsync(url);
                hrmraw = await mes.Content.ReadAsStringAsync();
                JsonDocument k = JsonDocument.Parse(hrmraw);
                JsonElement allID3Albums = k.RootElement.GetProperty("Items");

                Dictionary<String, List<AlbumID3>> d = new Dictionary<String, List<AlbumID3>>();

                String artistName = string.Empty;
                String artistId = string.Empty;

                foreach (JsonElement album in allID3Albums.EnumerateArray())
                {
                    JsonElement aa = album.GetProperty("AlbumArtists")[0];

                    if (aa.GetProperty("Id").ToString().Equals(req.id))
                    {
                        if (!d.ContainsKey(req.id))
                        {
                            d.Add(req.id, new List<AlbumID3>());
                            artistName = aa.GetProperty("Name").ToString();
                            artistId = aa.GetProperty("Id").ToString();
                        }

                        AlbumID3 aid3 = new AlbumID3();
                        aid3.artist = artistName;
                        aid3.artistId = artistId;

                        aid3.duration = (int)TimeSpan.FromTicks(album.GetProperty("RunTimeTicks").GetInt64()).TotalSeconds;
                        aid3.id = album.GetProperty("Id").ToString();
                        aid3.name = album.GetProperty("Name").ToString();

                        // get album track count
                        url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}", Plugin.Instance.Configuration.LocalEmbyPort, aid3.id);
                        mes = await c.GetAsync(url);
                        hrmraw = await mes.Content.ReadAsStringAsync();
                        JsonDocument r = JsonDocument.Parse(hrmraw);
                        aid3.songCount = Int32.Parse(r.RootElement.GetProperty("TotalRecordCount").ToString());

                        d[req.id].Add(aid3);

                    }
                }

                ArtistWithAlbumsID3 awa = new ArtistWithAlbumsID3();
                awa.name = artistName;
                awa.id = artistId;
                awa.albumCount = d[artistId].Count;
                awa.album = d[artistId].ToArray();

                if (string.IsNullOrEmpty(req.f))
                {

                    Response r = new Response();
                    r.Item = awa;
                    r.ItemElementName = EmbySonic.ItemChoiceType.artist;
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    contentType = "text/json";
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["_status"] = "ok";
                    r.root["artist"] = awa;
                    str = JsonSerializer.Serialize(r, options);
                }
            }
            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(BrowsingGetArtists req)
        {
            HttpResponseMessage hrm = await Login(req);
            String contentType = String.Empty;
            String str = String.Empty;
            if (!hrm.IsSuccessStatusCode)
            {
                str = GetErrorObject(req, out contentType);
            }
            else
            {
                var databasePath = Path.Combine("", "library.db");
                var db = new SQLiteConnection(databasePath);

                List<Artist> al = new List<Artist>();

                var artistResults = db.Query<Artist>(@"SELECT * FROM MediaItems WHERE id IN
                                                    (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                    (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                    (SELECT DISTINCT ParentId FROM MediaItems WHERE name IN
                                                    (SELECT DISTINCT name FROM MediaItems WHERE name IN
                                                    (SELECT Name FROM MediaItems WHERE id IN
                                                    (SELECT DISTINCT AlbumId FROM MediaItems WHERE Type=11 AND AlbumId IS NOT NULL))) AND type=3))) AND ParentID NOT IN
                                                    (SELECT id FROM MediaItems WHERE id IN
                                                    (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                    (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                    (SELECT DISTINCT ParentId FROM MediaItems WHERE name IN
                                                    (SELECT DISTINCT name FROM MediaItems WHERE name IN
                                                    (SELECT Name FROM MediaItems WHERE id IN
                                                    (SELECT DISTINCT AlbumId FROM MediaItems WHERE Type=11 AND AlbumId IS NOT NULL))) AND type=3))));");

                foreach (var item in artistResults)
                {
                    Artist ast = new Artist();
                    ast.name = item.name;
                    ast.id = item.id.ToString();
                    ast.artistImageUrl = item.artistImageUrl;
                    ast.averageRating = item.averageRating;
                    ast.averageRatingSpecified = item.averageRatingSpecified;
                    ast.starred = item.starred;
                    ast.starredSpecified = item.starredSpecified;
                    ast.userRating = item.userRating;
                    ast.userRatingSpecified = item.userRatingSpecified;
                    ast.userRating = item.userRating;
                    ast.userRatingSpecified = item.userRatingSpecified;

                    al.Add(ast);
                }

                if (string.IsNullOrEmpty(req.f))
                {
                    Response r = new Response();
                    r.Item = al.ToArray<Artist>();
                    r.ItemElementName = EmbySonic.ItemChoiceType.artists;
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    contentType = "text/json";
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["_status"] = "ok";
                    r.root["artists"] = al.ToArray<Artist>();
                    str = JsonSerializer.Serialize(r, options);
                }
                db.Close();
            }
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        private List<IndexID3> GetLetterIndex(Queue<ArtistPackage> q)
        {
            ArtistsID3 artistListID3 = new ArtistsID3();
            List<IndexID3> letterIndex = new List<IndexID3>();

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // for each letter of the alphabet....
            foreach (char c in alpha)
            {
                ArtistPackage artpac;
                if (q.TryPeek(out artpac))
                {
                    List<ArtistID3> artistIndex = new List<ArtistID3>();

                    char ch = q.Peek().artistName[0];

                    // ....let's get all artists that begin with that letter
                    while (Char.ToUpper(ch).Equals(Char.ToUpper(c)))
                    {
                        ArtistPackage arp = q.Dequeue();
                        ArtistID3 toAdd = new ArtistID3();
                        toAdd.name = arp.artistName;
                        toAdd.albumCount = arp.albums.Count;
                        toAdd.id = arp.artistId;
                        artistIndex.Add(toAdd);
                        if (!q.TryPeek(out artpac))
                        {
                            break;
                        }
                        else
                        {
                            ch = q.Peek().artistName[0];
                        }
                    }

                    // if any artists for that letter existed, add the index to the master indexes list
                    if (artistIndex.Any())
                    {
                        IndexID3 idx = new IndexID3();
                        idx.name = Char.ToUpper(c).ToString();
                        idx.artist = artistIndex.ToArray();
                        letterIndex.Add(idx);
                    }
                }
                else
                {
                    break;
                }
            }
            return letterIndex;

        }

        public async Task<object> Get(BrowsingGetMusicFolders req)
        {
            HttpResponseMessage hrm = await Login(req);
            String contentType = String.Empty;
            String str = String.Empty;
            if (!hrm.IsSuccessStatusCode)
            {
                str = GetErrorObject(req, out contentType);
            }
            else
            {
                var databasePath = Path.Combine("", "library.db");
                var db = new SQLiteConnection(databasePath);

                List<MusicFolder> mfl = new List<MusicFolder>();
                MusicFolders m = new MusicFolders();

                var musicFolderResults = db.Query<MediaItem>(@"SELECT * FROM MediaItems WHERE id IN
                                                              (SELECT ParentId FROM MediaItems WHERE id IN
                                                              (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                              (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                              (SELECT DISTINCT ParentId FROM MediaItems WHERE name IN
                                                              (SELECT DISTINCT name FROM MediaItems WHERE name IN
                                                              (SELECT Name FROM MediaItems WHERE id IN
                                                              (SELECT DISTINCT AlbumId FROM MediaItems WHERE Type=11 AND AlbumId IS NOT NULL)))
                                                              AND type=3))))
                                                              AND ParentId=2;");
                foreach (var item in musicFolderResults)
                {
                    MusicFolder mf = new MusicFolder();
                    mf.name = item.Name;
                    mf.id = item.Id;
                    mfl.Add(mf);
                }
                m.musicFolder = mfl.ToArray();

                if (string.IsNullOrEmpty(req.f))
                {

                    Response r = new Response();
                    r.Item = m;
                    r.ItemElementName = EmbySonic.ItemChoiceType.musicFolders;
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    contentType = "text/json";
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["_status"] = "ok";
                    r.root["musicFolders"] = m;
                    str = JsonSerializer.Serialize(r, options);
                }
                db.Close();
            }
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        public async Task<object> Get(BrowsingGetIndexes req)
        {
            HttpResponseMessage hrm = await Login(req);
            String contentType = String.Empty;
            String str = String.Empty;
            if (!hrm.IsSuccessStatusCode)
            {
                str = GetErrorObject(req, out contentType);
            }
            else
            {
                var databasePath = Path.Combine("", "library.db");
                var db = new SQLiteConnection(databasePath);

                var indexes = new Indexes();

                List<Artist> al = new List<Artist>();
                Hashtable il = new Hashtable();
                List<MediaItem> artistResults = new List<MediaItem>();

                if (!String.IsNullOrEmpty(req.musicFolderId))
                {
                    artistResults = db.Query<MediaItem>(string.Format(@"""SELECT * FROM MediaItems WHERE id IN
                                                         (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                         (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                         (SELECT DISTINCT ParentId FROM MediaItems WHERE name IN
                                                         (SELECT DISTINCT name FROM MediaItems WHERE name IN
                                                         (SELECT Name FROM MediaItems WHERE id IN
                                                         (SELECT DISTINCT AlbumId FROM MediaItems WHERE Type=11
                                                         AND AlbumId IS NOT NULL)))
                                                         AND type=3))) AND ParentID={0};""", req.musicFolderId));
                }
                else
                {
                    artistResults = db.Query<MediaItem>(@"SELECT * FROM MediaItems WHERE id IN
                                                         (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                         (SELECT DISTINCT ParentId FROM MediaItems WHERE ParentId IN
                                                         (SELECT DISTINCT ParentId FROM MediaItems WHERE name IN
                                                         (SELECT DISTINCT name FROM MediaItems WHERE name IN
                                                         (SELECT Name FROM MediaItems WHERE id IN
                                                         (SELECT DISTINCT AlbumId FROM MediaItems WHERE Type=11
                                                         AND AlbumId IS NOT NULL)))
                                                         AND type=3)));");
                }

                if (indexes.ignoredArticles == null)
                {
                    indexes.ignoredArticles = "The El La Los Las Le Les";
                }

                var ignoredArticlesArray = indexes.ignoredArticles.Split(' ');

                foreach (var item in artistResults)
                {
                    if (!String.IsNullOrEmpty(req.ifModifiedSince))
                    {
                        if (item.DateModified < Int32.Parse(req.ifModifiedSince))
                        {
                            continue;
                        }
                    }
                    Artist a = new Artist();
                    string artistName = item.Name;
                    foreach (var article in ignoredArticlesArray)
                    {
                        if (artistName.StartsWith(article))
                        {
                            artistName = artistName.Substring(article.Length).Trim();
                            break;
                        }
                    }
                    a.name = artistName;
                    a.id = item.Id.ToString();
                    al.Add(a);
                }

                foreach (var item in al)
                {
                    if (string.IsNullOrEmpty(item.name))
                    {
                        continue;
                    }
                    string key = item.name[0].ToString();
                    if (il.ContainsKey(key))
                    {
                        List<Artist> artistList = (List<Artist>)il[key];
                        artistList!.Add(item);
                    }
                    else
                    {
                        List<Artist> artistList = new List<Artist>();
                        artistList.Add(item);
                        il.Add(key, artistList);
                    }
                }

                indexes.index = new Index[il.Count];

                foreach (var o in il.OfType<object>().Select((x, i) => new { x, i }))
                {
                    Index i = new Index();
                    DictionaryEntry dictionaryEntry = (DictionaryEntry)o.x;
                    i.name = dictionaryEntry.Key?.ToString() ?? string.Empty;
                    var artistList = dictionaryEntry.Value as List<Artist>;
                    i.artist = artistList != null ? artistList.ToArray() : Array.Empty<Artist>();
                    indexes.index[o.i] = i;
                }

                if (!String.IsNullOrEmpty(req.f))
                {
                    if (req.f.Equals("json"))
                    {
                        JsonResponse r = new JsonResponse();
                        contentType = "text/json";
                        var options = new JsonSerializerOptions
                        {
                            IgnoreNullValues = true,
                            WriteIndented = true
                        };
                        r.root["_status"] = "ok";
                        r.root["indexes"] = indexes.index;
                        str = JsonSerializer.Serialize(r, options);
                    }
                }
                else
                {
                    Response r = new Response();
                    r.Item = indexes;
                    r.ItemElementName = EmbySonic.ItemChoiceType.indexes;
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                db.Close();
            }

            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        public async Task<object> Get(BrowsingGetAlbum req)
        {

            HttpResponseMessage hrm = await Login(req);
            String contentType = String.Empty;
            String str = String.Empty;
            if (!hrm.IsSuccessStatusCode)
            {
                str = GetErrorObject(req, out contentType);
            }
            else
            {
                var databasePath = Path.Combine("", "library.db");
                var db = new SQLiteConnection(databasePath);

                AlbumID3 aid3 = db.Query<AlbumID3>($@"SELECT * FROM MediaItems WHERE Id = '{req.id}' AND Type=11;").FirstOrDefault();
                if (aid3 != null)
                {
                    AlbumWithSongsID3 aws = new AlbumWithSongsID3();
                    aws.id = aid3.id;
                    aws.name = aid3.name;
                    aws.artist = aid3.artist;
                    aws.artistId = aid3.artistId;
                    aws.duration = aid3.duration;
                    aws.songCount = 0;
                    aws.year = aid3.year;
                    aws.coverArt = aid3.coverArt;
                    aws.genre = aid3.genre;
                    var songs = db.Query<Child>($@"SELECT * FROM MediaItems WHERE AlbumId = '{req.id}' AND Type=11 ORDER BY IndexNumber;");
                    aws.songCount = songs.Count;
                    aws.song = songs.ToArray();
                }
                else
                {
                    aid3 = new AlbumID3();
                    if (req.id != null)
                    {
                        aid3.id = req.id;
                    }
                }


                if (string.IsNullOrEmpty(req.f))
                {
                    Response r = new Response();
                    r.Item = aid3;
                    r.ItemElementName = EmbySonic.ItemChoiceType.album;
                    str = Serializer<Response>.Serialize(r);
                    contentType = "text/xml";
                }
                else if (req.f.Equals("json"))
                {
                    JsonResponse r = new JsonResponse();
                    contentType = "text/json";
                    var options = new JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        WriteIndented = true
                    };
                    r.root["_status"] = "ok";
                    r.root["album"] = aid3;
                    str = JsonSerializer.Serialize(r, options);

                }
                db.Close();
            }
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
    }
}
