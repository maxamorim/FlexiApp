using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiApp.Domain.Models.BankStatement
{
    public class Income
    {
        public List<Salary> Salary { get; set; }
        public List<Benefit> Benefits { get; set; }
        public List<OtherIncome> OtherIncomes { get; set; }
    }
}
