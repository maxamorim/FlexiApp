using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "ScoreProducts", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class ScoreProducts
    {
        [XmlElement(ElementName = "ScoreProduct", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public List<ScoreProduct> ScoreProduct { get; set; }
    }
}
