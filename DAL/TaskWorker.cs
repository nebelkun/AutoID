using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DAL
{
	public static class TaskWorker
	{
		public static IEnumerable<AutoID.Models.Task> ReadAll()
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.Tasks
							  select m).ToList();
			}
		}

		public static bool NewTask(AutoID.Models.Task task)
		{
			return false;
		}

		public static bool EditTask(AutoID.Models.Task task)
		{
			return false;
		}

		public static bool RemoveTask(Guid id)
		{
			return false;
		}
	}
}
