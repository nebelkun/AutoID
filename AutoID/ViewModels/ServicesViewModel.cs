using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;
using Common.Helpers.WPF;
using DAL;

namespace AutoID.ViewModels
{
	public class ServicesViewModel : BaseViewModel
	{
		public ServicesViewModel()
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


		public RelayCommand RefreshCommand { get; set; }

		public RelayCommand ExportCommand { get; set; }

		public RelayCommand AddCommand { get; set; }

		public RelayCommand CreateTaskNow { get; set; }

		public RelayCommand RemoveCommand { get; set; }

		public ObservableCollection<ServiceViewModel> ServiceList { get; set; }

		public ServiceViewModel SelectedService { get; set; }
	}
}