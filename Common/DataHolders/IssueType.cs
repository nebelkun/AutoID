using System.ComponentModel;

namespace AutoID.DataHolders
{
	public enum IssueType
	{
		[Description ("Поломка")]
		Break = 1,
		[Description("Настройка")]
		Setup = 2,
		[Description("Консультация")]
		Consultation = 3,
		[Description("Аппаратная часть")]
		Hardware = 4,
		[Description("Сеть")]
		Network = 5,
		[Description("Проблемы с ПО")]
		Software = 6,
	}
}