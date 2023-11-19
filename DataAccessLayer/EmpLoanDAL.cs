using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmpLoanDAL
	{
		public void Add(EmpLoan empLoan)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpLoan.AddObject(empLoan);
				context.SaveChanges();
			}
		}

		public void Update(EmpLoan empLoan)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpLoan.Attach(context.EmpLoan.Single(e => e.Id == empLoan.Id));
				context.EmpLoan.ApplyCurrentValues(empLoan);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmpLoan empLoan = context.EmpLoan.Single(e => e.Id == id);
				context.EmpLoan.Attach(empLoan);
				context.EmpLoan.DeleteObject(empLoan);
				context.SaveChanges();
			}
		}

		public EmpLoan Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpLoan.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmpLoan> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpLoan.ToList();
			}
		}
	}
}