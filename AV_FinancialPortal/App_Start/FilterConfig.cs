﻿using System.Web;
using System.Web.Mvc;

namespace AV_FinancialPortal
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
