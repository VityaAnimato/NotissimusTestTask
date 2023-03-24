using System.Xml.Serialization;
using System.Collections.Generic;
namespace NotissimusTestTask.Models
{
    [XmlRoot(ElementName = "categories")]
	public class Categories
	{
		[XmlElement(ElementName = "category")]
		public List<Category> Category { get; set; }
	}
}
