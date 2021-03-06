using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;

namespace EmbySonic.Api
{
    [Route("/rest/getAlbumList.view", "GET", Summary = "Gets all albums for all artists", Description = "Gets all albums for all artists")]
    public class ListAlbum : SystemBase
    {
        [ApiMember(Name = "Size", Description = "Number of items to return", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int size { get; set; }

        [ApiMember(Name = "Type", Description = "Type of list to return", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String type { get; set; }
    }

    [Route("/rest/getAlbumList2.view", "GET", Summary = "Gets all albums for all artists (ID3)", Description = "Gets all albums for all artists (ID3)")]
    public class ListAlbum2 : SystemBase
    {
        [ApiMember(Name = "Size", Description = "Number of items to return", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int size { get; set; }

        [ApiMember(Name = "Type", Description = "Type of list to return", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public String type { get; set; }
    }
    [Route("/rest/getRandomSongs.view", "GET", Summary = "Gets random songs (ID3)", Description = "Gets random songs (ID3)")]
    public class ListRandomSongs : SystemBase
    {
        [ApiMember(Name = "Size", Description = "Number of items to return", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int size { get; set; }
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
                List<EmbySonic.AlbumID3> albums;
                AddAlbumsToList(returnedAlbums, req, out albums);
                EmbySonic.AlbumListID3 al = new EmbySonic.AlbumListID3();

                if (string.IsNullOrEmpty(req.f))
                {
                    EmbySonic.Response r = new EmbySonic.Response();
                    contentType = "text/xml";
                    r.ItemElementName = EmbySonic.ItemChoiceType.albumList2;
                    al.album = albums.ToArray();
                    r.Item = al;
                    r.version = SupportedSubsonicApiVersion;
                    str = Serializer<EmbySonic.Response>.Serialize(r);
                }
                else if (req.f.Equals("json"))
                {
                    EmbySonic.JsonResponse r = new EmbySonic.JsonResponse();
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
                    List<EmbySonic.Child> songs;
                    AddSongsToList(returnedSongs, req, out songs);
                    EmbySonic.Songs sl = new EmbySonic.Songs();

                    if (string.IsNullOrEmpty(req.f))
                    {
                        EmbySonic.Response r = new EmbySonic.Response();
                        contentType = "text/xml";
                        r.ItemElementName = EmbySonic.ItemChoiceType.randomSongs;
                        sl.song = songs.ToArray();
                        r.Item = sl;
                        r.version = SupportedSubsonicApiVersion;
                        str = Serializer<EmbySonic.Response>.Serialize(r);
                    }
                    else if (req.f.Equals("json"))
                    {
                        EmbySonic.JsonResponse r = new EmbySonic.JsonResponse();
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
                    List<EmbySonic.Child> albums;
                    AddAlbumsToList(returnedAlbums, req, out albums);
                    EmbySonic.AlbumList al = new EmbySonic.AlbumList();

                    if (string.IsNullOrEmpty(req.f))
                    {
                        EmbySonic.Response r = new EmbySonic.Response();
                        contentType = "text/xml";
                        r.ItemElementName = EmbySonic.ItemChoiceType.albumList;
                        al.album = albums.ToArray();
                        r.Item = al;
                        r.version = SupportedSubsonicApiVersion;
                        str = Serializer<EmbySonic.Response>.Serialize(r);
                    }
                    else if (req.f.Equals("json"))
                    {
                        EmbySonic.JsonResponse r = new EmbySonic.JsonResponse();
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

        private static void AddAlbumsToList(JsonElement ra, ListAlbum r, out List<EmbySonic.Child> l)
        {
            l = new List<EmbySonic.Child>();
            foreach (JsonElement album in ra.EnumerateArray())
            {
                EmbySonic.Child ch = new EmbySonic.Child();
                ch.id = album.GetProperty("Id").ToString();
                ch.parent = album.GetProperty("ParentId").ToString();
                ch.title = album.GetProperty("Name").ToString();
                ch.coverArt = album.GetProperty("ImageTags").GetProperty("Primary").ToString();
                l.Add(ch);
            }
        }

        private static void AddAlbumsToList(JsonElement ra, ListAlbum2 r, out List<EmbySonic.AlbumID3> l)
        {
            l = new List<EmbySonic.AlbumID3>();
            foreach (JsonElement album in ra.EnumerateArray())
            {
                EmbySonic.AlbumID3 aid3 = new EmbySonic.AlbumID3();
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

        private static void AddSongsToList(JsonElement rs, ListRandomSongs r, out List<EmbySonic.Child> l)
        {
            l = new List<EmbySonic.Child>();
            foreach (JsonElement song in rs.EnumerateArray())
            {
                EmbySonic.Child ch = new EmbySonic.Child();
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