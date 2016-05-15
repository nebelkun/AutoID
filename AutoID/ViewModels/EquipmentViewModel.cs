using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoID.Models;

namespace AutoID.ViewModels
{
	public class EquipmentViewModel
	{

		public EquipmentViewModel()
		{
			
		}
		public ObservableCollection<Machine> EquipmentList { get; set; }
		public Machine SelectedMachine { get; set; }


	}
}
