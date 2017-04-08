using FlexiApp.Domain.Models.BankStatement;
using FlexiApp.Domain.Models.CreditReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace FlexiApp.Infrastructure.Helper
{
    public class Utils
    {
        public byte[] DataTableToCSV(DataTable dt)
        {
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(";", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(";", fields));
            }

            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(sb.ToString());
        }
        public static DataTable ConvertToDataTable(List<RootObject> data)
        {
            var ci = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            //PropertyDescriptorCollection properties =
            //   TypeDescriptor.GetProperties(typeof(T));

            PropertyDescriptorCollection propertiesApplication = TypeDescriptor.GetProperties(typeof(Application));
            StringBuilder sb = new StringBuilder();
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in propertiesApplication)
            {
                sb.Append(string.Format("{0};", prop.Name));
            }
            //table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            if (data.Any())
            {
                var firstApplication = data.FirstOrDefault().Applications.Application;
                if (firstApplication.Accounts != null && firstApplication.Accounts.Account.Any())
                {
                    var totalAccounts = firstApplication.Accounts.Account.Count;
                    for (int i = 0; i < totalAccounts; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Account)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                        //table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
                }
            }


            //foreach (PropertyDescriptor prop in properties)
            //    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            //foreach (T item in data)
            //{
            //    DataRow row = table.NewRow();
            //    foreach (PropertyDescriptor prop in properties)
            //        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            //    table.Rows.Add(row);
            //}
            return table;

        }
        public byte[] ListToCSV(List<RootObject> data)
        {
            var ci = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            PropertyDescriptorCollection propertiesApplication = TypeDescriptor.GetProperties(typeof(Application));
            StringBuilder sb = new StringBuilder();
            foreach (PropertyDescriptor prop in propertiesApplication)
            {
                sb.Append(string.Format("{0};", prop.Name));
            }
            if (data.Any())
            {
                var firstApplication = data.FirstOrDefault().Applications.Application;
                if (firstApplication.Accounts != null && firstApplication.Accounts.Account.Any())
                {
                    var totalAccounts = firstApplication.Accounts.Account.Count;
                    for (int i = 0; i < totalAccounts; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Account)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                        if (firstApplication.Accounts.Account[i].Overviews != null)
                        {
                            #region Income
                            if (firstApplication.Accounts.Account[i].Overviews.Overview.Income != null)
                            {
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary != null && firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary.Any())
                                {
                                    var totalSalary = firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary.Count;
                                    for (int j = 0; j < totalSalary; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Salary)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits != null && firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits.Any())
                                {
                                    var totalBenefits = firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits.Count;
                                    for (int j = 0; j < totalBenefits; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Benefit)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes != null && firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes.Any())
                                {
                                    var totalOtherIncomes = firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes.Count;
                                    for (int j = 0; j < totalOtherIncomes; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherIncome)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region Loan
                            if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans != null)
                            {
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(SmallAmountLoansLoan)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(SmallAmountLoansDishonour)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(SmallAmountLoansRepayment)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherDishonour)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherLoan)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region Outgoings
                            if (firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings != null)
                            {
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent != null && firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Rent)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings != null && firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherOutgoing)))
                                        {
                                            sb.Append(string.Format("{0};", prop.Name));
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        #region Transactions
                        if (firstApplication.Accounts.Account[i].Transactions != null)
                        {
                            if (firstApplication.Accounts.Account[i].Transactions.Transaction.Any())
                            {
                                var totalTransactions = firstApplication.Accounts.Account[i].Transactions.Transaction.Count;
                                for (int j = 0; j < totalTransactions; j++)
                                {
                                    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Transaction)))
                                    {
                                        sb.Append(string.Format("{0};", prop.Name));
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    sb.AppendLine("");
                    foreach (PropertyDescriptor prop in propertiesApplication)
                    {
                        sb.Append(string.Format("{0};", prop.GetValue(firstApplication) ?? ""));
                    }
                    for (int i = 0; i < totalAccounts; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Account)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i]) ?? ""));
                        }
                        if (firstApplication.Accounts.Account[i].Overviews != null)
                        {
                            #region Income
                            if (firstApplication.Accounts.Account[i].Overviews.Overview.Income != null)
                            {
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary != null && firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary.Any())
                                {
                                    var totalSalary = firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary.Count;
                                    for (int j = 0; j < totalSalary; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Salary)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Income.Salary[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits != null && firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits.Any())
                                {
                                    var totalBenefits = firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits.Count;
                                    for (int j = 0; j < totalBenefits; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Benefit)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Income.Benefits[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes != null && firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes.Any())
                                {
                                    var totalOtherIncomes = firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes.Count;
                                    for (int j = 0; j < totalOtherIncomes; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherIncome)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Income.OtherIncomes[j]) ?? ""));
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region Loan
                            if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans != null)
                            {
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(SmallAmountLoansLoan)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansLoans[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(SmallAmountLoansDishonour)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansDishonours[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(SmallAmountLoansRepayment)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Loans.SmallAmountLoansRepayments[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherDishonour)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherDishonours[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans != null && firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherLoan)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Loans.OtherLoans[j]) ?? ""));
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region Outgoings
                            if (firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings != null)
                            {
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent != null && firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Rent)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.Rent[j]) ?? ""));
                                        }
                                    }
                                }
                                if (firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings != null && firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings.Any())
                                {
                                    var total = firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings.Count;
                                    for (int j = 0; j < total; j++)
                                    {
                                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(OtherOutgoing)))
                                        {
                                            sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Overviews.Overview.Outgoings.OtherOutgoings[j]) ?? ""));
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        #region Transactions
                        if (firstApplication.Accounts.Account[i].Transactions != null)
                        {
                            if (firstApplication.Accounts.Account[i].Transactions.Transaction.Any())
                            {
                                var totalTransactions = firstApplication.Accounts.Account[i].Transactions.Transaction.Count;
                                for (int j = 0; j < totalTransactions; j++)
                                {
                                    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Transaction)))
                                    {
                                        sb.Append(string.Format("{0};", prop.GetValue(firstApplication.Accounts.Account[i].Transactions.Transaction[j]) ?? ""));
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                }

            }
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(sb.ToString());
        }
        public byte[] XMLObjectToCSV(Envelope xml)
        {
            var ci = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(ProcessRequestXMLResult));
            StringBuilder sb = new StringBuilder();
            foreach (PropertyDescriptor prop in properties)
            {
                sb.Append(string.Format("{0};", prop.Name));
            }

            if (xml.Body != null && xml.Body.ProcessRequestXMLResponse.ProcessRequestXMLResult != null && xml.Body.ProcessRequestXMLResponse.ProcessRequestXMLResult.TU_FFR_Report != null)
            {
                var tuReport = xml.Body.ProcessRequestXMLResponse.ProcessRequestXMLResult.TU_FFR_Report;
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(TU_FFR_Report)))
                {
                    sb.Append(string.Format("{0};", prop.Name));
                }
                #region Names
                if (tuReport.Names != null && tuReport.Names.Name.Any())
                {
                    var total = tuReport.Names.Name.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Name)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                    }
                }
                #endregion
                #region PersonalInformation
                if (tuReport.PersonalInformation != null)
                {
                    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(PersonalInformation)))
                    {
                        sb.Append(string.Format("{0};", prop.Name));
                    }
                }
                #endregion
                #region Addresses
                if (tuReport.Addresses != null && tuReport.Addresses.Address.Any())
                {
                    var total = tuReport.Addresses.Address.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Address)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                    }
                }
                #endregion
                #region Trades
                if (tuReport.Trades != null && tuReport.Trades.Trade.Any())
                {
                    var total = tuReport.Trades.Trade.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Trade)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                    }
                }
                #endregion
                #region Inquiries
                if (tuReport.Inquiries != null && tuReport.Inquiries.Inquiry.Any())
                {
                    var total = tuReport.Inquiries.Inquiry.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Inquiry)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                    }
                }
                #endregion
                #region Messages
                if (tuReport.Messages != null && tuReport.Messages.Message.Any())
                {
                    var total = tuReport.Messages.Message.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Message)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                    }
                }
                #endregion
                #region ScoreProducts
                if (tuReport.ScoreProducts != null && tuReport.ScoreProducts.ScoreProduct.Any())
                {
                    var total = tuReport.ScoreProducts.ScoreProduct.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(ScoreProduct)))
                        {
                            sb.Append(string.Format("{0};", prop.Name));
                        }
                    }
                }
                #endregion

                sb.AppendLine("");
                foreach (PropertyDescriptor prop in properties)
                {
                    sb.Append(string.Format("{0};", prop.GetValue(xml.Body.ProcessRequestXMLResponse.ProcessRequestXMLResult) ?? ""));
                }
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(TU_FFR_Report)))
                {
                    sb.Append(string.Format("{0};", prop.GetValue(tuReport) ?? ""));
                }
                #region Names
                if (tuReport.Names != null && tuReport.Names.Name.Any())
                {
                    var total = tuReport.Names.Name.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Name)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(tuReport.Names.Name[i]) ?? ""));
                        }
                    }
                }
                #endregion
                #region PersonalInformation
                if (tuReport.PersonalInformation != null)
                {
                    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(PersonalInformation)))
                    {
                        sb.Append(string.Format("{0};", prop.GetValue(tuReport.PersonalInformation) ?? ""));
                    }
                }
                #endregion
                #region Addresses
                if (tuReport.Addresses != null && tuReport.Addresses.Address.Any())
                {
                    var total = tuReport.Addresses.Address.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Address)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(tuReport.Addresses.Address[i]) ?? ""));
                        }
                    }
                }
                #endregion
                #region Trades
                if (tuReport.Trades != null && tuReport.Trades.Trade.Any())
                {
                    var total = tuReport.Trades.Trade.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Trade)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(tuReport.Trades.Trade[i]) ?? ""));
                        }
                    }
                }
                #endregion
                #region Inquiries
                if (tuReport.Inquiries != null && tuReport.Inquiries.Inquiry.Any())
                {
                    var total = tuReport.Inquiries.Inquiry.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Inquiry)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(tuReport.Inquiries.Inquiry[i]) ?? ""));
                        }
                    }
                }
                #endregion
                #region Messages
                if (tuReport.Messages != null && tuReport.Messages.Message.Any())
                {
                    var total = tuReport.Messages.Message.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(Message)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(tuReport.Messages.Message[i]) ?? ""));
                        }
                    }
                }
                #endregion
                #region ScoreProducts
                if (tuReport.ScoreProducts != null && tuReport.ScoreProducts.ScoreProduct.Any())
                {
                    var total = tuReport.ScoreProducts.ScoreProduct.Count;
                    for (int i = 0; i < total; i++)
                    {
                        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(typeof(ScoreProduct)))
                        {
                            sb.Append(string.Format("{0};", prop.GetValue(tuReport.ScoreProducts.ScoreProduct[i]) ?? ""));
                        }
                    }
                }
                #endregion
            }



            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(sb.ToString());
        }
    }
}
