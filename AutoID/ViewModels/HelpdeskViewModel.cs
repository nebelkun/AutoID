using System.Collections.ObjectModel;
using System.Windows.Forms;
using AutoID.DataHolders;
using AutoID.Views;
using Common.Helpers.WPF;
using DAL;
using AutoID.Helpers;
using Common.Helpers;
using MessageBox = System.Windows.MessageBox;

namespace AutoID.ViewModels
{
	public class HelpdeskViewModel : BaseViewModel
	{
		public HelpdeskViewModel()
		{
			AddCommand = new RelayCommand(OnAdd);
			ResolveCommand = new RelayCommand(OnResolve, CanClose);
			RemoveCommand = new RelayCommand(OnRemoveCommand, CanRemove);
			RefreshCommand = new RelayCommand(OnRefresh);
			ExportCommand = new RelayCommand(OnExport);
			FillTaskList();
		}

		void OnExport()
		{
			var dialog = new FolderBrowserDialog
			{
				Description = "Выберите папку для экспорта:",
				ShowNewFolderButton = true,
			};
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show(ExportHelper.TaskList(dialog.SelectedPath, "HelpdeskExport", TaskList) ? "Экспорт завершён" : "Ошибка экспорта");
			}
		}

		void OnRefresh()
		{
			FillTaskList();
		}

		void FillTaskList()
		{
			TaskList = new ObservableCollection<TaskViewModel>();
			var entities = TaskWorker.ReadAll();
			foreach (var item in entities)
			{
				TaskList.Add(EntityViewModelConverter.Convert(item));
			}
			OnPropertyChanged(() => TaskList);
		}

		bool CanRemove()
		{
			return SelectedTask != null;
		}

		bool CanClose()
		{
			return SelectedTask != null && SelectedTask.IssueStatus!= IssueStatus.Closed;
		}

		void OnRemoveCommand()
		{
			TaskWorker.RemoveTask(SelectedTask.Id);
			TaskList.Remove(SelectedTask);
		}

		void OnResolve()
		{
			ResolveTaskView view = new ResolveTaskView
			{
				DataContext = new ResolveTaskViewModel(SelectedTask),
			};

			if ((bool)view.ShowDialog())
			{
				SelectedTask.IssueStatus = IssueStatus.Closed;
				SelectedTask.Comment = ((ResolveTaskViewModel)view.DataContext).Model.Comment;
				TaskWorker.EditTask(EntityViewModelConverter.Convert(SelectedTask));
				OnPropertyChanged(() => TaskList);
			}
			
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
		public RelayCommand RefreshCommand { get; set; }
		public RelayCommand ResolveCommand { get; set; }
		public RelayCommand RemoveCommand { get; set; }
		public RelayCommand ExportCommand { get; set; }
	}
}