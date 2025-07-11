using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;

namespace EmbySonic.Api
{
    [Route("/rest/getAlbumList.view", "GET", Summary = "Returns a list of random, newest, highest rated etc. albums; similar to the album lists on the home page of the Subsonic web interface", Description = "Returns a <subsonic-response> element with a nested <albumList> element on success")]
    public class ListAlbum : SystemBase
    {
        [ApiMember(Name = "Size", Description = "The number of albums to return; max 500", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int size { get; set; }

        [ApiMember(Name = "Type", Description = "The list type; must be one of the following: random, newest, frequent, recent, starred, alphabeticalByName or alphabeticalByArtist; since 1.10.1 you can use byYear and byGenre to list albums in a given year range or genre", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String type { get; set; }

        [ApiMember(Name = "Offset", Description = "The list offset; useful if you for example want to page through the list of newest albums", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int offset { get; set; }

        [ApiMember(Name = "From Year", Description = "The first year in the range; if fromYear > toYear a reverse chronological list is returned", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int fromYear { get; set; }

        [ApiMember(Name = "To Year", Description = "The last year in the range", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int toYear { get; set; }

        [ApiMember(Name = "Genre", Description = "The name of the genre, e.g., \"Rock\"", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.11.0) Only return albums in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String musicFolderId { get; set; }
    }

    [Route("/rest/getAlbumList2.view", "GET", Summary = "Similar to getAlbumList, but organizes music according to ID3 tags", Description = "Returns a <subsonic-response> element with a nested <albumList2> element on success")]
    public class ListAlbum2 : SystemBase
    {
        [ApiMember(Name = "Size", Description = "The number of albums to return; max 500", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int size { get; set; }

        [ApiMember(Name = "Type", Description = "The list type; must be one of the following: random, newest, frequent, recent, starred, alphabeticalByName or alphabeticalByArtist; since 1.10.1 you can use byYear and byGenre to list albums in a given year range or genre", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String type { get; set; }

        [ApiMember(Name = "Offset", Description = "The list offset; useful if you for example want to page through the list of newest albums", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int offset { get; set; }

        [ApiMember(Name = "From Year", Description = "The first year in the range; if fromYear > toYear a reverse chronological list is returned", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int fromYear { get; set; }

        [ApiMember(Name = "To Year", Description = "The last year in the range", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int toYear { get; set; }

        [ApiMember(Name = "Genre", Description = "The name of the genre, e.g., \"Rock\"", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.11.0) Only return albums in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String musicFolderId { get; set; }
    }
    [Route("/rest/getRandomSongs.view", "GET", Summary = "Returns random songs matching the given criteria", Description = "Returns a <subsonic-response> element with a nested <randomSongs> element on success")]
    public class ListRandomSongs : SystemBase
    {
        [ApiMember(Name = "Size", Description = "The number of songs to return; max 500", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int size { get; set; }

        [ApiMember(Name = "From Year", Description = "Only return songs published after or in this year", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int fromYear { get; set; }

        [ApiMember(Name = "To Year", Description = "Only return songs published before or in this year", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int toYear { get; set; }

        [ApiMember(Name = "Genre", Description = "Only returns songs belonging to this genre", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "Only return songs in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String musicFolderId { get; set; }
    }

    [Route("/rest/getSongsByGenre.view", "GET", Summary = "Returns songs in a given genre", Description = "Returns a <subsonic-response> element with a nested <songsByGenre> element on success")]
    public class ListSongsByGenre : SystemBase
    {
        [ApiMember(Name = "Count", Description = " 	The maximum number of songs to return; max 500", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int count { get; set; }

        [ApiMember(Name = "Offset", Description = "The offset; seful if you want to page through the songs in a genre", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int offset { get; set; }

        [ApiMember(Name = "Genre", Description = "The genre, as returned by getGenres", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.12.0) Only return albums in the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String musicFolderId { get; set; }
    }

    [Route("/rest/getNowPlaying.view", "GET", Summary = "Returns what is currently being played by all users; takes no extra parameters", Description = "Returns a <subsonic-response> element with a nested <nowPlaying> element on success")]
    public class ListNowPlaying : SystemBase
    {
    }

    [Route("/rest/getStarred.view", "GET", Summary = "Returns starred songs, albums and artists", Description = "Returns a <subsonic-response> element with a nested <starred2> element on success")]
    public class ListStarred : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.12.0) Only return results from the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String musicFolderId { get; set; }
    }

    [Route("/rest/getStarred2.view", "GET", Summary = "Similar to getStarred, but organizes music according to ID3 tags", Description = "Returns a <subsonic-response> element with a nested <starred> element on success")]
    public class ListStarred2 : SystemBase
    {
        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.12.0) Only return results from the music folder with the given ID; see getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String musicFolderId { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        private String GetEmbyListType(string SubsonicListType)
        {
            switch (SubsonicListType)
            {
                case "random": return "Random";
                case "alphabeticalByName": return "Album";
                case "alphabeticalByArtist": return "Artist";
                case "recent": return "DateCreated&SortOrder=Descending";
                case "newest": return "ProductionYear&SortOrder=Descending";
                case "highest": return "CriticRating&SortOrder=Descending";
                default: return "Random";
            }
        }

        public async Task<object> Get(ListAlbum2 req)
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

                // let's get ID3 albums
                String sz = Convert.ToString(req.size == 0 ? 10 : req.size);
                String ty = GetEmbyListType(req.type);
                url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=MusicAlbum&ExcludeItemTypes=Folder&Recursive=true&Limit={1}&SortBy={2}", Plugin.Instance.Configuration.LocalEmbyPort, sz, ty);
                HttpResponseMessage mes = await c.GetAsync(url);
                hrmraw = await mes.Content.ReadAsStringAsync();
                JsonDocument j = JsonDocument.Parse(hrmraw);

                JsonElement returnedAlbums = j.RootElement.GetProperty("Items");
                List<AlbumID3> albums;
                AddAlbumsToList(returnedAlbums, req, out albums);
                AlbumListID3 al = new AlbumListID3();

                if (string.IsNullOrEmpty(req.f))
                {
                    Response r = new Response();
                    contentType = "text/xml";
                    r.ItemElementName = EmbySonic.ItemChoiceType.albumList2;
                    al.album = albums.ToArray();
                    r.Item = al;
                    r.version = SupportedSubsonicApiVersion;
                    str = Serializer<Response>.Serialize(r);
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
                    al.album = albums.ToArray();
                    r.root["_status"] = "ok";
                    r.root["albumList2"] = al;
                    str = JsonSerializer.Serialize(r, options);
                }

            }
            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        public async Task<object> Get(ListRandomSongs req)
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

                await GetMusicLibId(req);

                if (!String.IsNullOrEmpty(this.musicLibId))
                {
                    // library exists so let's get ID3 songs
                    String sz = Convert.ToString(req.size == 0 ? 10 : req.size);
                    url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&IncludeItemTypes=Audio&ExcludeItemTypes=Folder&Limit={2}&Recursive=true&SortBy=Random", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId, sz);
                    HttpResponseMessage mes = await c.GetAsync(url);
                    hrmraw = await mes.Content.ReadAsStringAsync();
                    JsonDocument j = JsonDocument.Parse(hrmraw);

                    JsonElement returnedSongs = j.RootElement.GetProperty("Items");
                    List<Child> songs;
                    AddSongsToList(returnedSongs, req, out songs);
                    Songs sl = new Songs();

                    if (string.IsNullOrEmpty(req.f))
                    {
                        Response r = new Response();
                        contentType = "text/xml";
                        r.ItemElementName = EmbySonic.ItemChoiceType.randomSongs;
                        sl.song = songs.ToArray();
                        r.Item = sl;
                        r.version = SupportedSubsonicApiVersion;
                        str = Serializer<Response>.Serialize(r);
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
                        sl.song = songs.ToArray();
                        r.root["_status"] = "ok";
                        r.root["randomSongs"] = sl;
                        str = JsonSerializer.Serialize(r, options);
                    }
                }
            }
            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        public async Task<object> Get(ListAlbum req)
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

                await GetMusicLibId(req);

                if (!String.IsNullOrEmpty(this.musicLibId))
                {
                    // library exists so let's get all the artists that have albums first
                    url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId);
                    HttpResponseMessage mes = await c.GetAsync(url);
                    hrmraw = await mes.Content.ReadAsStringAsync();
                    JsonDocument j = JsonDocument.Parse(hrmraw);

                    JsonElement allArtists = j.RootElement.GetProperty("Items");

                    StringBuilder sb = new StringBuilder();

                    // now let's get each artist ID into an exclusion list because....
                    foreach (JsonElement artist in allArtists.EnumerateArray())
                    {
                        sb.AppendFormat("{0},", artist.GetProperty("Id").ToString());
                    }

                    String sz = Convert.ToString(req.size == 0 ? 10 : req.size);
                    String ty = GetEmbyListType(req.type);

                    // ....we want to exclude artist-only records in our hierarchical library....
                    url = String.Format("http://localhost:{0}/emby/Items?Recursive=true&ParentId={1}&IncludeItemTypes=Folder&ExcludeItemTypes=Audio&ExcludeItemIds={2}&SortBy={3}&Limit={4}&Fields=ParentId", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId, sb.ToString(), ty, sz);
                    hrm = await c.GetAsync(url);
                    hrmraw = await hrm.Content.ReadAsStringAsync();
                    JsonDocument k = JsonDocument.Parse(hrmraw);

                    JsonElement returnedAlbums = k.RootElement.GetProperty("Items");
                    List<Child> albums;
                    AddAlbumsToList(returnedAlbums, req, out albums);
                    AlbumList al = new AlbumList();

                    if (string.IsNullOrEmpty(req.f))
                    {
                        Response r = new Response();
                        contentType = "text/xml";
                        r.ItemElementName = EmbySonic.ItemChoiceType.albumList;
                        al.album = albums.ToArray();
                        r.Item = al;
                        r.version = SupportedSubsonicApiVersion;
                        str = Serializer<Response>.Serialize(r);
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
                        al.album = albums.ToArray();
                        r.root["_status"] = "ok";
                        r.root["albumList"] = al;
                        str = JsonSerializer.Serialize(r, options);
                    }
                }
            }
            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        private static void AddAlbumsToList(JsonElement ra, ListAlbum r, out List<Child> l)
        {
            l = new List<Child>();
            foreach (JsonElement album in ra.EnumerateArray())
            {
                Child ch = new Child();
                ch.id = album.GetProperty("Id").ToString();
                ch.parent = album.GetProperty("ParentId").ToString();
                ch.title = album.GetProperty("Name").ToString();
                ch.coverArt = album.GetProperty("ImageTags").GetProperty("Primary").ToString();
                l.Add(ch);
            }
        }

        private static void AddAlbumsToList(JsonElement ra, ListAlbum2 r, out List<AlbumID3> l)
        {
            l = new List<AlbumID3>();
            foreach (JsonElement album in ra.EnumerateArray())
            {
                AlbumID3 aid3 = new AlbumID3();
                aid3.id = album.GetProperty("Id").ToString();
                aid3.artistId = album.GetProperty("AlbumArtists")[0].GetProperty("Id").ToString();
                aid3.artist = album.GetProperty("AlbumArtists")[0].GetProperty("Name").ToString();
                aid3.name = album.GetProperty("Name").ToString();

                JsonElement imgtags;
                JsonElement primaryimg;

                if (album.TryGetProperty("ImageTags", out imgtags))
                {
                    if (album.TryGetProperty("Primary", out primaryimg))
                    {
                        aid3.coverArt = primaryimg.ToString();
                    }
                }

                aid3.duration = (int)TimeSpan.FromTicks(album.GetProperty("RunTimeTicks").GetInt64()).TotalSeconds;
                l.Add(aid3);
            }
        }

        private static void AddSongsToList(JsonElement rs, ListRandomSongs r, out List<Child> l)
        {
            l = new List<Child>();
            foreach (JsonElement song in rs.EnumerateArray())
            {
                Child ch = new Child();
                ch.id = song.GetProperty("Id").ToString();
                ch.parent = song.GetProperty("AlbumId").ToString();
                ch.title = song.GetProperty("Name").ToString();
                ch.isDir = song.GetProperty("IsFolder").GetBoolean();
                ch.album = song.GetProperty("Album").ToString();
                ch.artist = song.GetProperty("Artists")[0].ToString();
                ch.track = song.GetProperty("IndexNumber").GetInt32();
                ch.coverArt = song.GetProperty("AlbumPrimaryImageTag").ToString();
                ch.duration = (int)TimeSpan.FromTicks(song.GetProperty("RunTimeTicks").GetInt64()).TotalSeconds;
                l.Add(ch);
            }
        }
    }
}