using AV_FinancialPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AV_FinancialPortal.ViewModels
{
	public class ConfigureHouseVM
	{
		public int HouseholdId { get; set; }

		public string OwnerId { get; set; }

		public string Created { get; set; }

		#region One of Everything
		//public BankAccount BankAccount { get; set; }

		//public Budget Budget { get; set; }

		//public BudgetItem BudgetItem { get; set; }
		#endregion

		#region Multiple Options 
		//public ICollection<BankAccount> Accounts { get; set; }
		//public ICollection<Budget> Budgets { get; set; }
		//public ICollection<BudgetItem> BudgetItems { get; set; }
		#endregion

		public ICollection<BankAccountWizardVM> BankAccounts { get; set; }

		public ICollection<BudgetWizardVM> Budgets { get; set; }
	}
}