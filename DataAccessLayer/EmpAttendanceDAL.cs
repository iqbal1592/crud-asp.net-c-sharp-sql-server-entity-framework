using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmpAttendanceDAL
	{
		public void Add(EmpAttendance empAttendance)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpAttendance.AddObject(empAttendance);
				context.SaveChanges();
			}
		}

		public void Update(EmpAttendance empAttendance)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpAttendance.Attach(context.EmpAttendance.Single(e => e.Id == empAttendance.Id));
				context.EmpAttendance.ApplyCurrentValues(empAttendance);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmpAttendance empAttendance = context.EmpAttendance.Single(e => e.Id == id);
				context.EmpAttendance.Attach(empAttendance);
				context.EmpAttendance.DeleteObject(empAttendance);
				context.SaveChanges();
			}
		}

		public EmpAttendance Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpAttendance.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmpAttendance> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpAttendance.ToList();
			}
		}
	}
}