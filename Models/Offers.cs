using System.Xml.Serialization;
using System.Collections.Generic;
namespace NotissimusTestTask.Models
{
    [XmlRoot(ElementName = "offers")]
	public class Offers
	{
		[XmlElement(ElementName = "offer")]
		public List<Offer> Offer { get; set; }
	}
}
