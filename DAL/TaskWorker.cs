using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
	public static class TaskWorker
	{
		static string _connectionString;
		public static List<Task> ReadAll()
		{
			return new List<Task>();
		}

		public static bool NewTask(Task task)
		{
			return false;
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
