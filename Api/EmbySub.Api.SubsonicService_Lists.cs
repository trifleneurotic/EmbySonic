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
    public class ListAlbum : IReturn<EmbySub.Response>
    {
        [ApiMember(Name = "u", Description = "Username of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? Username { get; set; }

        [ApiMember(Name = "p", Description = "Password of Emby user", IsRequired = true, DataType = "string", ParameterType = "query", Verb = "GET")]
        public string? Password { get; set; }
    }

    public partial class SubsonicService : IService, IRequiresRequest
    {
        public async Task<object> Get(ListAlbum req)
        {
          HttpClientHandler clientHandler = new HttpClientHandler();
          clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
          HttpClient client = new HttpClient(clientHandler);

          var payload = String.Format("Username={0}\nPw={1}", req.Username, req.Password);
          StringContent body = new StringContent(payload);
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Add("Accept", "application/json");
          client.DefaultRequestHeaders.Add("X-Emby-Authorization", "MediaBrowser Client=\"SubsonicClient\", Device=\"SubsonicDevice\", DeviceId=\"0192742\", Version=\"0.0.1.7\"");

          String url = String.Format("http://localhost:{0}/emby/Users/AuthenticateByName", Plugin.Instance.Configuration.LocalEmbyPort);

          HttpResponseMessage result = await client.PostAsync(url, body);

          url = String.Format("http://localhost:{0}/emby/Items?api_key=4cee3dd9684a48fc99d32f84bfc7b8e2&ParentId=7843888&IncludeItemTypes=Album&ExcludeItemTypes=Audio", Plugin.Instance.Configuration.LocalEmbyPort);
          HttpResponseMessage mes = await client.GetAsync(url);
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
            hrm = await client.GetAsync(url);
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
