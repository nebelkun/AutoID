using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoID.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class AddTaskViewModel:BaseViewModel
	{
		public AddTaskViewModel()
		{
			Task  = new TaskItemViewModel();
		}

		public TaskItemViewModel Task { get; set; }
	}
}
