using System;
using AutoID.DataHolders;
using Common.Helpers.WPF;
using System.Windows;

namespace AutoID.ViewModels
{
	public class AddTaskViewModel : BaseViewModel
	{
		public TaskViewModel Task { get; set; }
		public AddTaskViewModel()
		{
			SaveCommand = new RelayCommand<Window>(OnSave, CanSave);
		}

		void OnCancel(Window window)
		{
			if (window != null)
			{
				window.DialogResult = false;
				window.Close();
			}
		}

		bool CanSave(Window window)
		{
			return !string.IsNullOrWhiteSpace(Name);
		}

		void OnSave(Window window)
		{
			Task = new TaskViewModel
			{
				AssigneeName = AssigneeName,
				Comment = Comment,
				IssueType = SelectedIssueType,
				Priority = SelectedPriority,
				ReporterName = ReporterName,
				IssueStatus = IssueStatus.Открыт,
				OpenDate = DateTime.Now,
			};
			window.DialogResult = true;
			window.Close();
		}

		IssueType _selectedIssueType;
		public IssueType SelectedIssueType
		{
			get { return _selectedIssueType;  }
			set
			{
				_selectedIssueType = value;
				OnPropertyChanged(() => SelectedIssueType);
			}
		}
		public string Name { get; set; }
		public string Comment { get; set; }

		IssuePriority _selectedPriority;
		public IssuePriority SelectedPriority
		{
			get { return _selectedPriority; }
			set
			{
				_selectedPriority = value;
				OnPropertyChanged(() => SelectedPriority);
			}
		}

		public string ReporterName { get; set; }
		public string AssigneeName { get; set; }


		public RelayCommand<Window> SaveCommand { get; set; }
	}
}
