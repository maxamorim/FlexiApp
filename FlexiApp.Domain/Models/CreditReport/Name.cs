using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Name", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Name
    {
        [XmlElement(ElementName = "LastName", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "FirstName", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string MiddleName { get; set; }
        [XmlAttribute(AttributeName = "NameType")]
        public string NameType { get; set; }
    }
}
