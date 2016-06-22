using AutoID.DataHolders;
using Common.Helpers.WPF;
using System;
using System.Windows;

namespace AutoID.ViewModels
{
	public class AddTaskViewModel : BaseViewModel
	{
		public TaskViewModel Task { get; set; }

		IssueType _selectedIssueType;
		public IssueType SelectedIssueType
		{
			get { return _selectedIssueType; }
			set
			{
				_selectedIssueType = value;
				OnPropertyChanged(() => SelectedIssueType);
			}
		}

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

		public string Name { get; set; }
		public string Comment { get; set; }
		public string ReporterName { get; set; }
		public string AssigneeName { get; set; }

		public AddTaskViewModel()
		{
			SaveCommand = new RelayCommand<Window>(OnSave, CanSave);
		}

		public RelayCommand<Window> SaveCommand { get; set; }
		void OnSave(Window window)
		{
			Task = new TaskViewModel
			{
				Name = Name,
				AssigneeName = AssigneeName,
				Comment = Comment,
				IssueType = SelectedIssueType,
				Priority = SelectedPriority,
				ReporterName = ReporterName,
				IssueStatus = IssueStatus.Open,
				OpenDate = DateTime.Now,
			};
			window.DialogResult = true;
			window.Close();
		}
		bool CanSave(Window window)
		{
			return !string.IsNullOrWhiteSpace(Name);
		}
	}
}