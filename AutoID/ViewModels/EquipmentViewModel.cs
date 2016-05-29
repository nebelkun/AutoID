using System;
using System.Collections.ObjectModel;
using Common.Helpers.WPF;
using DAL;
using AutoID.Helpers;
using DAL.Entities;

namespace AutoID.ViewModels
{
	public class EquipmentViewModel : BaseViewModel
	{

		public EquipmentViewModel()
		{
			DetailsCommand = new RelayCommand(OnDetails);
			RefreshCommand = new RelayCommand(OnRefresh);
			RemoveCommand = new RelayCommand(OnRemove);
			ExportCommand = new RelayCommand(OnExport);
			FillEquipment();
		}

		void OnExport()
		{
			NpoiWorker.ExportMachineList("C:\\", "test", EquipmentList);
		}

		void FillEquipment()
		{
			EquipmentList = new ObservableCollection<MachineViewModel>();
			var entities = MachineWorker.ReadAll();
			foreach (Machine item in entities)
			{
				EquipmentList.Add(EntityViewModelConverter.Convert(item));
			}
		}

		void OnRefresh()
		{
			throw new NotImplementedException();
		}

		void OnRemove()
		{
			throw new NotImplementedException();
		}

		void OnDetails()
		{
			throw new NotImplementedException();
		}

		public ObservableCollection<MachineViewModel> EquipmentList { get; set; }
		public Machine SelectedMachine { get; set; }

		public RelayCommand DetailsCommand { get; set; }
		public RelayCommand RefreshCommand { get; set; }
		public RelayCommand RemoveCommand { get; set; }
		public RelayCommand ExportCommand { get; set; }
	}
}
