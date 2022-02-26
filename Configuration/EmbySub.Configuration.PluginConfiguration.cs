using MediaBrowser.Model.Plugins;

namespace EmbySub.Configuration
{
    /// <summary>
    /// Class PluginConfiguration
    /// </summary>
    public class PluginConfiguration : BasePluginConfiguration
    {
      public int LocalEmbyPort { get; set; }
    }
}
