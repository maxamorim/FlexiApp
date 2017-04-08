using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{

    [XmlRoot(ElementName = "Message", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Message
    {
        [XmlElement(ElementName = "Code", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Code { get; set; }
    }

}
