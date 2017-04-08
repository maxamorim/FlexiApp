using System.Collections.Generic;

namespace FlexiApp.Domain.Models.BankStatement
{

    public class Outgoings
    {
        public List<Rent> Rent { get; set; }
        public List<OtherOutgoing> OtherOutgoings { get; set; }
    }

}