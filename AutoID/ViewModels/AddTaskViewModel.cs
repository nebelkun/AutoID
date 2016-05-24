using System;
using AutoID.DataHolders;
using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class AddTaskViewModel : BaseViewModel
	{
		public TaskItemViewModel Task { get; set; }
		public AddTaskViewModel()
		{
			SaveCommand = new RelayCommand(OnSave, CanSave);
		}

		bool CanSave()
		{
			return !string.IsNullOrWhiteSpace(Name);
		}

		void OnSave()
		{
			Task = new TaskItemViewModel
			{
				AssigneeName = AssigneeName,
				Comment = Comment,
				IssueType = SelectedIssueType,
				Priority = SelectedIssuePriority,
				ReporterName = ReporterName,
				IssueStatus = IssueStatus.Открыт,

			};

		}

		public IssueType IssueTypes { get; set; }
		public IssueType SelectedIssueType { get; set; }
		public string Name { get; set; }
		public string Comment { get; set; }
		public IssuePriority IssuePriorities { get; set; }
		public IssuePriority SelectedIssuePriority { get; set; }
		public string ReporterName { get; set; }
		public string AssigneeName { get; set; }


		public RelayCommand SaveCommand { get; set; }
	}
}
