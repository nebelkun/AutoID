using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssueStatus
	{
		[Description("Открыт")]
		Открыт = 1,
		[Description("В работе")]
		В_работе = 2,
		[Description("Завершен")]
		Завершен = 3,
	}
}