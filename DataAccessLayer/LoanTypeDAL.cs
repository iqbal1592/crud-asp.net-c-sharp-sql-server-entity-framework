using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class LoanTypeDAL
	{
		public void Add(LoanType loanType)
		{
			using (var context = new HRMSEntities())
			{
				context.LoanType.AddObject(loanType);
				context.SaveChanges();
			}
		}

		public void Update(LoanType loanType)
		{
			using (var context = new HRMSEntities())
			{
				context.LoanType.Attach(context.LoanType.Single(l => l.Id == loanType.Id));
				context.LoanType.ApplyCurrentValues(loanType);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				LoanType loanType = context.LoanType.Single(l => l.Id == id);
				context.LoanType.Attach(loanType);
				context.LoanType.DeleteObject(loanType);
				context.SaveChanges();
			}
		}

		public LoanType Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.LoanType.Where(l => l.Id == id).FirstOrDefault();
			}
		}

		public List<LoanType> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.LoanType.ToList();
			}
		}
	}
}