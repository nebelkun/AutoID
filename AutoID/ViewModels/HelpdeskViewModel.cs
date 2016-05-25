using System.Collections.ObjectModel;
using AutoID.Views;
using Common.Helpers.WPF;
using DAL;
using AutoID.DataHolders;
using AutoID.Helpers;
using System;

namespace AutoID.ViewModels
{
	public class HelpdeskViewModel : BaseViewModel
	{
		public HelpdeskViewModel()
		{
			AddCommand = new RelayCommand(OnAdd);
			ResolveCommand = new RelayCommand(OnResolve, CanClose);
			RemoveCommand = new RelayCommand(OnRemoveCommand, CanRemove);
			EditCommand = new RelayCommand(OnEdit, CanEdit);
			FillTaskList();
		}

		private bool CanEdit()
		{
			throw new NotImplementedException();
		}

		private void OnEdit()
		{
			throw new NotImplementedException();
		}

		void FillTaskList()
		{
			TaskList = new ObservableCollection<TaskViewModel>();
			var entities = TaskWorker.ReadAll();
			foreach (var item in entities)
			{
				TaskList.Add(EntityViewModelConverter.Convert(item));
			}
		}

		bool CanRemove()
		{
			return SelectedTask != null;
		}

		bool CanClose()
		{
			return SelectedTask != null;
		}

		void OnRemoveCommand()
		{
			TaskList.Remove(SelectedTask);
		}

		void OnResolve()
		{
			ResolveTaskView view = new ResolveTaskView();
			view.DataContext = new ResolveTaskViewModel(SelectedTask);
			view.ShowDialog();
		}

		void OnAdd()
		{
			AddTaskView view = new AddTaskView();
			var vm = new AddTaskViewModel();
			view.DataContext = vm;
			var dialogResult = view.ShowDialog();
			if (dialogResult != null && (bool)dialogResult)
			{
				TaskList.Add(vm.Task);
				TaskWorker.NewTask(EntityViewModelConverter.Convert(vm.Task));
			}
		}
		public TaskViewModel SelectedTask { get; set; }

		public ObservableCollection<TaskViewModel> TaskList { get; set; }

		public RelayCommand AddCommand { get; set; }
		public RelayCommand EditCommand { get; set; }
		public RelayCommand PropertiesCommand { get; set; }
		public RelayCommand RefreshCommand { get; set; }
		public RelayCommand ResolveCommand { get; set; }
		public RelayCommand RemoveCommand { get; set; }
	}
}