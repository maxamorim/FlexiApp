using System;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Inquiry", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Inquiry
    {
        [XmlElement(ElementName = "MemberCode", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MemberCode { get; set; }
        [XmlElement(ElementName = "MemberName", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MemberName { get; set; }
        [XmlElement(ElementName = "Date", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Date { get; set; }
    }
}
