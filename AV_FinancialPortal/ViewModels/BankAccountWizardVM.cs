using AV_FinancialPortal.Enums;
using AV_FinancialPortal.Models;

namespace AV_FinancialPortal.ViewModels
{
	public class BankAccountWizardVM
	{
		public decimal StartingBalance { get; set; }
		public decimal WarningBalance { get; set; }
		public string AccountName { get; set; }

		public AccountType AccountType { get; set; }
	}
}