using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoID.DataHolders;
using AutoID.Views;
using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class HelpdeskViewModel : BaseViewModel
	{
		public HelpdeskViewModel()
		{
			TaskList = new ObservableCollection<TaskItemViewModel>();
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Консультация, Priority = Priority.Низкий });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Поломка, Priority = Priority.Высокий });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Поломка, Priority = Priority.Средний });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Настройка, Priority = Priority.Средний });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Поломка, Priority = Priority.Низкий });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Консультация, Priority = Priority.Низкий });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName = "Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Настройка, Priority = Priority.Средний });
			AddTaskCommand = new RelayCommand(OnAddTask);
			CloseTaskCommand = new RelayCommand(OnCloseTask, CanCloseTask);
			RemoveTaskCommand = new RelayCommand(OnRemoveCommand, CanRemoveTask);

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

		void OnCloseTask()
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
		public RelayCommand CloseTaskCommand { get; set; }
		public RelayCommand RemoveTaskCommand { get; set; }
	}
}
