using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers.WPF;

namespace AutoIDClient.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			RegisterCommand = new RelayCommand(OnRegister);
		}

		private void OnRegister()
		{
			
		}

		public RelayCommand RegisterCommand { get; set; }

		public string CPU { get; set; }
		public string RamVolume { get; set; }
		public string HddSN { get; set; }
		public string OS { get; set; }
		public string MAC { get; set; }
	}
}