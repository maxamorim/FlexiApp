﻿namespace FlexiApp.Domain.Models.BankStatement
{
    public class OtherIncome
    {
        public int AccountID { get; set; }
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string H3 { get; set; }
        public string SH1 { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string FrequencyDescription { get; set; }
        public string FrequencyDuration { get; set; }
        public string FrequencyDurationDate { get; set; }
        public string FrequencyWeekday { get; set; }
        public double FrequencyAmount { get; set; }
        public string FrequencyAmountRange { get; set; }
        public double TotalAmount { get; set; }
        public double TotalInAmount { get; set; }
        public int TotalOutAmount { get; set; }
        public double MonthlyAmount { get; set; }
        public string GroupID { get; set; }
        public string Display { get; set; }
        public string FrequencyExactness { get; set; }
        public string FrequencyPeriod { get; set; }
        public string ScoreEmployer { get; set; }
        public string ScoreDirCr { get; set; }
        public string ScoreWeekday { get; set; }
        public string ScoreFrequency { get; set; }
        public string ScoreAmount { get; set; }
        public int ScoreTotal { get; set; }
    }
}