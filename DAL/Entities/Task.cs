using System;
using System.Data.SqlTypes;

namespace AutoID.Models
{
	public class Task
	{
		public Task()
		{
			ClosedDate = (DateTime)SqlDateTime.MinValue;
		}
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int IssueType { get; set; }
		public int Priority { get; set; }
		public string Comment { get; set; }
		public DateTime OpenDate { get; set; }
		public DateTime? ClosedDate { get; set; }
		public string AssigneeName { get; set; }
		public string ReporterName { get; set; }
		public bool IsDone { get; set; }
		public int IssueStatus { get; set; }
		public int No { get; set; }
	}
}
