using System;
using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class SparePartViewModel : BaseViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Article { get; set; }
		public int Quantity { get; set; }
	}
}