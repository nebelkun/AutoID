using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssuePriority
	{
		[Description ("Высокий")]
		Высокий = 1,
		[Description("Средний")]
		Средний = 2,
		[Description("Низкий")]
		Низкий = 3,
	}
}