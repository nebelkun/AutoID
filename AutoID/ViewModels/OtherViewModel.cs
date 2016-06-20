using System;
using System.Collections.Generic;
using AutoID.Views;
using Common.Helpers.WPF;
using DAL.Entities;

namespace AutoID.ViewModels
{
	public class OtherViewModel : BaseViewModel
	{
		public OtherViewModel()
		{
			GenerateFakeDataCommand = new RelayCommand(OnGenerateData);
			ConfigureEmailCommand = new RelayCommand(OnConfigureEmail);
		}

		void OnConfigureEmail()
		{
			var view = new ConfigureEmailView {DataContext = new ConfigureEmailViewModel()};
			view.ShowDialog();
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
					IssueStatus = i%3,
					IssueType = i%6,
					Priority = i%3,
					OpenDate = DateTime.Now,
					No = i,
				});
			}
		}

		public RelayCommand ConfigureEmailCommand { get; set; }
	}
}