using System.Net;
using System.Net.Mail;
using DAL;

namespace Common.Helpers
{
	public class EmailHelper
	{
		public static bool Send(string body, string attachmentString = "")
		{
			var config = ConfigWorker.GetConfig();
			System.Net.Mail.Attachment attachment = null;
			if (!string.IsNullOrEmpty(attachmentString))
			{
				attachment = new System.Net.Mail.Attachment(attachmentString);
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
			using (var message = new MailMessage(config.EmailFrom, config.EmailTo)
			{
				Subject = config.EmailSubject,
				Body = body,
				Attachments = { attachment },
			})
			{
				smtp.Send(message);
			}
			return true;
		}
	}
}