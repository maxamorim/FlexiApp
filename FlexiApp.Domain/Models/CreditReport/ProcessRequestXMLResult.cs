using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "ProcessRequestXMLResult", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class ProcessRequestXMLResult
    {
        [XmlElement(ElementName = "UserReference", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string UserReference { get; set; }
        [XmlElement(ElementName = "MemberCode", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MemberCode { get; set; }
        [XmlElement(ElementName = "Date", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Time", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Time { get; set; }
        [XmlElement(ElementName = "Product", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Product { get; set; }
        [XmlElement(ElementName = "TU_FFR_Report", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public TU_FFR_Report TU_FFR_Report { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
