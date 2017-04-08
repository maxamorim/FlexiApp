using System.Collections.Generic;

namespace FlexiApp.Domain.Models.BankStatement
{
    public class Application
    {
        public int AppID { get; set; }
        public int ReportID { get; set; }
        public string AppReference { get; set; }
        public string CreateDT { get; set; }
        public string ClientName { get; set; }
        public string StoreName { get; set; }
        public string Email { get; set; }
        public string StoreCode { get; set; }
        public string AppShortReference { get; set; }
        public string ClientNameShort { get; set; }
        public string StoreNameShort { get; set; }
        public object VerifyEmployer { get; set; }
        public object VerifyAmount { get; set; }
        public object VerifyFrequency { get; set; }
        public object VerifyWeekday { get; set; }
        public string LocalityCode { get; set; }
        public int TemplateReportID { get; set; }
        public int daysRange { get; set; }
        public string templateReportName { get; set; }
        public Accounts Accounts { get; set; }
    }

}