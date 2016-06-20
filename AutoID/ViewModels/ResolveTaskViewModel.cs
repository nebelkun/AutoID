using System.Windows;
using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class ResolveTaskViewModel : BaseViewModel
	{
		public ResolveTaskViewModel(TaskViewModel vm)
		{
			Model = vm;
			ResolveCommand = new RelayCommand<Window>(OnResolveCommand);
		}

		public string Name { get; set; }
		public string Comment { get; set; }

		void OnResolveCommand(Window obj)
		{
			obj.DialogResult = true;
			obj.Close();
		}

		public TaskViewModel Model { get; set; }

		public RelayCommand<Window> ResolveCommand { get; set; }
	}
}
