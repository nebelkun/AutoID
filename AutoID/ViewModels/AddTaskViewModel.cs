using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class AddTaskViewModel : BaseViewModel
	{
		public AddTaskViewModel()
		{
			Task = new TaskItemViewModel();
		}

		public TaskItemViewModel Task { get; set; }
	}
}
