using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class CountryDAL
	{
		public void Add(Country country)
		{
			using (var context = new HRMSEntities())
			{
				context.Country.AddObject(country);
				context.SaveChanges();
			}
		}

		public void Update(Country country)
		{
			using (var context = new HRMSEntities())
			{
				context.Country.Attach(context.Country.Single(c => c.Id == country.Id));
				context.Country.ApplyCurrentValues(country);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				Country country = context.Country.Single(c => c.Id == id);
				context.Country.Attach(country);
				context.Country.DeleteObject(country);
				context.SaveChanges();
			}
		}

		public Country Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.Country.Where(c => c.Id == id).FirstOrDefault();
			}
		}

		public List<Country> GetAll()
		{
			using (var context = new HRMSEntities())
			{
				return context.Country.ToList();
			}
		}
	}
}