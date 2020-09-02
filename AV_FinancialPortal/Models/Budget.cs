using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AV_FinancialPortal.Models
{
	public class Budget
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public int Id { get; set; }
		public int HouseholdId { get; set; }
		public virtual Household Household { get; set; }
		public String OwnerId { get; set; }
		public virtual ApplicationUser Owner { get; set; }
		public DateTime Created { get; set; }

		[Display(Name = "Name")]
		public string BudgetName { get; set; }

		//This is how much the user currently spent in this category for the time period 
		[Display (Name = "Current Amount")]
		public decimal CurrentAmount { get; set; }

		//This is how much the user expects to spend in this category for the time period 
		[NotMapped]
		[Display(Name = "Target Amount")]
		public decimal TargetAmount 
		{
			get
			{
				var target = db.BudgetItems.Where(bI => bI.BudgetId == Id).Count();
				return target != 0 ? db.BudgetItems.Where(bI => bI.BudgetId == Id).Sum(s => s.TargetAmount) : 0;
			}
		}

		public virtual ICollection<BudgetItem> Items { get; set; }

		public Budget()
		{
			Items = new HashSet<BudgetItem>();
			Created = DateTime.Now;
			OwnerId = HttpContext.Current.User.Identity.GetUserId();
		}
	}
}