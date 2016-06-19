using Common.Helpers.WPF;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Common.Helpers;
using DAL;
using DAL.Entities;

namespace AutoID.ViewModels
{
	public class SparePartsViewModel : BaseViewModel
	{
		public ObservableCollection<SparePartViewModel> SpareParts { get; set; }

		public SparePartViewModel SelectedSparePart { get; set; }

		public SparePartsViewModel()
		{
			RefreshCommand = new RelayCommand(OnRefresh);
			AddCommand = new RelayCommand(OnAdd);
			EditCommand = new RelayCommand(OnEdit);
			RemoveCommand = new RelayCommand(OnRemove);
			SpareParts = new ObservableCollection<SparePartViewModel>();
			FillSpareParts();
		}

		void FillSpareParts()
		{
			SpareParts = new ObservableCollection<SparePartViewModel>();
			var entities = SparePartsWorker.ReadAll();
			foreach (SparePart item in entities)
				SpareParts.Add(EntityViewModelConverter.Convert(item));
			OnPropertyChanged(() => SpareParts);
		}

		public RelayCommand EditCommand { get; set; }
		void OnEdit()
		{
			throw new System.NotImplementedException();
		}

		public RelayCommand RemoveCommand { get; set; }
		void OnRemove()
		{
			SpareParts.Remove(SelectedSparePart);
			SparePartsWorker.RemoveSparePart(SelectedSparePart.Id);
		}

		public RelayCommand AddCommand { get; set; }
		void OnAdd()
		{
			throw new System.NotImplementedException();
		}

		public RelayCommand RefreshCommand { get; set; }
		void OnRefresh()
		{
			FillSpareParts();
		}
	}
}