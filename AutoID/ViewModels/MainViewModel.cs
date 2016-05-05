using System;
using System.Collections.ObjectModel;
using AutoID.DataHolders;
using AutoID.Helpers.WPF;
using AutoID.Views;

namespace AutoID.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			TaskList = new ObservableCollection<TaskItemViewModel>();
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Консультация, Priority = Priority.Низкий});
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Поломка, Priority = Priority.Высокий});
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Поломка, Priority = Priority.Средний });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Настройка, Priority = Priority.Средний });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Поломка, Priority = Priority.Низкий });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Консультация, Priority = Priority.Низкий });
			TaskList.Add(new TaskItemViewModel { Comment = "123", ReporterName="Мочалов Илья", AssigneeName = "Михаил Земсков", IssueType = IssueType.Настройка, Priority = Priority.Средний });
			AddTaskCommand = new RelayCommand(OnAddTask);
			CloseTaskCommand = new RelayCommand(OnCloseTask, CanCloseTask);
			RemoveTaskCommand = new RelayCommand(OnRemoveCommand, CanRemoveTask);
		}

		private bool CanRemoveTask()
		{
			return SelectedTask != null;
		}

		private bool CanCloseTask()
		{
			return SelectedTask != null;
		}

		private void OnRemoveCommand()
		{
			TaskList.Remove(SelectedTask);
		}

		private void OnCloseTask()
		{
			ResolveTaskView view = new ResolveTaskView();
			view.DataContext = new ResolveTaskViewModel(SelectedTask);
			view.ShowDialog();
		}

		private void OnAddTask()
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