using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class DeductionTypeDAL
	{
		public void Add(DeductionType deductionType)
		{
			using (var context = new HRMSEntities())
			{
				context.DeductionType.AddObject(deductionType);
				context.SaveChanges();
			}
		}

		public void Update(DeductionType deductionType)
		{
			using (var context = new HRMSEntities())
			{
				context.DeductionType.Attach(context.DeductionType.Single(d => d.Id == deductionType.Id));
				context.DeductionType.ApplyCurrentValues(deductionType);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				DeductionType deductionType = context.DeductionType.Single(d => d.Id == id);
				context.DeductionType.Attach(deductionType);
				context.DeductionType.DeleteObject(deductionType);
				context.SaveChanges();
			}
		}

		public DeductionType Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.DeductionType.Where(d => d.Id == id).FirstOrDefault();
			}
		}

		public List<DeductionType> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.DeductionType.ToList();
			}
		}
	}
}