using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "ScoreProduct", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class ScoreProduct
    {
        [XmlElement(ElementName = "Product", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Product { get; set; }
        [XmlElement(ElementName = "Score", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Score { get; set; }
        [XmlElement(ElementName = "ScoreDerogatoryAlert", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string ScoreDerogatoryAlert { get; set; }
        [XmlElement(ElementName = "Factor1", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Factor1 { get; set; }
        [XmlElement(ElementName = "Factor2", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Factor2 { get; set; }
        [XmlElement(ElementName = "Factor3", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Factor3 { get; set; }
        [XmlElement(ElementName = "Factor4", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string Factor4 { get; set; }
        [XmlElement(ElementName = "ScoreCard", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string ScoreCard { get; set; }
    }
}
