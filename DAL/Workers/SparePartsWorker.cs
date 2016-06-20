using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
	public class SparePartsWorker
	{
		public static IEnumerable<SparePart> ReadAll()
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.SpareParts
						select m).ToList();
			}
		}

		public static bool AddSparePart(SparePart sparePart)
		{
			using (var db = new AutoIDContext())
			{
				db.SpareParts.Add(sparePart);
				if (db.SaveChanges() >= 0)
				{
					return true;
				}
				return false;
			}
		}

		public static bool EditSparePart(SparePart sparePart)
		{
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.SpareParts
							  where m.Id == sparePart.Id
							  select m).SingleOrDefault();

				if (entity != null)
				{
					entity.Name = sparePart.Name;
					entity.Article = sparePart.Article;
					entity.Quantity = sparePart.Quantity;
					entity.Id = sparePart.Id;

					if (db.SaveChanges() >= 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool RemoveSparePart(Guid id)
		{
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.SpareParts
							  where m.Id == id
							  select m).SingleOrDefault();

				if (entity != null)
				{
					db.SpareParts.Remove(entity);
					return db.SaveChanges() > 0;
				}
			}
			return false;
		}
	}
}