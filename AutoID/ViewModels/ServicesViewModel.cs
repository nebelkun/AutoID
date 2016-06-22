using AutoID.Views;
using Common.Helpers;
using Common.Helpers.WPF;
using DAL;
using System.Collections.ObjectModel;

namespace AutoID.ViewModels
{
	public class ServicesViewModel : BaseViewModel
	{
		public ObservableCollection<ServiceViewModel> ServiceList { get; set; }

		public ServiceViewModel SelectedService { get; set; }

		public ServicesViewModel()
		{
			RefreshCommand = new RelayCommand(OnRefresh);
			ExportCommand = new RelayCommand(OnExport);
			AddCommand = new RelayCommand(OnAdd);

			FillServiceList();
		}

		void OnAdd()
		{
			AddEditServiceView view = new AddEditServiceView();
			var vm = new AddEditServiceViewModel();
			view.DataContext = vm;
			var dialogResult = view.ShowDialog();
			if (dialogResult != null && (bool)dialogResult)
			{
				ServiceList.Add(vm.Service);
				ServiceWorker.NewTask(EntityViewModelConverter.Convert(vm.Service));
			}
		}

		public RelayCommand RefreshCommand { get; set; }
		void OnRefresh()
		{
			FillServiceList();
		}

		void FillServiceList()
		{
			ServiceList = new ObservableCollection<ServiceViewModel>();
			foreach (var service in ServiceWorker.ReadAll())
			{
				ServiceList.Add(EntityViewModelConverter.Convert(service));
			}
			OnPropertyChanged(() => ServiceList);
		}

		public RelayCommand ExportCommand { get; set; }
		void OnExport()
		{
			throw new System.NotImplementedException();
		}

		public RelayCommand AddCommand { get; set; }

		public RelayCommand CreateTaskNow { get; set; }

		public RelayCommand RemoveCommand { get; set; }


	}
}