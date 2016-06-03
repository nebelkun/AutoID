using Common.Helpers.WPF;
using Common.Helpers;
using DAL;
using System.Windows;
using AutoID.Helpers;
using AutoID.ViewModels;
using AutoIDClient.Views;
using DAL.Entities;

namespace AutoIDClient.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			RegisterCommand = new RelayCommand(OnRegister, CanRegister);
			UpdateCommand = new RelayCommand(OnUpdate, CanUpdate);
			AddTaskCommand = new RelayCommand(OnAddTask);
			CPU = HardwareInfoGetter.GetProcessorId();
			RamVolume = HardwareInfoGetter.GetPhysicalMemory();
			HddSN = HardwareInfoGetter.GetHDDSerialNo();
			OS = HardwareInfoGetter.GetOSInformation();
			MAC = HardwareInfoGetter.GetMACAddress();
			Name = HardwareInfoGetter.GetComputerName();

			Machine = new Machine
			{
				Comment = Comment,
				Department = Department,
				MAC = MAC,
				Owner = Owner,
				Name = Name,
				CPUID = CPU,
				HardDriveId = HddSN,
				OS = OS,
				Ram = RamVolume
			};

			var dbMachine = MachineWorker.GetMachineByCPU(CPU);

			if (dbMachine != null)
			{
				_isRegistered = true;
				Comment = dbMachine.Comment;
				Department = dbMachine.Department;
				MAC = dbMachine.MAC;
				Owner = dbMachine.Owner;
				Name = dbMachine.Name;
				CPU = dbMachine.CPUID;
				HddSN = dbMachine.HardDriveId;
				OS = dbMachine.OS;
				RamVolume = dbMachine.Ram;
			}
		}

		void OnAddTask()
		{
			AddTaskView view = new AddTaskView();
			var vm = new AddTaskViewModel();
			view.DataContext = vm;
			var dialogResult = view.ShowDialog();
			if (dialogResult != null && (bool)dialogResult)
			{
				MessageBox.Show(TaskWorker.NewTask(EntityViewModelConverter.Convert(vm.Task)) ? "Задание добавлено.":"Ошибка добавления задания.");
			}
		}

		bool _isRegistered;

		bool CanUpdate(object obj)
		{
			return _isRegistered;
		}

		bool CanRegister(object obj)
		{
			return !_isRegistered;
		}

		void OnUpdate()
		{
			MachineWorker.UpdateMachine(Machine);
		}

		public Machine Machine { get; set; }

		void OnRegister()
		{
			MessageBox.Show(MachineWorker.RegisterMachine(Machine) ? "Успешно зарегистрировано" : "Ошибка регистрации компьютера");
		}

		public RelayCommand RegisterCommand { get; set; }

		public RelayCommand UpdateCommand { get; set; }

		public RelayCommand AddTaskCommand { get; set; }

		public string CPU { get; set; }
		public string RamVolume { get; set; }
		public string HddSN { get; set; }
		public string OS { get; set; }
		public string MAC { get; set; }
		public string Comment { get; set; }
		public string Department { get; set; }
		public string Owner { get; set; }
		public string Name { get; set; }
	}
}