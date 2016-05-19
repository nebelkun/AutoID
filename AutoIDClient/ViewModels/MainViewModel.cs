using Common.Helpers.WPF;
using Common.Helpers;
using DAL;
using System.Windows;

namespace AutoIDClient.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			RegisterCommand = new RelayCommand(OnRegister);
			CPU = HardwareInfoGetter.GetProcessorId();
			RamVolume = HardwareInfoGetter.GetPhysicalMemory();
			HddSN = HardwareInfoGetter.GetHDDSerialNo();
			OS = HardwareInfoGetter.GetOSInformation();
			MAC = HardwareInfoGetter.GetMACAddress();
		}

		void OnRegister()
		{
			if (MachineWorker.RegisterMachine())
				MessageBox.Show("Успешно зарегистрировано");
			else
				MessageBox.Show("Ошибка регистрации компьютера");
		}

		public RelayCommand RegisterCommand { get; set; }

		public string CPU { get; set; }
		public string RamVolume { get; set; }
		public string HddSN { get; set; }
		public string OS { get; set; }
		public string MAC { get; set; }
		public string Comment { get; set; }
		public string Department { get; set; }
		public string Owner { get; set; }
	}
}