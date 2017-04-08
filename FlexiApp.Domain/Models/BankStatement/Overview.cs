using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiApp.Domain.Models.BankStatement
{
    public class Overview
    {
        public Income Income { get; set; }
        public Loans Loans { get; set; }
        public Outgoings Outgoings { get; set; }
    }
}