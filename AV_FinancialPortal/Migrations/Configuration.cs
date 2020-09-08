namespace AV_FinancialPortal.Migrations
{
	using AV_FinancialPortal.Models;
	using Microsoft.Ajax.Utilities;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using System.Web.Configuration;

	internal sealed class Configuration : DbMigrationsConfiguration<AV_FinancialPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AV_FinancialPortal.Models.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			#region Role Creation
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			if (!context.Roles.Any(r => r.Name == "Admin"))
			{
				roleManager.Create(new IdentityRole { Name = "Admin" });
			}
			//head of household role 
			if (!context.Roles.Any(r => r.Name == "Head"))
			{
				roleManager.Create(new IdentityRole { Name = "Head" });
			}
			//part of a household, but not the head 
			//assign users to this role who used an invitation code 
			if (!context.Roles.Any(r => r.Name == "Member"))
			{
				roleManager.Create(new IdentityRole { Name = "Member" });
			}
			//new user who has not joined a household 
			//assign users to this role if they did not use an invitation code 
			//also be assigned to any user that leaves a household 
			if (!context.Roles.Any(r => r.Name == "New User"))
			{
				roleManager.Create(new IdentityRole { Name = "New User" });
			}
			#endregion

			#region User Creation
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var adminEmail = WebConfigurationManager.AppSettings["AdminEmail"];
			var demoPassword = WebConfigurationManager.AppSettings["DemoPassword"];
			if (!context.Users.Any(u => u.Email == adminEmail))
			{
				userManager.Create(new ApplicationUser()
				{
					Email = adminEmail,
					UserName = adminEmail,
					FirstName = "Angelica",
					LastName = "Velez",

				}, demoPassword);
				var userId = userManager.FindByEmail(adminEmail).Id;
				userManager.AddToRole(userId, "Admin");
			}
			#endregion
		}
	}
}
