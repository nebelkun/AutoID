using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssuePriority
	{
		[Description ("Высокий")]
		High = 0,
		[Description("Средний")]
		Medium = 1,
		[Description("Низкий")]
		Low = 2,
	}
}