using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace DAL
{
	public class ServiceWorker
	{
		public static IEnumerable<Service> ReadAll()
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.Services
						select m).ToList();
			}
		}

		public static bool NewTask(Service service)
		{
			using (var db = new AutoIDContext())
			{
				db.Services.Add(service);
				if (db.SaveChanges() >= 0)
				{
					return true;
				}
				return false;
			}
		}

		public static bool EditTask(Service service)
		{
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.Services
							  where m.Id == service.Id
							  select m).SingleOrDefault();

				if (entity != null)
				{
					entity.Period = service.Period;
					entity.AssigneeName = service.AssigneeName;
					entity.Comment = service.Comment;
					entity.Id = service.Id;
					entity.Name = service.Name;
					entity.ReporterName = service.ReporterName;

					if (db.SaveChanges() >= 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool RemoveTask(Guid id)
		{
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.Services
							  where m.Id == id
							  select m).SingleOrDefault();

				if (entity != null)
				{
					db.Services.Remove(entity);
					return db.SaveChanges() > 0;
				}
			}
			return false;
		}
	}
}
