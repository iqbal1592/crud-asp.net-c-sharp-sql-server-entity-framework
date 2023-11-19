using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class BonusTypeDAL
	{
		public void Add(BonusType bonusType)
		{
			using (var context = new HRMSEntities())
			{
				context.BonusType.AddObject(bonusType);
				context.SaveChanges();
			}
		}

		public void Update(BonusType bonusType)
		{
			using (var context = new HRMSEntities())
			{
				context.BonusType.Attach(context.BonusType.Single(b => b.Id == bonusType.Id));
				context.BonusType.ApplyCurrentValues(bonusType);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				BonusType bonusType = context.BonusType.Single(b => b.Id == id);
				context.BonusType.Attach(bonusType);
				context.BonusType.DeleteObject(bonusType);
				context.SaveChanges();
			}
		}

		public BonusType Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.BonusType.Where(b => b.Id == id).FirstOrDefault();
			}
		}

		public List<BonusType> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.BonusType.ToList();
			}
		}
	}
}