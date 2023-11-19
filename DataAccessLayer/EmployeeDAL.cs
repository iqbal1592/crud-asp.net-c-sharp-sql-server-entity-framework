using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class EmployeeDAL
	{
		public void Add(Employee employee)
		{
			using (var context = new HRMSEntities())
			{
				context.Employee.AddObject(employee);
				context.SaveChanges();
			}
		}

		public void Update(Employee employee)
		{
			using (var context = new HRMSEntities())
			{
				context.Employee.Attach(context.Employee.Single(e => e.Id == employee.Id));
				context.Employee.ApplyCurrentValues(employee);
				context.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			using (var context = new HRMSEntities())
			{
				Employee employee = context.Employee.Single(e => e.Id == id);
				context.Employee.Attach(employee);
				context.Employee.DeleteObject(employee);
				context.SaveChanges();
			}
		}

		public Employee Get(int id)
		{
			using (var context = new HRMSEntities())
			{
				return context.Employee.Where(e => e.Id == id).FirstOrDefault();
			}
		}

		public List<Employee> GetAll(String sortColumn, String sortOrder, int pageNo, int pageSize, out int totalRecordsCount, String firstName, String lastName)
		{
			using (var context = new HRMSEntities())
			{
				var query = from e in context.Employee
							where (firstName == null || e.FirstName.Contains(firstName))
							&& (lastName == null || e.LastName.Contains(lastName))
							select e;

				totalRecordsCount = query.Count();
				int pagesCount = (int)Math.Ceiling((double)totalRecordsCount / pageSize);
				if (pageNo > pagesCount)
				{
					pageNo = pagesCount;
				}

				Func<Employee, Object> func;

				switch (sortColumn.ToLower())
				{
					case "firstname":
						func = f => f.FirstName;
						break;

					case "lastname":
						func = f => f.LastName;
						break;

					case "emailaddress":
						func = f => f.EmailAddress;
						break;

					case "isactive":
						func = f => f.IsActive;
						break;

					case "gender":
						func = f => f.Gender;
						break;

					default:
						func = f => f.Id;
						break;
				}

				if (sortOrder.ToLower() == "desc")
				{
					return query.OrderByDescending(func).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
				}
				else
				{
					return query.OrderBy(func).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
				}
			}
		}
	}
}