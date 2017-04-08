using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Inquiries", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Inquiries
    {
        [XmlElement(ElementName = "Inquiry", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public List<Inquiry> Inquiry { get; set; }
    }
}
