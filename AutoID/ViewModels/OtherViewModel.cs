using Common.Helpers.WPF;
using System.Net.Mail;

namespace AutoID.ViewModels
{
	public class OtherViewModel : BaseViewModel
	{
		public string Email { get; set; }

		public string Subject { get; set; }

		public string Body { get; set; }

		public OtherViewModel()
		{
			Email = "dreamwalkerzmm@gmail.com";
			Subject = "Уведомнение AutoID";
			Body = "/n/n С уважением, клиентское приложение AutoID.";
			SendEmailCommand = new RelayCommand(OnSendEmail);
			GenerateFakeDataCommand = new RelayCommand(OnGenerateData);
		}

		public RelayCommand SendEmailCommand { get; set; }
		void OnSendEmail()
		{
			MailMessage mail = new MailMessage("NebelKun@AutoID.com", Email);
			SmtpClient client = new SmtpClient
			{
				Port = 25,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				Host = "smtp.o2.ie"
			};
			mail.Subject = Subject;
			mail.Body = Body;
			client.Send(mail);
		}

		public RelayCommand GenerateFakeDataCommand { get; set; }
		void OnGenerateData()
		{
			throw new System.NotImplementedException();
		}


	}
}
}
