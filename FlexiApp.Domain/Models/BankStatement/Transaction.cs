namespace FlexiApp.Domain.Models.BankStatement
{
    public class Transaction
    {
        public int AccountID { get; set; }
        public string TranID { get; set; }
        public string CleanDesc { get; set; }
        public string Category { get; set; }
        public string TranDate { get; set; }
        public string TranAmount { get; set; }
        public string TranBaseTypeID { get; set; }
        public string TranBaseType { get; set; }
        public string GroupID { get; set; }
        public double Balance { get; set; }
    }
}