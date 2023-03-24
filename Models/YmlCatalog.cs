using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace NotissimusTestTask.Models
{
    [XmlRoot(ElementName = "yml_catalog")]
	public class YmlCatalog
	{
		[XmlElement(ElementName = "shop")]
		public Shop Shop { get; set; }
		[XmlAttribute(AttributeName = "date")]
		public string Date { get; set; }

		public static async Task<YmlCatalog> GetTestDataAsync()
        {
            var wabRequest = WebRequest.Create(@"http://partner.market.yandex.ru/pages/help/YML.xml");
            using (var response = await wabRequest.GetResponseAsync())
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("windows-1251")))
                {
                    var serializer = new XmlSerializer(typeof(YmlCatalog));
                    return (YmlCatalog)serializer.Deserialize(reader);
                }
            }
        }
	}

}
