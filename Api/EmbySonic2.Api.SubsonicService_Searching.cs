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


namespace EmbySonic2.Api
{
    [Route("/rest/search3", "GET", Summary = "Similar to search2, but organizes music according to ID3 tags.", Description = "Returns albums, artists and songs matching the given search criteria. Supports paging through the result.")]
    public class SearchingSearch3 : SystemBase
    {
        [ApiMember(Name = "query", Description = "Search query.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? query { get; set; }

        [ApiMember(Name = "artistOffset", Description = "Search result offset for artists. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? artistOffset { get; set; }

        [ApiMember(Name = "artistCount", Description = "Maximum number of artists to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? artistCount { get; set; }
        [ApiMember(Name = "albumOffset", Description = "Search result offset for albums. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? albumOffset { get; set; }
        [ApiMember(Name = "albumCount", Description = "Maximum number of albums to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? albumCount { get; set; }

        [ApiMember(Name = "songOffset", Description = "Search result offset for songs. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? songOffset { get; set; }
        [ApiMember(Name = "songCount", Description = "Maximum number of songs to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? songCount { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "Only return results in the music folder with the given ID. See getMusicFolders.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    [Route("/rest/search2", "GET", Summary = "Returns albums, artists and songs matching the given search criteria. Supports paging through the result.", Description = "Returns albums, artists and songs matching the given search criteria. Supports paging through the result.")]
    public class SearchingSearch2 : SystemBase
    {
        [ApiMember(Name = "query", Description = "Search query.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? query { get; set; }

        [ApiMember(Name = "artistOffset", Description = "Search result offset for artists. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? artistOffset { get; set; }

        [ApiMember(Name = "artistCount", Description = "Maximum number of artists to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? artistCount { get; set; }
        [ApiMember(Name = "albumOffset", Description = "Search result offset for albums. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? albumOffset { get; set; }
        [ApiMember(Name = "albumCount", Description = "Maximum number of albums to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? albumCount { get; set; }

        [ApiMember(Name = "songOffset", Description = "Search result offset for songs. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? songOffset { get; set; }
        [ApiMember(Name = "songCount", Description = "Maximum number of songs to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? songCount { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "Only return results in the music folder with the given ID. See getMusicFolders.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    [Route("/rest/search", "GET", Summary = "Returns a listing of files matching the given search criteria. Supports paging through the result.", Description = "Returns a listing of files matching the given search criteria. Supports paging through the result.")]
    public class SearchingSearch : SystemBase
    {
        [ApiMember(Name = "artist", Description = "Artist to search for.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? artist { get; set; }
        [ApiMember(Name = "album", Description = "Album to search for.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? album { get; set; }
        [ApiMember(Name = "title", Description = "Song title to search for.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? title { get; set; }
        [ApiMember(Name = "any", Description = "Searches all fields.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? any { get; set; }
        [ApiMember(Name = "count", Description = "Maximum number of results to return.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? count { get; set; }
        [ApiMember(Name = "offset", Description = "Search result offset. Used for paging.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? offset { get; set; }
        [ApiMember(Name = "newerThan", Description = "Only return matches that are newer than this. Given as milliseconds since 1970.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? newerThan { get; set; }
    }
    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(SearchingSearch3 req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var search3 = new SearchResult3();

            // start get albums by search term
            var query = new InternalItemsQuery(user);
            query.SearchTerm = req.query;
            query.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            query.Recursive = true;

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            var album = new AlbumID3();
            var albumList = new List<AlbumID3>();
            int numberOfAlbumsToPick = req.albumCount ?? 20;

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
                albumList.Add(album);
            }
            // end get albums by search term

            search3.album = albumList.Take(numberOfAlbumsToPick).ToArray();

            // start get songs by search term
            var query2 = new InternalItemsQuery(user);
            //query2.SearchTerm = req.query;
            query2.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            query2.Recursive = true;

            List<MusicAlbum> itemsResult2;

            itemsResult2 = _libraryManager.GetMusicAlbums(query2).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r2 = new JsonResponse();
            var options2 = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            var album2 = new AlbumID3();
            var songs = new List<Child>();
            var songList = new Songs();
            int numberOfSongsToPick = req.songCount ?? 20;

            foreach (MusicAlbum item in itemsResult)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))

                foreach (var song in item.GetRecursiveChildren().OfType<Audio>())
                {
                    if (song.Name.Contains(req.query, StringComparison.OrdinalIgnoreCase))
                    {
                        var child = new Child
                        {
                            artist = song.Artists != null && song.Artists.Length > 0 ? song.Artists[0] : item.AlbumArtist,
                            id = song.InternalId.ToString(),
                            parent = item.InternalId.ToString(),
                            title = song.Name,
                            album = item.Name,
                            duration = (int)(song.RunTimeTicks / TimeSpan.TicksPerSecond),
                            track = song.IndexNumber ?? 0,
                            year = item.ProductionYear ?? 0
                        };
                        songs.Add(child);
                    }
                }
            }
            // end get songs by search term

            search3.song = songs.Take(numberOfSongsToPick).ToArray();

            // start get artists by search term
            var query3 = new InternalItemsQuery(user);
            query3.SearchTerm = req.query;
            query3.IncludeItemTypes = new[] { typeof(MediaBrowser.Controller.Entities.Audio.MusicArtist).Name };
            query3.Recursive = true;

            List<MusicArtist> itemsResult3;

            itemsResult3 = _libraryManager.GetArtists(query3).Items.Cast<MusicArtist>().ToList();

            JsonResponse r3 = new JsonResponse();
            var options3 = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var artist = new ArtistID3();
            var artistList = new List<ArtistID3>();
            int numberOfArtistsToPick = req.artistCount ?? 20;

            foreach (MusicArtist item in itemsResult3)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))
                artist.id = item.InternalId.ToString();
                artist.name = item.Name.ToString();
                artist.albumCount = item.Album.Length;
                artist.starredSpecified = item.IsFavorite;
                // artist.coverArt = item.ImageDisplayParentId != null ? item.ImageDisplayParentId.ToString() : null;
                // artist.artistImageUrl
                artistList.Add(artist);
            }
            // end get artists by search term

            search3.artist = artistList.Take(numberOfArtistsToPick).ToArray();

            r.root["status"] = "ok";
            r.root["searchResult3"] = search3;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(SearchingSearch2 req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var search3 = new SearchResult3();

            // start get albums by search term
            var query = new InternalItemsQuery(user);
            query.SearchTerm = req.query;
            query.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            query.Recursive = true;

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            var album = new AlbumID3();
            var albumList = new List<AlbumID3>();

            int numberOfAlbumsToPick = req.albumCount ?? 20;

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
                albumList.Add(album);
            }
            // end get albums by search term

            search3.album = albumList.Take(numberOfAlbumsToPick).ToArray();

            // start get songs by search term
            var query2 = new InternalItemsQuery(user);
            //query2.SearchTerm = req.query;
            query2.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            query2.Recursive = true;

            List<MusicAlbum> itemsResult2;

            itemsResult2 = _libraryManager.GetMusicAlbums(query2).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r2 = new JsonResponse();
            var options2 = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            var album2 = new AlbumID3();
            var songs = new List<Child>();
            var songList = new Songs();
            int numberOfSongsToPick = req.songCount ?? 20;

            foreach (MusicAlbum item in itemsResult)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))

                foreach (var song in item.GetRecursiveChildren().OfType<Audio>())
                {
                    if (song.Name.Contains(req.query, StringComparison.OrdinalIgnoreCase))
                    {
                        var child = new Child
                        {
                            artist = song.Artists != null && song.Artists.Length > 0 ? song.Artists[0] : item.AlbumArtist,
                            id = song.InternalId.ToString(),
                            parent = item.InternalId.ToString(),
                            title = song.Name,
                            album = item.Name,
                            duration = (int)(song.RunTimeTicks / TimeSpan.TicksPerSecond),
                            track = song.IndexNumber ?? 0,
                            year = item.ProductionYear ?? 0
                        };
                        songs.Add(child);
                    }
                }
            }
            // end get songs by search term

            search3.song = songs.Take(numberOfSongsToPick).ToArray();

            // start get artists by search term
            var query3 = new InternalItemsQuery(user);
            query3.SearchTerm = req.query;
            query3.IncludeItemTypes = new[] { typeof(MediaBrowser.Controller.Entities.Audio.MusicArtist).Name };
            query3.Recursive = true;

            List<MusicArtist> itemsResult3;

            itemsResult3 = _libraryManager.GetArtists(query3).Items.Cast<MusicArtist>().ToList();

            JsonResponse r3 = new JsonResponse();
            var options3 = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var artist = new ArtistID3();
            var artistList = new List<ArtistID3>();
            int numberOfArtistsToPick = req.artistCount ?? 20;

            foreach (MusicArtist item in itemsResult3)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))
                artist.id = item.InternalId.ToString();
                artist.name = item.Name.ToString();
                artist.albumCount = item.Album.Length;
                artist.starredSpecified = item.IsFavorite;
                // artist.coverArt = item.ImageDisplayParentId != null ? item.ImageDisplayParentId.ToString() : null;
                // artist.artistImageUrl
                artistList.Add(artist);
            }
            // end get artists by search term

            search3.artist = artistList.Take(numberOfArtistsToPick).ToArray();

            r.root["status"] = "ok";
            r.root["searchResult3"] = search3;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(SearchingSearch req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var search = new SearchResult();

            // start get albums by search term
            var query = new InternalItemsQuery(user);
            query.SearchTerm = req.album;
            query.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            query.Recursive = false;

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            var child = new Child();
            var matchList = new List<Child>();
            int numberOfMatchesToPick = req.count ?? 20;

            foreach (MusicAlbum item in itemsResult)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))

                child.id = item.InternalId.ToString();
                child.parent = item.ParentId.ToString();
                child.title = item.Name.ToString();
                child.artist = item.AlbumArtist;
                child.album = item.Name.ToString();
                child.duration = (int)(item.RunTimeTicks / TimeSpan.TicksPerSecond);
                child.year = item.ProductionYear ?? 0;
                matchList.Add(child);
            }

            // end get albums by search term

            // start get songs by search term
            var query2 = new InternalItemsQuery(user);
            //query2.SearchTerm = req.query;
            query2.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            query2.Recursive = true;

            List<MusicAlbum> itemsResult2;

            itemsResult2 = _libraryManager.GetMusicAlbums(query2).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r2 = new JsonResponse();
            var options2 = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            foreach (MusicAlbum item in itemsResult)
            {
                //if (item.AlbumId.ToString().Equals(req.albumId.ToString()))

                foreach (var song in item.GetRecursiveChildren().OfType<Audio>())
                {
                    if (song.Name.Contains(req.title, StringComparison.OrdinalIgnoreCase))
                    {
                        var child2 = new Child
                        {
                            artist = song.Artists != null && song.Artists.Length > 0 ? song.Artists[0] : item.AlbumArtist,
                            id = song.InternalId.ToString(),
                            parent = item.InternalId.ToString(),
                            title = song.Name,
                            album = item.Name,
                            duration = (int)(song.RunTimeTicks / TimeSpan.TicksPerSecond),
                            track = song.IndexNumber ?? 0,
                            year = item.ProductionYear ?? 0
                        };
                        matchList.Add(child2);
                    }
                }
            }
            // end get songs by search term

            // start get artists by search term
            var query3 = new InternalItemsQuery(user);
            query3.SearchTerm = req.artist;
            query3.IncludeItemTypes = new[] { typeof(MediaBrowser.Controller.Entities.Audio.MusicArtist).Name };
            query3.Recursive = false;

            List<MusicArtist> itemsResult3;

            itemsResult3 = _libraryManager.GetArtists(query3).Items.Cast<MusicArtist>().ToList();

            JsonResponse r3 = new JsonResponse();
            var options3 = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            foreach (MusicArtist item in itemsResult3)
            {
                if (item.Name.Contains(req.artist, StringComparison.OrdinalIgnoreCase))
                {
                    var child3 = new Child
                    {
                        id = item.InternalId.ToString(),
                        title = item.Name,
                        artist = item.Name
                    };
                    matchList.Add(child3);
                }
            }
            // end get artists by search term

            search.match = matchList.Take(numberOfMatchesToPick).ToArray();
            
            r.root["status"] = "ok";
            r.root["searchResult"] = search;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        } 
    }
}
