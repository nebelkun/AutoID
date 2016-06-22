using AutoID.Views;
using Common.Helpers;
using Common.Helpers.WPF;
using DAL;
using DAL.Entities;
using System.Collections.ObjectModel;

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
			AddSparePartView view = new AddSparePartView();
			var vm = new AddSparePartViewModel(SelectedSparePart);
			view.DataContext = vm;
			var dialogResult = view.ShowDialog();
			if (dialogResult != null && (bool)dialogResult)
			{
				SparePartsWorker.EditSparePart(EntityViewModelConverter.Convert(vm.SparePart));
			}
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
			AddSparePartView view = new AddSparePartView();
			var vm = new AddSparePartViewModel();
			view.DataContext = vm;
			var dialogResult = view.ShowDialog();
			if (dialogResult != null && (bool)dialogResult)
			{
				SpareParts.Add(vm.SparePart);
				SparePartsWorker.AddSparePart(EntityViewModelConverter.Convert(vm.SparePart));
			}
		}

		public RelayCommand RefreshCommand { get; set; }
		void OnRefresh()
		{
			FillSpareParts();
		}
	}
}