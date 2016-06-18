using Common.Helpers.WPF;
using System.Collections.Generic;

namespace AutoID.ViewModels
{
	public class SparePartsViewModel : BaseViewModel
	{
		public List<SparePartViewModel> SpareParts { get; set; }

		public SparePartViewModel SelectedSparePart { get; set; }

		public SparePartsViewModel()
		{

		}


	}
}
