using Common.Helpers.WPF;

namespace AutoID.ViewModels
{
	public class ConfigViewModel:BaseViewModel
	{
		public string SMTPServer { get; set; }
		public int SMTPPort { get; set; }
		public bool UseSSL { get; set; }
		public string EmailTo { get; set; }
		public string EmailFrom { get; set; }
		public string EmailFromPassword { get; set; }
		public string EmailSubject { get; set; }
	}
}
