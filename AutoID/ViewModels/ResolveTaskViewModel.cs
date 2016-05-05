using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoID.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class ResolveTaskViewModel : BaseViewModel
	{
		public ResolveTaskViewModel(TaskItemViewModel vm)
		{
			Model = vm;
		}

		public TaskItemViewModel Model { get; set; }
	}
}
