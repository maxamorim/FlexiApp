using System;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "PersonalInformation", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class PersonalInformation
    {
        [XmlElement(ElementName = "SIN", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string SIN { get; set; }
        [XmlElement(ElementName = "DOB", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public string DOB { get; set; }
    }
}
