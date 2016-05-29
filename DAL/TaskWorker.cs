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
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.Tasks
							  where m.Id == task.Id
							  select m).SingleOrDefault();

				if (entity != null)
				{
					entity.ClosedDate =task.ClosedDate;
					entity.AssigneeName = task.AssigneeName;
					entity.Comment = task.Comment;
					entity.Id = task.Id;
					entity.IssueStatus = task.IssueStatus;
					entity.IssueType = task.IssueType;
					entity.Name = task.Name;
					entity.No = task.No;
					entity.OpenDate = task.OpenDate;
					entity.Priority = task.Priority;
					entity.ReporterName = task.ReporterName;

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
				var entity = (from m in db.Tasks
					where m.Id == id
					select m).SingleOrDefault();

				if (entity != null)
				{
					db.Tasks.Remove(entity);
					return db.SaveChanges() >0;
				}
			}
			return false;
		}
	}
}