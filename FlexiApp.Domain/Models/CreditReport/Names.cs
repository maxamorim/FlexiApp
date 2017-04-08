using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Names", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Names
    {
        [XmlElement(ElementName = "Name", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public List<Name> Name { get; set; }
    }

}
