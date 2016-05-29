using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace DAL
{
	public static class TaskWorker
	{
		public static IEnumerable<Task> ReadAll()
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.Tasks
							  select m).ToList();
			}
		}

		public static bool NewTask(Task task)
		{
			using (var db = new AutoIDContext())
			{
				db.Tasks.Add(task);
				if (db.SaveChanges() >= 0)
				{
					return true;
				}
				return false;
			}
		}

		public static bool EditTask(Task task)
		{
			return false;
		}

		public static bool RemoveTask(Guid id)
		{
			return false;
		}
	}
}
