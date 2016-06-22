using Common.Helpers.WPF;
using System.Windows;

namespace AutoID.ViewModels
{
	public class AddSparePartViewModel : BaseViewModel
	{

		public string Name { get; set; }
		public string Article { get; set; }
		public int Quantity { get; set; }
		public SparePartViewModel SparePart { get; set; }

		public AddSparePartViewModel(SparePartViewModel model = null)
		{
			SaveCommand = new RelayCommand<Window>(OnSave, CanSave);
			if (model != null)
			{
				Name = model.Name;
				Article = model.Article;
				Quantity = model.Quantity;
			}
		}

		public RelayCommand<Window> SaveCommand { get; set; }

		void OnSave(Window window)
		{
			SparePart = new SparePartViewModel
			{
				Name = Name,
				Article = Article,
				Quantity = Quantity,
			};

			window.DialogResult = true;
			window.Close();
		}

		bool CanSave(Window window)
		{
			return !string.IsNullOrWhiteSpace(Name);
		}
	}
}