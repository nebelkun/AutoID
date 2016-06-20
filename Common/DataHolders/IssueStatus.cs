using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssueStatus
	{
		[Description("Открыт")]
		Open = 0,
		[Description("В работе")]
		InProgress = 1,
		[Description("Завершен")]
		Closed = 2,
	}
}