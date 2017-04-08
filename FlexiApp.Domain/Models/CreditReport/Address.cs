using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Address", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Address
    {
        [XmlElement(ElementName = "Street", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Street { get; set; }
        [XmlElement(ElementName = "City", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string City { get; set; }
        [XmlElement(ElementName = "Prov", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Prov { get; set; }
        [XmlElement(ElementName = "Postal", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Postal { get; set; }
        [XmlElement(ElementName = "DateReported", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string DateReported { get; set; }
        [XmlAttribute(AttributeName = "AddrType")]
        public string AddrType { get; set; }
    }
}
