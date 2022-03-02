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
          else
          {
            // extract token for c
            // add token header along with json accept to c
          }

          String url = String.Format("http://localhost:{0}/emby/Items?ParentId=7843888&IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
          HttpResponseMessage mes = await c.GetAsync(url);
          String raw = await mes.Content.ReadAsStringAsync();
          JsonDocument j = JsonDocument.Parse(raw);

          String hrmraw;
          JsonElement allArtists = j.RootElement.GetProperty("Items");

          subReq.ItemElementName = EmbySub.ItemChoiceType.albumList;

          List<EmbySub.Child> albums = new List<EmbySub.Child>();

          foreach (JsonElement artist in allArtists.EnumerateArray())
          {
            String artistId = artist.GetProperty("Id").ToString();
            url = String.Format("http://localhost:{0}/emby/Items?ParentId={1}&IncludeItemTypes=Folder&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort, artistId);
            hrm = await c.GetAsync(url);
            hrmraw = await hrm.Content.ReadAsStringAsync();
            JsonDocument k = JsonDocument.Parse(hrmraw);

            JsonElement allAlbumsOfArtist = k.RootElement.GetProperty("Items");

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

          EmbySub.AlbumList al = new EmbySub.AlbumList();
          al.album = albums.ToArray();
          subReq.Item = al;
          subReq.version = SupportedSubsonicApiVersion;
          xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
          // logout with token
          return ResultFactory.GetResult(Request, xmlString, null);
        }
    }
}
