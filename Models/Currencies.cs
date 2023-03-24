using System.Xml.Serialization;
namespace NotissimusTestTask.Models
{
    [XmlRoot(ElementName = "currencies")]
	public class Currencies
	{
		[XmlElement(ElementName = "currency")]
		public Currency Currency { get; set; }
	}
}
