using System;
using System.Collections.ObjectModel;
using AutoID.Views;
using Common.Helpers.WPF;
using DAL;
using AutoID.DataHolders;

namespace AutoID.ViewModels
{
	public class HelpdeskViewModel : BaseViewModel
	{
		public HelpdeskViewModel()
		{
			AddTaskCommand = new RelayCommand(OnAddTask);
			ResolveCommand = new RelayCommand(OnResolveTask, CanCloseTask);
			RemoveTaskCommand = new RelayCommand(OnRemoveCommand, CanRemoveTask);
			FillTaskList();
		}

		void FillTaskList()
		{
			TaskList = new ObservableCollection<TaskItemViewModel>();
			var entities = TaskWorker.ReadAll();
			foreach (var item in entities)
			{
				TaskList.Add(new TaskItemViewModel
				{
					AssigneeName = item.AssigneeName,
					Comment = item.Comment,
					Id = item.Id,
					IsDone = item.IsDone,
					IssueStatus = (IssueStatus)item.IssueStatus,
					IssueType = (IssueType)item.IssueType,
					No = item.No,
					Priority = (IssuePriority)item.Priority,
					ReporterName = item.ReporterName,
				});
			}
		}

		bool CanRemoveTask()
		{
			return SelectedTask != null;
		}

		bool CanCloseTask()
		{
			return SelectedTask != null;
		}

		void OnRemoveCommand()
		{
			TaskList.Remove(SelectedTask);
		}

		void OnResolveTask()
		{
			ResolveTaskView view = new ResolveTaskView();
			view.DataContext = new ResolveTaskViewModel(SelectedTask);
			view.ShowDialog();
		}

		void OnAddTask()
		{
			AddTaskView view = new AddTaskView();
			var vm = new AddTaskViewModel();
			view.DataContext = vm;
			var result = view.ShowDialog();
			if (result.Value)
			{
				TaskList.Add(vm.Task);
			}
		}
		public TaskItemViewModel SelectedTask { get; set; }

		public ObservableCollection<TaskItemViewModel> TaskList { get; set; }

		public RelayCommand AddTaskCommand { get; set; }
		public RelayCommand PropertiesCommand { get; set; }
		public RelayCommand RefreshCommand { get; set; }
		public RelayCommand ResolveCommand { get; set; }
		public RelayCommand RemoveTaskCommand { get; set; }
	}
}