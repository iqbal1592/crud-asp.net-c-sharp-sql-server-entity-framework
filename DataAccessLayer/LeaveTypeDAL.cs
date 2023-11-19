using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class LeaveTypeDAL
	{
		public void Add(LeaveType leaveType)
		{
			using (var context = new HRMSEntities())
			{
				context.LeaveType.AddObject(leaveType);
				context.SaveChanges();
			}
		}

		public void Update(LeaveType leaveType)
		{
			using (var context = new HRMSEntities())
			{
				context.LeaveType.Attach(context.LeaveType.Single(l => l.Id == leaveType.Id));
				context.LeaveType.ApplyCurrentValues(leaveType);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				LeaveType leaveType = context.LeaveType.Single(l => l.Id == id);
				context.LeaveType.Attach(leaveType);
				context.LeaveType.DeleteObject(leaveType);
				context.SaveChanges();
			}
		}

		public LeaveType Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.LeaveType.Where(l => l.Id == id).FirstOrDefault();
			}
		}

		public List<LeaveType> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.LeaveType.ToList();
			}
		}
	}
}