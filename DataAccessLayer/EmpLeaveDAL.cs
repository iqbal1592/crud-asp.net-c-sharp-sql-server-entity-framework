using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmpLeaveDAL
	{
		public void Add(EmpLeave empLeave)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpLeave.AddObject(empLeave);
				context.SaveChanges();
			}
		}

		public void Update(EmpLeave empLeave)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpLeave.Attach(context.EmpLeave.Single(e => e.Id == empLeave.Id));
				context.EmpLeave.ApplyCurrentValues(empLeave);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmpLeave empLeave = context.EmpLeave.Single(e => e.Id == id);
				context.EmpLeave.Attach(empLeave);
				context.EmpLeave.DeleteObject(empLeave);
				context.SaveChanges();
			}
		}

		public EmpLeave Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpLeave.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmpLeave> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpLeave.ToList();
			}
		}
	}
}