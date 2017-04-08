using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "TU_FFR_Report", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class TU_FFR_Report
    {
        [XmlElement(ElementName = "Hit", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Hit { get; set; }
        [XmlElement(ElementName = "OnFileDate", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string OnFileDate { get; set; }
        [XmlElement(ElementName = "Names", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public Names Names { get; set; }
        [XmlElement(ElementName = "PersonalInformation", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public PersonalInformation PersonalInformation { get; set; }
        [XmlElement(ElementName = "Addresses", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public Addresses Addresses { get; set; }
        [XmlElement(ElementName = "Trades", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public Trades Trades { get; set; }
        [XmlElement(ElementName = "Inquiries", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public Inquiries Inquiries { get; set; }
        [XmlElement(ElementName = "Messages", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public Messages Messages { get; set; }
        [XmlElement(ElementName = "ScoreProducts", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public ScoreProducts ScoreProducts { get; set; }
    }
}
