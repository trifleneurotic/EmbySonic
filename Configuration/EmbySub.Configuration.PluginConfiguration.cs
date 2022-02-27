using MediaBrowser.Model.Plugins;

namespace EmbySub.Configuration
{
    /// <summary>
    /// Class PluginConfiguration
    /// </summary>
    public class PluginConfiguration : BasePluginConfiguration
    {
      public PluginConfiguration()
      {
        LocalEmbyPort = 8096;
      }

      public int LocalEmbyPort { get; set; }
    }
}
