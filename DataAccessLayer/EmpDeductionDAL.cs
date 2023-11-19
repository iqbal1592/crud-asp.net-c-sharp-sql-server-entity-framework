using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmpDeductionDAL
	{
		public void Add(EmpDeduction empDeduction)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpDeduction.AddObject(empDeduction);
				context.SaveChanges();
			}
		}

		public void Update(EmpDeduction empDeduction)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpDeduction.Attach(context.EmpDeduction.Single(e => e.Id == empDeduction.Id));
				context.EmpDeduction.ApplyCurrentValues(empDeduction);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmpDeduction empDeduction = context.EmpDeduction.Single(e => e.Id == id);
				context.EmpDeduction.Attach(empDeduction);
				context.EmpDeduction.DeleteObject(empDeduction);
				context.SaveChanges();
			}
		}

		public EmpDeduction Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpDeduction.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmpDeduction> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpDeduction.ToList();
			}
		}
	}
}