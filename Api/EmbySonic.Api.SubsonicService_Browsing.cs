using MediaBrowser.Model.Services;
using System.Text;
using System.Text.Json;

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

                Dictionary<String, List<EmbySonic.AlbumID3>> d = new Dictionary<String, List<EmbySonic.AlbumID3>>();

                String artistName = string.Empty;
                String artistId = string.Empty;

                foreach (JsonElement album in allID3Albums.EnumerateArray())
                {
                    JsonElement aa = album.GetProperty("AlbumArtists")[0];

                    if (aa.GetProperty("Id").ToString().Equals(req.id))
                    {
                        if (!d.ContainsKey(req.id))
                        {
                            d.Add(req.id, new List<EmbySonic.AlbumID3>());
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

                EmbySonic.ArtistWithAlbumsID3 awa = new ArtistWithAlbumsID3();
                awa.name = artistName;
                awa.id = artistId;
                awa.albumCount = d[artistId].Count;
                awa.album = d[artistId].ToArray();

                if (string.IsNullOrEmpty(req.f))
                {

                    EmbySonic.Response r = new EmbySonic.Response();
                    r.Item = awa;
                    r.ItemElementName = EmbySonic.ItemChoiceType.artist;
                    str = Serializer<EmbySonic.Response>.Serialize(r);
                    contentType = "text/xml";
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

                // let's get a list of all ID3 songs
                url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=Audio&Recursive=true", Plugin.Instance.Configuration.LocalEmbyPort);
                HttpResponseMessage mes = await c.GetAsync(url);
                hrmraw = await mes.Content.ReadAsStringAsync();
                JsonDocument k = JsonDocument.Parse(hrmraw);
                JsonElement allID3Songs = k.RootElement.GetProperty("Items");

                // now store all albums UNIQUELY per artist
                Dictionary<String, HashSet<String>> d = new Dictionary<String, HashSet<String>>();

                // make an artist ID lookup dictionary for convenience
                Dictionary<String, ArtistPackage> artistWithId = new Dictionary<String, ArtistPackage>();

                String albumArtist = string.Empty;
                String artistId = string.Empty;
                JsonElement je;
                foreach (JsonElement song in allID3Songs.EnumerateArray())
                {
                    if (!song.TryGetProperty("AlbumArtist", out je) || !song.TryGetProperty("Album", out je))
                    {
                        continue;
                    }

                    foreach (JsonElement items in song.GetProperty("ArtistItems").EnumerateArray())
                    {
                        artistId = items.GetProperty("Id").ToString();
                        albumArtist = items.GetProperty("Name").ToString();
                        break;
                    }

                    // not worrying about artists that don't begin with a letter right now
                    if (!Char.IsLetter(albumArtist[0]))
                    {
                        continue;
                    }

                    if (!d.ContainsKey(albumArtist))
                    {
                        d.Add(albumArtist, new HashSet<String>());
                    }

                    String album = song.GetProperty("Album").ToString();

                    d[albumArtist].Add(album);

                    if (!artistWithId.ContainsKey(albumArtist))
                    {
                        ArtistPackage ta = new ArtistPackage();
                        ta.artistName = albumArtist;
                        ta.artistId = artistId;
                        artistWithId.Add(albumArtist, ta);
                    }
                }

                var sortedDict = from entry in d orderby entry.Key ascending select entry;

                // now let's put each artist/albumlist pair into a queue for easier processing with a custom object
                Queue<ArtistPackage> q = new Queue<ArtistPackage>();
                foreach (KeyValuePair<string, HashSet<String>> entry in sortedDict)
                {
                    ArtistPackage ap = artistWithId[entry.Key];
                    ap.albums = entry.Value;
                    q.Enqueue(ap);
                }

                List<EmbySonic.IndexID3> li = this.GetLetterIndex(q);
                EmbySonic.ArtistsID3 a = new EmbySonic.ArtistsID3();
                a.ignoredArticles = "The El La Los Las Le Les";
                a.index = li.ToArray();

                if (string.IsNullOrEmpty(req.f))
                {

                    EmbySonic.Response r = new EmbySonic.Response();
                    r.Item = a;
                    r.ItemElementName = EmbySonic.ItemChoiceType.artists;
                    str = Serializer<EmbySonic.Response>.Serialize(r);
                    contentType = "text/xml";
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
                    r.root["_status"] = "ok";
                    r.root["artists"] = a;
                    str = JsonSerializer.Serialize(r, options);
                }


            }
            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        private List<EmbySonic.IndexID3> GetLetterIndex(Queue<ArtistPackage> q)
        {
            EmbySonic.ArtistsID3 artistListID3 = new EmbySonic.ArtistsID3();
            List<EmbySonic.IndexID3> letterIndex = new List<IndexID3>();

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
                        EmbySonic.IndexID3 idx = new IndexID3();
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

                // we need the unique ID for the desired music library set in the plugin configuration
                url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
                hrm = await c.GetAsync(url);
                hrmraw = await hrm.Content.ReadAsStringAsync();
                JsonDocument j = JsonDocument.Parse(hrmraw);
                JsonElement allLibs = j.RootElement.GetProperty("Items");
                String GetLetterIndex = String.Empty;

                List<EmbySonic.MusicFolder> mfl = new List<EmbySonic.MusicFolder>();
                EmbySonic.MusicFolders m = new EmbySonic.MusicFolders();

                foreach (JsonElement lib in allLibs.EnumerateArray())
                {
                    s = lib.GetProperty("Name").ToString();
                    if (String.Equals(s, Plugin.Instance.Configuration.MusicLibraryName))
                    {
                        EmbySonic.MusicFolder mf = new EmbySonic.MusicFolder();
                        mf.name = s;
                        mf.id = Int32.Parse(lib.GetProperty("Id").ToString());
                        mfl.Add(mf);
                        break;
                    }
                }
                m.musicFolder = mfl.ToArray();

                if (string.IsNullOrEmpty(req.f))
                {

                    EmbySonic.Response r = new EmbySonic.Response();
                    r.Item = m;
                    r.ItemElementName = EmbySonic.ItemChoiceType.musicFolders;
                    str = Serializer<EmbySonic.Response>.Serialize(r);
                    contentType = "text/xml";
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
                    r.root["_status"] = "ok";
                    r.root["musicFolders"] = m;
                    str = JsonSerializer.Serialize(r, options);
                }


            }
            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }


        public async Task<object> Get(BrowsingGetIndexes req)
        {
            HttpResponseMessage hrm = await Login(req);
            String contentType = String.Empty;
            String str = String.Empty;
            String hrmraw = String.Empty;
            String s = String.Empty;
            String url = String.Empty;
            JsonDocument j;
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
                    // we want a certain music folder, so let's get all of them first
                    if (!String.IsNullOrEmpty(req.musicFolderId))
                    {
                        url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&Recursive=true&IncludeItemTypes=Folder&Fields=ParentId", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId);
                        hrm = await c.GetAsync(url);
                        hrmraw = await hrm.Content.ReadAsStringAsync();
                        j = JsonDocument.Parse(hrmraw);
                        JsonElement allFolders = j.RootElement.GetProperty("Items");
                        EmbySonic.Directory d = new EmbySonic.Directory();
                        List<EmbySonic.Child> l = new List<EmbySonic.Child>();

                        // for each folder let's find out if it is a parent or child music directory and add to the appropriate collection
                        foreach (JsonElement folder in allFolders.EnumerateArray())
                        {
                            if (folder.GetProperty("Id").ToString().Equals(req.musicFolderId))
                            {
                                d.parent = folder.GetProperty("ParentId").ToString();
                                d.id = folder.GetProperty("Id").ToString();
                                d.name = folder.GetProperty("Name").ToString();
                            }
                            else if (folder.GetProperty("ParentId").ToString().Equals(req.musicFolderId))
                            {
                                EmbySonic.Child c = new EmbySonic.Child();
                                c.id = folder.GetProperty("Id").ToString();
                                c.parent = folder.GetProperty("ParentId").ToString();
                                c.title = folder.GetProperty("Name").ToString();
                                c.artist = d.name;
                                c.isDir = folder.GetProperty("IsFolder").GetBoolean();
                                c.coverArt = folder.GetProperty("ImageTags").GetProperty("Primary").ToString();
                                l.Add(c);
                            }
                        }

                        d.child = l.ToArray();

                        if (string.IsNullOrEmpty(req.f))
                        {
                            EmbySonic.Response r = new EmbySonic.Response();
                            r.Item = d;
                            r.ItemElementName = EmbySonic.ItemChoiceType.directory;
                            str = Serializer<EmbySonic.Response>.Serialize(r);
                            contentType = "text/xml";
                            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
                            await c.PostAsync(url, null);
                            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
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
                            r.root["_status"] = "ok";
                            r.root["directory"] = d;
                            str = JsonSerializer.Serialize(r, options);
                            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
                            await c.PostAsync(url, null);
                            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
                        }

                    }

                    // library exists so first let's get all artists....
                    url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&SortBy=Name", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId);
                    hrm = await c.GetAsync(url);
                    hrmraw = await hrm.Content.ReadAsStringAsync();
                    j = JsonDocument.Parse(hrmraw);
                    JsonElement allArtists = j.RootElement.GetProperty("Items");
                    Queue<JsonElement> q = new Queue<JsonElement>();

                    // ....and put them in a FIFO Queue
                    foreach (JsonElement artist in allArtists.EnumerateArray())
                    {
                        q.Enqueue(artist);
                    }

                    EmbySonic.Indexes indexes = new EmbySonic.Indexes();
                    List<EmbySonic.Index> letterIndex = new List<EmbySonic.Index>();

                    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

                    // for each letter of the alphabet....
                    foreach (char c in alpha)
                    {
                        JsonElement r;
                        if (q.TryPeek(out r))
                        {
                            List<EmbySonic.Artist> artistList = new List<EmbySonic.Artist>();

                            // if there are any artists that begin with this letter, dequeue and add to index's artist array
                            char ch = q.Peek().GetProperty("Name").ToString()[0];
                            while (ch.Equals(c))
                            {
                                JsonElement je = q.Dequeue();
                                EmbySonic.Artist a = new EmbySonic.Artist();
                                a.id = je.GetProperty("Id").ToString();
                                a.name = je.GetProperty("Name").ToString();
                                artistList.Add(a);
                                if (!q.TryPeek(out r))
                                {
                                    break;
                                }
                                else
                                {
                                    ch = q.Peek().GetProperty("Name").ToString()[0];
                                }
                            }

                            // if any artists for that letter existed, add the index to the master indexes list
                            if (artistList.Any())
                            {
                                EmbySonic.Index i = new EmbySonic.Index();
                                i.name = c.ToString();
                                i.artist = artistList.ToArray();
                                letterIndex.Add(i);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    indexes.index = letterIndex.ToArray();

                    if (string.IsNullOrEmpty(req.f))
                    {

                        EmbySonic.Response r = new EmbySonic.Response();
                        r.Item = indexes;
                        r.ItemElementName = EmbySonic.ItemChoiceType.indexes;
                        str = Serializer<EmbySonic.Response>.Serialize(r);
                        contentType = "text/xml";
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
                        r.root["_status"] = "ok";
                        r.root["indexes"] = indexes;
                        str = JsonSerializer.Serialize(r, options);
                    }
                }
            }

            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);

        }
        public async Task<object> Get(BrowsingGetAlbum req)
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

                // first we get album (not the songs)
                url = String.Format("http://localhost:{0}/emby/Items?Ids={1}&Fields=ParentId", Plugin.Instance.Configuration.LocalEmbyPort, req.id);
                hrm = await c.GetAsync(url);
                hrmraw = await hrm.Content.ReadAsStringAsync();
                JsonDocument j = JsonDocument.Parse(hrmraw);
                JsonElement album = j.RootElement.GetProperty("Items")[0];
                JsonElement artist = album.GetProperty("ArtistItems")[0];

                // then we get the album's songs
                url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}", Plugin.Instance.Configuration.LocalEmbyPort, req.id);
                hrm = await c.GetAsync(url);
                hrmraw = await hrm.Content.ReadAsStringAsync();
                JsonDocument k = JsonDocument.Parse(hrmraw);
                JsonElement ss = k.RootElement.GetProperty("Items");

                List<EmbySonic.Child> songs = new List<EmbySonic.Child>();

                // ....and then add each song to our list of songs for the album
                foreach (JsonElement song in ss.EnumerateArray())
                {
                    EmbySonic.Child ch = new EmbySonic.Child();
                    ch.id = song.GetProperty("Id").ToString();
                    ch.title = song.GetProperty("Name").ToString();
                    ch.album = album.GetProperty("Name").ToString();
                    ch.artist = artist.GetProperty("Name").ToString();
                    ch.isDir = song.GetProperty("IsFolder").GetBoolean();
                    ch.albumId = req.id;
                    ch.artistId = artist.GetProperty("Id").ToString();
                    ch.durationSpecified = true;
                    ch.duration = (int)TimeSpan.FromTicks(song.GetProperty("RunTimeTicks").GetInt64()).TotalSeconds;
                    songs.Add(ch);
                }

                Child[] songArray = songs.ToArray();

                // then we create the main album record....
                EmbySonic.AlbumWithSongsID3 aws = new EmbySonic.AlbumWithSongsID3();
                aws.id = req.id;
                aws.name = album.GetProperty("Name").ToString();
                aws.artist = artist.GetProperty("Name").ToString();
                aws.artistId = artist.GetProperty("Id").ToString();
                aws.songCount = Int32.Parse(k.RootElement.GetProperty("TotalRecordCount").ToString());
                aws.duration = (int)TimeSpan.FromTicks(album.GetProperty("RunTimeTicks").GetInt64()).TotalSeconds;

                // ....and the album's song list to that record
                aws.song = songArray;

                if (string.IsNullOrEmpty(req.f))
                {

                    EmbySonic.Response r = new EmbySonic.Response();
                    r.Item = aws;
                    r.ItemElementName = EmbySonic.ItemChoiceType.album;
                    str = Serializer<EmbySonic.Response>.Serialize(r);
                    contentType = "text/xml";
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
                    r.root["_status"] = "ok";
                    r.root["album"] = aws;
                    str = JsonSerializer.Serialize(r, options);
                }

            }

            url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
            await c.PostAsync(url, null);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);

        }
    }
}
