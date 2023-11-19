using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmpSalaryDAL
	{
		public void Add(EmpSalary empSalary)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpSalary.AddObject(empSalary);
				context.SaveChanges();
			}
		}

		public void Update(EmpSalary empSalary)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpSalary.Attach(context.EmpSalary.Single(e => e.Id == empSalary.Id));
				context.EmpSalary.ApplyCurrentValues(empSalary);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmpSalary empSalary = context.EmpSalary.Single(e => e.Id == id);
				context.EmpSalary.Attach(empSalary);
				context.EmpSalary.DeleteObject(empSalary);
				context.SaveChanges();
			}
		}

		public EmpSalary Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpSalary.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmpSalary> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpSalary.ToList();
			}
		}
	}
}