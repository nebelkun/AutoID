using AutoID.DataHolders;
using AutoID.Helpers.WPF;
using System;

namespace AutoID.ViewModels
{
	public class TaskItemViewModel : BaseViewModel
	{
		public int No { get; set; }
		public Guid Id { get; set; }

		public IssueType IssueType { get; set; }

		public IssueType SelectedIssueType { get; set; }

		public Priority Priority { get; set; }

		public Priority SelectedPriority { get; set; }

		public string Comment { get; set; }

		public bool IsDone { get; set; }

		public string AssigneeName { get; set; }

		public string ReporterName { get; set; }

		public IssueStatus IssueStatus { get; set; }

		public TaskItemViewModel()
		{
			Id = Guid.NewGuid();
		}
	}

}