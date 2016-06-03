using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssueType
	{
		[Description ("Поломка")]
		Поломка = 1,
		[Description("Настройка")]
		Настройка = 2,
		[Description("Консультация")]
		Консультация = 3,
		[Description("Аппаратная часть")]
		Аппаратная_часть = 4,
		[Description("Интернет")]
		Интернет = 5,
		[Description("Проблемы с ПО")]
		Проблемы_с_ПО = 6,
	}
}