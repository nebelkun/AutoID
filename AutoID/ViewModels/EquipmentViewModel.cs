using System;
using System.Collections.ObjectModel;
using AutoID.Models;
using Common.Helpers.WPF;
using DAL;
using AutoID.Helpers;

namespace AutoID.ViewModels
{
	public class EquipmentViewModel : BaseViewModel
	{

		public EquipmentViewModel()
		{
			DetailsCommand = new RelayCommand(OnDetails);
			RefreshCommand = new RelayCommand(OnRefresh);
			RemoveCommand = new RelayCommand(OnRemove);
			FillEquipment();
		}

		private void FillEquipment()
		{
			EquipmentList = new ObservableCollection<MachineViewModel>();
			var entities = MachineWorker.ReadAll();
			foreach (Machine item in entities)
			{
				EquipmentList.Add(EntityViewModelConverter.Convert(item));
			}
		}

		private void OnRefresh()
		{
			throw new NotImplementedException();
		}

		private void OnRemove()
		{
			throw new NotImplementedException();
		}

		private void OnDetails()
		{
			throw new NotImplementedException();
		}

		public ObservableCollection<MachineViewModel> EquipmentList { get; set; }
		public Machine SelectedMachine { get; set; }

		public RelayCommand DetailsCommand { get; set; }
		public RelayCommand RefreshCommand { get; set; }
		public RelayCommand RemoveCommand { get; set; }

	}
}
