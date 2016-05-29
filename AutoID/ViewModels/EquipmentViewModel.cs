using System.Collections.ObjectModel;
using System.Windows;
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
			RefreshCommand = new RelayCommand(OnRefresh);
			RemoveCommand = new RelayCommand(OnRemove);
			ExportCommand = new RelayCommand(OnExport);
			FillEquipment();
		}

		void OnExport()
		{
			MessageBox.Show(ExportHelper.MachineList("C:\\", "MachineList", EquipmentList) ? "Экспорт завершён" : "Ошибка экспорта");
		}

		void FillEquipment()
		{
			EquipmentList = new ObservableCollection<MachineViewModel>();
			var entities = MachineWorker.ReadAll();
			foreach (Machine item in entities)
				EquipmentList.Add(EntityViewModelConverter.Convert(item));
			OnPropertyChanged(() => EquipmentList);
		}

		void OnRefresh()
		{
			FillEquipment();
		}

		void OnRemove()
		{
			MachineWorker.RemoveMachine(SelectedMachine.Id);
			EquipmentList.Remove(SelectedMachine);
		}

		public ObservableCollection<MachineViewModel> EquipmentList { get; set; }
		public MachineViewModel SelectedMachine { get; set; }

		public RelayCommand RefreshCommand { get; set; }
		public RelayCommand RemoveCommand { get; set; }
		public RelayCommand ExportCommand { get; set; }
	}
}