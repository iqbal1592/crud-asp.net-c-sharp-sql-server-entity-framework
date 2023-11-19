using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmpBonusDAL
	{
		public void Add(EmpBonus empBonus)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpBonus.AddObject(empBonus);
				context.SaveChanges();
			}
		}

		public void Update(EmpBonus empBonus)
		{
			using (var context = new HRMSEntities())
			{
				context.EmpBonus.Attach(context.EmpBonus.Single(e => e.Id == empBonus.Id));
				context.EmpBonus.ApplyCurrentValues(empBonus);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				EmpBonus empBonus = context.EmpBonus.Single(e => e.Id == id);
				context.EmpBonus.Attach(empBonus);
				context.EmpBonus.DeleteObject(empBonus);
				context.SaveChanges();
			}
		}

		public EmpBonus Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpBonus.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<EmpBonus> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.EmpBonus.ToList();
			}
		}
	}
}