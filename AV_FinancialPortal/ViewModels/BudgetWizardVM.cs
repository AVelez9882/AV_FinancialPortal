﻿using AV_FinancialPortal.Models;
using System.Collections;
using System.Collections.Generic;

namespace AV_FinancialPortal.ViewModels
{
	public class BudgetWizardVM
	{
		public Budget Budget { get; set; }

		public ICollection<BudgetItem> BudgetItems { get; set; }
	}
}