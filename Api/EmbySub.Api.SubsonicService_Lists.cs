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
          await Login(req);

          String url = String.Format("http://localhost:{0}/emby/Items?api_key=4cee3dd9684a48fc99d32f84bfc7b8e2&ParentId=7843888&IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
          HttpResponseMessage mes = await c.GetAsync(url);
          String raw = await mes.Content.ReadAsStringAsync();
          JsonDocument j = JsonDocument.Parse(raw);

          HttpResponseMessage hrm;
          String hrmraw;
          JsonElement allArtists = j.RootElement.GetProperty("Items");
          var subReq = new EmbySub.Response();

          subReq.ItemElementName = EmbySub.ItemChoiceType.albumList;

          List<EmbySub.Child> albums = new List<EmbySub.Child>();

          foreach (JsonElement artist in allArtists.EnumerateArray())
          {
            String artistId = artist.GetProperty("Id").ToString();
            url = String.Format("http://localhost:{0}/emby/Items?api_key=4cee3dd9684a48fc99d32f84bfc7b8e2&ParentId={1}&IncludeItemTypes=Folder&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort, artistId);
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
          string xmlString = Serializer<EmbySub.Response>.Serialize(subReq);
          return ResultFactory.GetResult(Request, xmlString, null);
        }
    }
}
