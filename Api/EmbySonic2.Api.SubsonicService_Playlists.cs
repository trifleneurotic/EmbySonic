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
using MediaBrowser.Controller.Playlists;
using MediaBrowser.Controller.Session;
using System.Xml.Linq;


namespace EmbySonic2.Api
{
    [Route("/rest/createPlaylist", "GET", Summary = "Creates a new playlist.", Description = "Creates a new playlist for the authenticated user.")]
    public class PlaylistsCreatePlaylist : SystemBase
    {
        [ApiMember(Name = "name", Description = "The playlist name.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? name { get; set; }

        [ApiMember(Name = "songId", Description = "Comma-separated list of song ids to add to the playlist.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? songId { get; set; }

        [ApiMember(Name = "comment", Description = "The playlist comment.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? comment { get; set; }
    }

    [Route("/rest/updatePlaylist", "GET", Summary = "Updates a playlist.", Description = "Updates a playlist for the authenticated user.")]
    public class PlaylistsUpdatePlaylist : SystemBase
    {
        [ApiMember(Name = "playlistId", Description = "The playlist ID.", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? playlistId { get; set; }

        [ApiMember(Name = "name", Description = "The new playlist name.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? name { get; set; }

        [ApiMember(Name = "comment", Description = "The playlist comment.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? comment { get; set; }

        [ApiMember(Name = "public", Description = "Whether the playlist is public.", IsRequired = false, DataType = "bool", ParameterType = "query", Verb = "GET")]
        public bool? @public { get; set; }

        [ApiMember(Name = "songIdToAdd", Description = "Song IDs to add to the playlist.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? songIdToAdd { get; set; }

        [ApiMember(Name = "songIndexToRemove", Description = "Song indices to remove from the playlist.", IsRequired = false, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? songIndexToRemove { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
    
        public async Task<object> Get(PlaylistsCreatePlaylist req)
        {
            string contentType = string.Empty;
            string str = string.Empty;

            // TODO: Replace with actual user context
            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            if (string.IsNullOrEmpty(req.name))
            {
                JsonResponse errorResponse = new JsonResponse();
                errorResponse.root["status"] = "failed";
                errorResponse.root["error"] = new { code = 10, message = "Missing playlist name" };
                contentType = "text/json";
                str = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true });
                return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }

            // Create the playlist using Emby library classes
            var createRequest = new MediaBrowser.Controller.Playlists.CreatePlaylistRequest
            {
                Name = req.name,
                UserId = user.Id,
                Overview = req.comment
            };

            var result = await _playlistManager.CreatePlaylist(createRequest);
            var playlist = result.Playlist;

            if (playlist == null)
            {
                JsonResponse errorResponse = new JsonResponse();
                errorResponse.root["status"] = "failed";
                errorResponse.root["error"] = new { code = 70, message = "Playlist creation failed" };
                contentType = "text/json";
                str = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true });
                return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }

            // Add songs to the playlist if provided
            if (!string.IsNullOrEmpty(req.songId))
            {
                var songIds = req.songId.Split(',').Select(id => long.Parse(id)).ToArray();
                await _playlistManager.AddToPlaylist(playlist, songIds, false, user, System.Threading.CancellationToken.None);
            }

            // Prepare Subsonic-compatible response
            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            r.root["playlistId"] = playlist.Id.ToString();
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

        public async Task<object> Get(PlaylistsUpdatePlaylist req)
        {
            String contentType = String.Empty;
            String str = String.Empty;

            // TODO: Replace with actual user context
            var user = _userManager.GetUserById("b46ed6e64a1343599b2352273982a86b");

            if (string.IsNullOrEmpty(req.playlistId))
            {
                JsonResponse errorResponse = new JsonResponse();
                errorResponse.root["status"] = "failed";
                errorResponse.root["error"] = new { code = 10, message = "Missing playlistId" };
                contentType = "text/json";
                str = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true });
                return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }

            var playlist = await _playlistManager.GetPlaylistById(long.Parse(req.playlistId));
            if (playlist == null)
            {
                JsonResponse errorResponse = new JsonResponse();
                errorResponse.root["status"] = "failed";
                errorResponse.root["error"] = new { code = 70, message = "Playlist not found" };
                contentType = "text/json";
                str = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true });
                return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }

            bool updated = false;
            if (!string.IsNullOrEmpty(req.name) && req.name != playlist.Name)
            {
                playlist.Name = req.name;
                updated = true;
            }
            if (!string.IsNullOrEmpty(req.comment) && req.comment != playlist.Overview)
            {
                playlist.Overview = req.comment;
                updated = true;
            }
            if (req.@public.HasValue)
            {
                playlist.IsPublic = req.@public.Value;
                updated = true;
            }
            if (updated)
            {
                await _playlistManager.UpdatePlaylist(playlist);
            }

            // Add songs
            if (!string.IsNullOrEmpty(req.songIdToAdd))
            {
                var songIds = req.songIdToAdd.Split(',').Select(id => long.Parse(id)).ToArray();
                await _playlistManager.AddToPlaylist(playlist, songIds, false, user, System.Threading.CancellationToken.None);
            }

            // Remove songs by index
            if (!string.IsNullOrEmpty(req.songIndexToRemove))
            {
                var indices = req.songIndexToRemove.Split(',').Select(i => int.Parse(i)).OrderByDescending(i => i).ToArray();
                var items = playlist.GetPlaylistItems().ToList();
                foreach (var idx in indices)
                {
                    if (idx >= 0 && idx < items.Count)
                    {
                        await _playlistManager.RemoveFromPlaylist(playlist, new[] { items[idx].Id }, user, System.Threading.CancellationToken.None);
                    }
                }
            }

            JsonResponse r = new JsonResponse();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            r.root["status"] = "ok";
            contentType = "text/json";
            str = JsonSerializer.Serialize(r, options);
            return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }
    }
}
