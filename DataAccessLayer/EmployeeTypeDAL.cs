using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmployeeTypeDAL
	{
		public void Add(EmployeeType employeeType)
		{
			using (var context = new HRMSEntities())
			{
				context.EmployeeType.AddObject(employeeType);
				context.SaveChanges();
			}
		}

		public void Update(EmployeeType employeeType)
		{
			using (var context = new HRMSEntities())
			{
				context.EmployeeType.Attach(context.EmployeeType.Single(e => e.Id == employeeType.Id));
				context.EmployeeType.ApplyCurrentValues(employeeType);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmployeeType employeeType = context.EmployeeType.Single(e => e.Id == id);
				context.EmployeeType.Attach(employeeType);
				context.EmployeeType.DeleteObject(employeeType);
				context.SaveChanges();
			}
		}

		public EmployeeType Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmployeeType.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmployeeType> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmployeeType.ToList();
			}
		}
	}
}