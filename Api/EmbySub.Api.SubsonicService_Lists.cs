using MediaBrowser.Common.Configuration;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.MediaEncoding;
using MediaBrowser.Controller.Net;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Session;
using MediaBrowser.Model.Services;
using MediaBrowser.Model.Users;
using MediaBrowser.Model.IO;
using MediaBrowser.Model;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using EmbySub.Configuration;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EmbySub.Api
{
    [Route("/rest/getAlbumList", "GET", Description = "Gets all albums for all artists")]
    public class ListAlbum : SystemBase
    {
      [ApiMember(Name = "Size", Description = "Number of items to return", IsRequired = false, DataType = "int", ParameterType = "query", Verb = "GET")]
      public int size { get; set; }

      [ApiMember(Name = "Type", Description = "Type of list to return", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
      public String type { get; set; }
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

            // we need the unique ID for the desired music library set in the plugin configuration
            url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
            HttpResponseMessage mes = await c.GetAsync(url);
            hrmraw = await mes.Content.ReadAsStringAsync();
            JsonDocument j = JsonDocument.Parse(hrmraw);
            JsonElement allLibs = j.RootElement.GetProperty("Items");
            String musicLibId = String.Empty;

            foreach (JsonElement lib in allLibs.EnumerateArray())
            {
              s = lib.GetProperty("Name").ToString();
              if(String.Equals(s, Plugin.Instance.Configuration.MusicLibraryName))
              {
                musicLibId = lib.GetProperty("Id").ToString();
                break;
              }
            }
          

          // music library does not exist under configured name
          if (String.IsNullOrEmpty(musicLibId))
          {
            if (String.IsNullOrEmpty(req.f))
            {
              EmbySub.Response r = new EmbySub.Response();
              EmbySub.Error e = new EmbySub.Error();
              e.code = 0;
              e.message = "Music library does not exist";
              r.Item = e;
              r.ItemElementName = EmbySub.ItemChoiceType.error;
              str = Serializer<EmbySub.Response>.Serialize(r);
              contentType = "text/xml";
              return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }
            else if (req.f.Equals("json"))
            {
              EmbySub.JsonResponse r = new EmbySub.JsonResponse();
              var e = new EmbySub.Error();
              e.code = 0;
              e.message = "Music library does not exist";
              var options = new JsonSerializerOptions
              {
                  IgnoreNullValues = true,
                  WriteIndented = true
              };
              r.root["error"] = e;
              r.root["_status"] = "ok";
              str = JsonSerializer.Serialize(r, options);
              contentType = "text/json";
              return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
            }
          }

          // library exists so let's get all the artists that have albums first
          url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId);
          mes = await c.GetAsync(url);
          hrmraw = await mes.Content.ReadAsStringAsync();
          j = JsonDocument.Parse(hrmraw);

          JsonElement allArtists = j.RootElement.GetProperty("Items");

          StringBuilder sb = new StringBuilder();

          // now let's get each artist ID into an exclusion list because....
          foreach (JsonElement artist in allArtists.EnumerateArray())
          {
            sb.AppendFormat("{0},", artist.GetProperty("Id").ToString());
          }

          String sz = Convert.ToString(req.size  == 0 ? 10 : req.size);
          String ty = GetEmbyListType(req.type);

          // ....we want to exclude artist-only records in our hierarchical library....
          url = String.Format("http://localhost:{0}/emby/Items?Recursive=true&ParentId={1}&IncludeItemTypes=Folder&ExcludeItemTypes=Audio&ExcludeItemIds={2}&SortBy={3}&Limit={4}&Fields=ParentId", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId, sb.ToString(), ty, sz);
          hrm = await c.GetAsync(url);
          hrmraw = await hrm.Content.ReadAsStringAsync();
          JsonDocument k = JsonDocument.Parse(hrmraw);

          JsonElement returnedAlbums = k.RootElement.GetProperty("Items");
          List<EmbySub.Child> albums;
          AddAlbumsToList(returnedAlbums, req, out albums);
          EmbySub.AlbumList al = new EmbySub.AlbumList();

          if (string.IsNullOrEmpty(req.f))
          {
            EmbySub.Response r = new EmbySub.Response();
            contentType = "text/xml";
            r.ItemElementName = EmbySub.ItemChoiceType.albumList;
            al.album = albums.ToArray();
            r.Item = al;
            r.version = SupportedSubsonicApiVersion;
            str = Serializer<EmbySub.Response>.Serialize(r);
          }
          else if (req.f.Equals("json"))
          {
            EmbySub.JsonResponse r = new EmbySub.JsonResponse();
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
          url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
           await c.PostAsync(url, null);
           return ResultFactory.GetResult(Request, Encoding.UTF8.GetBytes(str), contentType, null);
        }

         private static void AddAlbumsToList(JsonElement ra, ListAlbum r, out List<EmbySub.Child> l)
        {
          l = new List<EmbySub.Child>();
          foreach (JsonElement album in ra.EnumerateArray())
            {
              EmbySub.Child ch = new EmbySub.Child();
              ch.id = album.GetProperty("Id").ToString();
              ch.parent = album.GetProperty("ParentId").ToString();
              ch.title = album.GetProperty("Name").ToString();
              ch.coverArt = album.GetProperty("ImageTags").GetProperty("Primary").ToString();
              l.Add(ch);
            }
        }
    }
}