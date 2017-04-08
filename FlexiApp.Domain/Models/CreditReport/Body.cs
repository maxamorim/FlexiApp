using System;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "ProcessRequestXMLResponse", Namespace = "https://tu.tuconline.com/TUOnlineServices/")]
        public ProcessRequestXMLResponse ProcessRequestXMLResponse { get; set; }
    }
}
