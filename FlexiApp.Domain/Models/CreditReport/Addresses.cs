using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Addresses", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Addresses
    {
        [XmlElement(ElementName = "Address", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public List<Address> Address { get; set; }
    }
}
