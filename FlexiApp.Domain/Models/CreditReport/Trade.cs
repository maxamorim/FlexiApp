using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Trade", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Trade
    {
        [XmlElement(ElementName = "MemberCode", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MemberCode { get; set; }
        [XmlElement(ElementName = "MemberName", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MemberName { get; set; }
        [XmlElement(ElementName = "Type", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Account", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Account { get; set; }
        [XmlElement(ElementName = "Joint", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Joint { get; set; }
        [XmlElement(ElementName = "DateOpened", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string DateOpened { get; set; }
        [XmlElement(ElementName = "DateRevised", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string DateRevised { get; set; }
        [XmlElement(ElementName = "DateLastActivity", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string DateLastActivity { get; set; }
        [XmlElement(ElementName = "MOP", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MOP { get; set; }
        [XmlElement(ElementName = "Balance", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Balance { get; set; }
        [XmlElement(ElementName = "HighCredit", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string HighCredit { get; set; }
        [XmlElement(ElementName = "CreditLimit", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string CreditLimit { get; set; }
        [XmlElement(ElementName = "Frequency", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Frequency { get; set; }
        [XmlElement(ElementName = "Payment", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Payment { get; set; }
        [XmlElement(ElementName = "Narrative1", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Narrative1 { get; set; }
        [XmlElement(ElementName = "PastDue", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string PastDue { get; set; }
        [XmlElement(ElementName = "PaymentPatternStartDate", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string PaymentPatternStartDate { get; set; }
        [XmlElement(ElementName = "PaymentPattern", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string PaymentPattern { get; set; }
        [XmlElement(ElementName = "MonthsReviewed", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MonthsReviewed { get; set; }
        [XmlElement(ElementName = "Plus30", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Plus30 { get; set; }
        [XmlElement(ElementName = "Plus60", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Plus60 { get; set; }
        [XmlElement(ElementName = "Plus90", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Plus90 { get; set; }
    }

}
