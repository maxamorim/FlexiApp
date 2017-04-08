using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "ProcessRequestXMLResponse", Namespace = "https://tu.tuconline.com/TUOnlineServices/")]
    public class ProcessRequestXMLResponse
    {
        [XmlElement(ElementName = "ProcessRequestXMLResult", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public ProcessRequestXMLResult ProcessRequestXMLResult { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
