using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssuePriority
	{
		[Description ("Высокий")]
		High = 1,
		[Description("Средний")]
		Medium = 2,
		[Description("Низкий")]
		Low = 3,
	}
}