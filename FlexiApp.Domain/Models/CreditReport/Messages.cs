using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlexiApp.Domain.Models.CreditReport
{
    [XmlRoot(ElementName = "Messages", Namespace = "http://www.transunion.ca/WS/TU4R")]
    public class Messages
    {
        [XmlElement(ElementName = "Message", Namespace = "http://www.transunion.ca/WS/TU4R")]
        public List<Message> Message { get; set; }
    }
}
