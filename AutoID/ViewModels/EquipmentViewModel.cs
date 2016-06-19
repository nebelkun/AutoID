using System.Collections.ObjectModel;
using System.Windows.Forms;
using Common.Helpers.WPF;
using DAL;
using AutoID.Helpers;
using Common.Helpers;
using DAL.Entities;
using MessageBox = System.Windows.MessageBox;

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
			var dialog = new FolderBrowserDialog
			{
				Description = "Выберите папку для экспорта:",
				ShowNewFolderButton = true,
			};
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show(ExportHelper.MachineList(dialog.SelectedPath, "MachineList", EquipmentList) ? "Экспорт завершён" : "Ошибка экспорта");
			}
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