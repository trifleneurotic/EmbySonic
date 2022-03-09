using System.Text.Json.Serialization;

namespace EmbySub
{

    public partial class JsonResponse : Response
    {

        [JsonPropertyName("subsonic-response")]
        public Dictionary<string, object> root { get; set; } = new Dictionary<string, object>()
        {
            {"_xmlns", "http://subsonic.org/restapi"},
            {"_version", "1.16.1"}
        };
    }
}