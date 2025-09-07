using MediaBrowser.Model.Plugins;

namespace EmbySonic2.Configuration
{
    /// <summary>
    /// Class PluginConfiguration
    /// </summary>
    public class PluginConfiguration : BasePluginConfiguration
    {
        public PluginConfiguration()
        {
            ApiKey = "none";
        }

        public string ApiKey { get; set; }
    }
}
