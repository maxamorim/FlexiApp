using System.Collections.Generic;

namespace FlexiApp.Domain.Models.BankStatement
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountHolder { get; set; }
        public string SecondaryAccountHolder { get; set; }
        public double BankAvailableBalance { get; set; }
        public double BankCurrentBalanceOriginal { get; set; }
        public double BankCurrentBalance { get; set; }
        public string CardMinPayment { get; set; }
        public string CardRunningBalance { get; set; }
        public string CardLastPaymentAmount { get; set; }
        public string CardAvailableCredit { get; set; }
        public string CardTotalCreditLine { get; set; }
        public string CardDueDate { get; set; }
        public string CardLastPaymentDate { get; set; }
        public string CreateDT { get; set; }
        public int ServiceID { get; set; }
        public string BankName { get; set; }
        public string AccountBSB { get; set; }
        public int DishonourCount { get; set; }
        public int DaysRange { get; set; }
        public int accountCategoryId { get; set; }
        public string accountCategory { get; set; }
        public int loanInterestRateTypeId { get; set; }
        public string loanInterestRateType { get; set; }
        public string loanTerm { get; set; }
        public int loanTypeId { get; set; }
        public string loanType { get; set; }
        public int interestRate { get; set; }
        public string dueDateLoan { get; set; }
        public int overDraft { get; set; }
        public string lastPaymentDate { get; set; }
        public int MaxAmountOverdraft { get; set; }
        public int DaysOverdraft { get; set; }
        public double TotalCredits { get; set; }
        public double TotalDebits { get; set; }
        public string FirstTransaction { get; set; }
        public string LastTransaction { get; set; }
        public double DayAgoBalance { get; set; }
        public Overviews Overviews { get; set; }
        public Transactions Transactions { get; set; }
    }

}