using AV_FinancialPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AV_FinancialPortal.Extensions
{
	public static class TransactionExtensions
	{
		public static ApplicationDbContext db = new ApplicationDbContext();
	}
}