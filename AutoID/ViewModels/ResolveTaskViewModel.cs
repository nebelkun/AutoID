using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class ResolveTaskViewModel : BaseViewModel
	{
		public ResolveTaskViewModel(TaskViewModel vm)
		{
			Model = vm;
		}

		public TaskViewModel Model { get; set; }
	}
}
