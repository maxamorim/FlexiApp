using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Trades", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Trades
    {
        [XmlElement(ElementName = "Trade", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public List<Trade> Trade { get; set; }
    }
}
