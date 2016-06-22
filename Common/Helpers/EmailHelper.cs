using DAL;
using System.Net;
using System.Net.Mail;

namespace Common.Helpers
{
	public class EmailHelper
	{
		public static bool Send(string body, string attachmentString = "")
		{
			var config = ConfigWorker.GetConfig();
			Attachment attachment = null;
			if (!string.IsNullOrEmpty(attachmentString))
			{
				attachment = new Attachment(attachmentString);
				attachment.Name = "Report.xlsx";
			}
			var smtp = new SmtpClient
			{
				Host = config.SMTPServer,
				Port = config.SMTPPort,
				EnableSsl = config.UseSSL,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(config.EmailFrom, config.EmailFromPassword)
			};


			using (var message = new MailMessage(config.EmailFrom, config.EmailTo))
			{
				message.Subject = config.EmailSubject;
				message.Body = body;
				if (attachment != null)
					message.Attachments.Add(attachment);
				smtp.Send(message);
			}
			return true;
		}
	}
}