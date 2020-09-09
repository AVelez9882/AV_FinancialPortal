﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AV_FinancialPortal.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace AV_FinancialPortal.Extensions
{
	public static class AuthorizeExtensions
	{
		public static async Task RefreshAuthentication(this HttpContextBase context, ApplicationUser user)
		{
			context.GetOwinContext().Authentication.SignOut();
			await context.GetOwinContext().Get<ApplicationSignInManager>().SignInAsync(user, isPersistent: false, rememberBrowser: false);
		}

		public static void AutoLogout(this HttpContextBase context)
		{
			context.GetOwinContext().Authentication.SignOut();
		}
	}
}