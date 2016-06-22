using Common.Helpers.WPF;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AutoID.ViewModels
{
	public class AddEditServiceViewModel : BaseViewModel
	{

		public string ReporterName { get; set; }

		public int PeriodDays { get; set; }

		public Guid Id { get; set; }

		public string Comment { get; set; }

		public string AssigneeName { get; set; }
		public string Name { get; set; }
		public ServiceViewModel Service { get; set; }
		public AddEditServiceViewModel(ServiceViewModel model = null)
		{
			Id = Guid.NewGuid();
			if (model != null)
			{
				Name = model.Name;
				AssigneeName = model.AssigneeName;
				Comment = model.Comment;
				Id = model.Id;
				PeriodDays = model.PeriodDays;
				ReporterName = model.ReporterName;
			}

			SaveCommand = new RelayCommand<Window>(OnSave, CanSave);

		}

		public RelayCommand<Window> SaveCommand { get; set; }
		void OnSave(Window window)
		{
			Service = new ServiceViewModel
			{
				Name = Name,
				AssigneeName = AssigneeName,
				Comment = Comment,
				Id = Id,
				PeriodDays = PeriodDays,
				ReporterName = ReporterName,
				Services = new List<TaskViewModel>()
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