using System;
using System.Collections.Generic;
using System.Net;
using Common.Helpers.WPF;
using System.Net.Mail;
using DAL.Entities;

namespace AutoID.ViewModels
{
	public class OtherViewModel : BaseViewModel
	{
		public OtherViewModel()
		{

			GenerateFakeDataCommand = new RelayCommand(OnGenerateData);
			ConfigureCommand = new RelayCommand(OnConfigure);
		}

		void OnConfigure()
		{
			throw new NotImplementedException();
		}

		public RelayCommand GenerateFakeDataCommand { get; set; }
		void OnGenerateData()
		{
			for (int i = 0; i < 50; i++)
			{
				DAL.MachineWorker.RegisterMachine(new Machine
				{
					Comment = "Test machine #" +i,
					CPUID = Guid.NewGuid().ToString(),
					Department = "Отдел тестирования",
					HardDriveId = Guid.NewGuid().ToString(),
					Id = Guid.NewGuid(),
					MAC = "98:98:98:98:98",
					Name = "Тестовый компьютер " +i,
					OS = "Windows 7",
					Owner = "Семён Стрельцов",
					Ram = Guid.NewGuid().ToString(),
				});

				DAL.ServiceWorker.NewTask(new Service
				{
					Name = "Замена расходных материалов #"+i,
					Comment = "Нужно заменить расходные материалы в отделе тестирования",
					Id = Guid.NewGuid(),
					AssigneeName = "Михаил Земсков",
					PeriodDays = i+3,
					ReporterName = "Илья Мочалов",
					Services = new List<Task>(),
				});

				DAL.SparePartsWorker.AddSparePart(
					new SparePart
					{
						Id = Guid.NewGuid(),
						Name = "Запасная часть №"+i,
						Article = i.ToString(),
						Quantity = i,
					});

				DAL.TaskWorker.NewTask(new Task
				{
					Name = "Задача №"+i,
					Id = Guid.NewGuid(),
					Comment = "Комментарий к тестовой задаче №"+i,
					ReporterName = "Семён стрельцов",
					AssigneeName = "Михаил Земсков",
					IssueStatus = i%4,
					IssueType = i%7,
					Priority = i%4,
					OpenDate = DateTime.Now,
					No = i,
				});
			}
		}

		public RelayCommand ConfigureCommand { get; set; }
	}
}