using System.Text.Json.Serialization;

namespace EmbySonic2
{

    public partial class JsonResponse : Response
    {

        [JsonPropertyName("subsonic-response")]
        public Dictionary<string, object> root { get; set; } = new Dictionary<string, object>()
        {
            {"version", "1.16.1"}
        };
    }
}