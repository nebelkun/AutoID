using AutoID.DataHolders;
using Common.Helpers.WPF;
using System;

namespace AutoID.ViewModels
{
	public class TaskViewModel : BaseViewModel
	{
		public int No { get; set; }
		public Guid Id { get; set; }
		public IssueType IssueType { get; set; }
		public IssuePriority Priority { get; set; }
		public string Comment { get; set; }
		public string AssigneeName { get; set; }
		public string ReporterName { get; set; }
		public IssueStatus IssueStatus { get; set; }
		public DateTime? ClosedDate { get; set; }
		public DateTime OpenDate { get; set; }
		public string Name { get; set; }
		public TaskViewModel()
		{
			Id = Guid.NewGuid();
		}
	}

}