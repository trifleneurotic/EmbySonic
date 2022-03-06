using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace EmbySub
{
  public class SubsonicXmlTextWriter : XmlTextWriter
{
    public SubsonicXmlTextWriter(Utf8StringWriter u) : base(u)
    {

    }

    public override void WriteEndElement()
    {
        base.WriteFullEndElement();
    }
}
  public class Utf8StringWriter : StringWriter
{
	public override Encoding Encoding
	{
		get { return Encoding.UTF8; }
	}
}
  public class Serializer<T> where T : class
  {
    public static string Serialize(T obj)
    {
      XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
      using (var sww = new Utf8StringWriter())
      {
        using (SubsonicXmlTextWriter writer = new SubsonicXmlTextWriter(sww) { Formatting = Formatting.Indented })
        {
            xsSubmit.Serialize(writer, obj);
            return sww.ToString();
        }
      }
    }
  }
}
