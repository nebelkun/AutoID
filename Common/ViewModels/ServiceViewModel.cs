using System;
using System.Collections.Generic;
using System.Linq;
using Common.Helpers.WPF;

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
		public DateTime LastTimeServiced { get
		{
			var taskViewModel = Services.OrderByDescending(x => x.ClosedDate).FirstOrDefault();
			if (taskViewModel?.ClosedDate != null) return (DateTime) taskViewModel.ClosedDate;
			return DateTime.MinValue;
		}
		}
		public List<TaskViewModel> Services { get; set; }
	}
}
