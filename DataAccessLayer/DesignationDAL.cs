using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class DesignationDAL
	{
		public void Add(Designation designation)
		{
			using (var context = new HRMSEntities())
			{
				context.Designation.AddObject(designation);
				context.SaveChanges();
			}
		}

		public void Update(Designation designation)
		{
			using (var context = new HRMSEntities())
			{
				context.Designation.Attach(context.Designation.Single(d => d.Id == designation.Id));
				context.Designation.ApplyCurrentValues(designation);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				Designation designation = context.Designation.Single(d => d.Id == id);
				context.Designation.Attach(designation);
				context.Designation.DeleteObject(designation);
				context.SaveChanges();
			}
		}

		public Designation Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.Designation.Where(d => d.Id == id).FirstOrDefault();
			}
		}

		public List<Designation> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.Designation.ToList();
			}
		}
	}
}