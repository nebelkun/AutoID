using Common.Helpers.WPF;

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
