using System;
using System.Collections.Generic;
using Common.Helpers.WPF;
using DAL.Entities;

namespace AutoID.ViewModels
{
	public class ServiceViewModel : BaseViewModel
	{
		public Guid Id { get; set; }
		public int PeriodDays { get; set; }
		public string Name { get; set; }
		public string Comment { get; set; }
		public string ReporterName { get; set; }
		public string AssigneeName { get; set; }
		public List<TaskViewModel> Services { get; set; }
	}
}
