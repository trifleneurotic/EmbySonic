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

namespace EmbySub.Api
{
    [Route("/rest/getAlbumList", "GET")]
    public class ListAlbum : SystemBase
    {
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(ListAlbum req)
        {
          HttpResponseMessage hrm;
          hrm = await Login(req);
          var subReq = new EmbySub.Response();
          string xmlString;
          String hrmraw;

          // if login is NOT successful return an error....
          if (!hrm.IsSuccessStatusCode)
          {
            subReq.ItemElementName = EmbySub.ItemChoiceType.error;
            EmbySub.Error e = new EmbySub.Error();
            e.code = 0;
            e.message = "Login failed";
            subReq.Item = e;
            subReq.version = SupportedSubsonicApiVersion;
            xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
            return ResultFactory.GetResult(Request, xmlString, null);
          }
          // otherwise it was successful so grab & store the auth token
          else
          {
            hrmraw = await hrm.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(hrmraw);
            JsonElement u = doc.RootElement.GetProperty("User");
            c.DefaultRequestHeaders.Add("Accept", "application/json");
            c.DefaultRequestHeaders.Add("X-Emby-Token", u.GetProperty("AccesssToken").ToString());
          }

          // we need the unique ID for the desired music library set in the plugin configuration
          String url = String.Format("http://localhost:{0}/emby/Items?IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
          HttpResponseMessage mes = await c.GetAsync(url);
          String raw = await mes.Content.ReadAsStringAsync();
          JsonDocument j = JsonDocument.Parse(raw);
          JsonElement allLibs = j.RootElement.GetProperty("Items");
          String s;
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
            subReq.ItemElementName = EmbySub.ItemChoiceType.error;
            EmbySub.Error e = new EmbySub.Error();
            e.code = 0;
            e.message = "Music library does not exist";
            subReq.Item = e;
            subReq.version = SupportedSubsonicApiVersion;
            xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
            return ResultFactory.GetResult(Request, xmlString, null);
          }

          // library exists so let's get all the artists that have albums first
          url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort, musicLibId);
          mes = await c.GetAsync(url);
          raw = await mes.Content.ReadAsStringAsync();
          j = JsonDocument.Parse(raw);

          JsonElement allArtists = j.RootElement.GetProperty("Items");
          subReq.ItemElementName = EmbySub.ItemChoiceType.albumList;
          List<EmbySub.Child> albums = new List<EmbySub.Child>();

          // now for each artist let's get a list of their albums....
          foreach (JsonElement artist in allArtists.EnumerateArray())
          {
            String artistId = artist.GetProperty("Id").ToString();
            url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&IncludeItemTypes=Folder&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort, artistId);
            hrm = await c.GetAsync(url);
            hrmraw = await hrm.Content.ReadAsStringAsync();
            JsonDocument k = JsonDocument.Parse(hrmraw);

            JsonElement allAlbumsOfArtist = k.RootElement.GetProperty("Items");

            // ....and then add each album to our list
            foreach (JsonElement album in allAlbumsOfArtist.EnumerateArray())
            {
              EmbySub.Child ch = new EmbySub.Child();
              ch.isDir = album.GetProperty("IsFolder").GetBoolean();
              ch.id = album.GetProperty("Id").ToString();
              ch.parent = artistId;
              ch.title = album.GetProperty("Name").ToString();
              ch.coverArt = album.GetProperty("ImageTags").GetProperty("Primary").ToString();
              albums.Add(ch);
            }
          }


          // lastly let's convert the above list and add to our Subsonic XML to return
          EmbySub.AlbumList al = new EmbySub.AlbumList();
          al.album = albums.ToArray();
          subReq.Item = al;
          subReq.version = SupportedSubsonicApiVersion;
          xmlString = Serializer<EmbySub.Response>.Serialize(subReq);

          url = String.Format("http://localhost:{0}/emby/Sessions/Logout", Plugin.Instance.Configuration.LocalEmbyPort);
          await c.PostAsync(url, null);
          return ResultFactory.GetResult(Request, xmlString, null);
        }
    }
}