using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssueType
	{
		[Description ("Поломка")]
		Break = 0,
		[Description("Настройка")]
		Setup = 1,
		[Description("Консультация")]
		Consultation = 2,
		[Description("Сеть")]
		Network = 3,
		[Description("Аппаратная часть")]
		Hardware = 4,
		[Description("Проблемы с ПО")]
		Software = 5,
	}
}