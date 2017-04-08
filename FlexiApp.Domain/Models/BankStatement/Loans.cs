using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiApp.Domain.Models.BankStatement
{
    public class Loans
    {
        public List<SmallAmountLoansLoan> SmallAmountLoansLoans { get; set; }
        public List<SmallAmountLoansRepayment> SmallAmountLoansRepayments { get; set; }
        public List<SmallAmountLoansDishonour> SmallAmountLoansDishonours { get; set; }
        public List<OtherDishonour> OtherDishonours { get; set; }
        public List<OtherLoan> OtherLoans { get; set; }
    }
}