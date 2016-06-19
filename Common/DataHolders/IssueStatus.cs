using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssueStatus
	{
		[Description("Открыт")]
		Open = 1,
		[Description("В работе")]
		InProgress = 2,
		[Description("Завершен")]
		Closed = 3,
	}
}