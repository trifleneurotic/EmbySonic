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
    [Route("/rest/getRandomSongs", "GET", Summary = "Returns random songs matching the given criteria.", Description = "Returns random songs matching the given criteria.")]
    public class ListsGetRandomSongs : SystemBase
    {
        [ApiMember(Name = "Size", Description = "The maximum number of songs to return. Max 500.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? size { get; set; }

        [ApiMember(Name = "From Year", Description = "Only return songs published after or in this year.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? fromYear { get; set; }

        [ApiMember(Name = "To Year", Description = "Only return songs published before or in this year.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? toYear { get; set; }

        [ApiMember(Name = "Genre", Description = "Only return songs belonging to this genre.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "Only return songs in the music folder with the given ID. See getMusicFolders.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    [Route("/rest/getAlbumList", "GET", Summary = "Returns a list of random, newest, highest rated etc. albums.", Description = "Returns a list of random, newest, highest rated etc. albums. Similar to the album lists on the home page of the Subsonic web interface.")]
    public class ListsGetAlbumList : SystemBase
    {
        [ApiMember(Name = "Album ID", Description = "The list type.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? type { get; set; }

        [ApiMember(Name = "Size", Description = "The number of albums to return. Max 500.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? size { get; set; }

        [ApiMember(Name = "Offset", Description = "The list offset. Useful if you for example want to page through the list of newest albums.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? offset { get; set; }

        [ApiMember(Name = "From Year", Description = "The first year in the range. If fromYear > toYear a reverse chronological list is returned.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? fromYear { get; set; }

        [ApiMember(Name = "To Year", Description = "The last year in the range.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? toYear { get; set; }

        [ApiMember(Name = "Genre", Description = "The name of the genre, e.g., \"Rock\".", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.11.0) Only return albums in the music folder with the given ID. See getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

    [Route("/rest/getAlbumList2", "GET", Summary = "Returns a list of random, newest, highest rated etc. albums.", Description = "Similar to getAlbumList, but organizes music according to ID3 tags.")]
    public class ListsGetAlbumList2 : SystemBase
    {
        [ApiMember(Name = "Album ID", Description = "The list type.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? type { get; set; }

        [ApiMember(Name = "Size", Description = "The number of albums to return. Max 500.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? size { get; set; }

        [ApiMember(Name = "Offset", Description = "The list offset. Useful if you for example want to page through the list of newest albums.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? offset { get; set; }

        [ApiMember(Name = "From Year", Description = "The first year in the range. If fromYear > toYear a reverse chronological list is returned.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? fromYear { get; set; }

        [ApiMember(Name = "To Year", Description = "The last year in the range.", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
        public int? toYear { get; set; }

        [ApiMember(Name = "Genre", Description = "The name of the genre, e.g., \"Rock\".", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? genre { get; set; }

        [ApiMember(Name = "Music Folder ID", Description = "(Since 1.11.0) Only return albums in the music folder with the given ID. See getMusicFolders", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? musicFolderId { get; set; }
    }

   
    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(ListsGetRandomSongs req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var query = new InternalItemsQuery(user);

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Cast<MusicAlbum>().ToList();

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var album = new AlbumWithSongsID3();
            var songList = new List<Child>();
            int numberOfElementsToPick = req.size ?? 10;
            var randomSongs = new RandomSongs();

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
            }

            songList.Shuffle();
             Random random = new Random();

            // Shuffle the list and take the first 'numberOfElementsToPick' elements
            List<Child> uniqueRandomElements = songList
                .OrderBy(x => random.Next()) // Order by a random value to shuffle
                .Take(numberOfElementsToPick)
                .ToList();
            
            randomSongs.song = uniqueRandomElements.ToArray();
            r.root["randomSongs"] = randomSongs;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        // begin Lists methods
        public async Task<object> Get(ListsGetAlbumList req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var albumList = new List<AlbumID3>();
            var al = new AlbumListID3();
            var query = new InternalItemsQuery(user);
            //query.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            //query.Recursive = true;
            if (req.type == "newest")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.DateCreated, SortOrder.Descending) };
            }
            else if (req.type == "random")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.Random, SortOrder.Ascending) };
            }
            else if (req.type == "highest")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.CommunityRating, SortOrder.Descending) };
            }
            else if (req.type == "frequent")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.PlayCount, SortOrder.Descending) };
            }
            else if (req.type == "recent")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.DatePlayed, SortOrder.Descending) };
            }
            else
            {
                // default to newest
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.DateCreated, SortOrder.Descending) };
            }

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Take(req.size == null ? 10 : req.size.Value).Select(i => i.Item1).AsQueryable().Cast<MusicAlbum>().ToList();

            // Apply additional filters based on the request parameters
            if (req.fromYear.HasValue)
            {
                itemsResult = itemsResult.Where(i => i.ProductionYear >= req.fromYear.Value).ToList();
            }
            if (req.toYear.HasValue)
            {
                itemsResult = itemsResult.Where(i => i.ProductionYear <= req.toYear.Value).ToList();
            }
            if (!string.IsNullOrEmpty(req.genre))
            {
                itemsResult = itemsResult.Where(i => i.Genres.Contains(req.genre)).ToList();
            }
            if (!string.IsNullOrEmpty(req.musicFolderId))
            {
                itemsResult = itemsResult.Where(i => i.ParentId.ToString() == req.musicFolderId).ToList();
            }

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var album = new AlbumID3();

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
                album.genre = item.Genres[0].ToString();
                albumList.Add(album);
            }

            al.album = albumList.ToArray();

            r.root["albumList"] = al;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        
        public async Task<object> Get(ListsGetAlbumList2 req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");
            // 112457

            var albumList = new List<AlbumID3>();
            var al = new AlbumListID3();
            var query = new InternalItemsQuery(user);
            //query.IncludeItemTypes = new[] { typeof(MusicAlbum).Name };
            //query.Recursive = true;
            if (req.type == "newest")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.DateCreated, SortOrder.Descending) };
            }
            else if (req.type == "random")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.Random, SortOrder.Ascending) };
            }
            else if (req.type == "highest")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.CommunityRating, SortOrder.Descending) };
            }
            else if (req.type == "frequent")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.PlayCount, SortOrder.Descending) };
            }
            else if (req.type == "recent")
            {
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.DatePlayed, SortOrder.Descending) };
            }
            else
            {
                // default to newest
                query.OrderBy = new[] { new ValueTuple<string, SortOrder>(ItemSortBy.DateCreated, SortOrder.Descending) };
            }

            List<MusicAlbum> itemsResult;

            itemsResult = _libraryManager.GetMusicAlbums(query).Items.Take(req.size == null ? 10 : req.size.Value).Select(i => i.Item1).AsQueryable().Cast<MusicAlbum>().ToList();

            // Apply additional filters based on the request parameters
            if (req.fromYear.HasValue)
            {
                itemsResult = itemsResult.Where(i => i.ProductionYear >= req.fromYear.Value).ToList();
            }
            if (req.toYear.HasValue)
            {
                itemsResult = itemsResult.Where(i => i.ProductionYear <= req.toYear.Value).ToList();
            }
            if (!string.IsNullOrEmpty(req.genre))
            {
                itemsResult = itemsResult.Where(i => i.Genres.Contains(req.genre)).ToList();
            }
            if (!string.IsNullOrEmpty(req.musicFolderId))
            {
                itemsResult = itemsResult.Where(i => i.ParentId.ToString() == req.musicFolderId).ToList();
            }            

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            var album = new AlbumID3();

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
                album.genre = item.Genres[0].ToString();
                albumList.Add(album);
            }

            al.album = albumList.ToArray();

            r.root["albumList"] = al;
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
        // end Lists methods
    }
}
