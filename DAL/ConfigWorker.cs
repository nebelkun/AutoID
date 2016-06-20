using System.Linq;
using DAL.Entities;

namespace DAL
{
	public class ConfigWorker
	{
		public static Config GetConfig()
		{
			using (var db = new AutoIDContext())
			{
				return (from m in db.Configs
						select m).FirstOrDefault();
			}
		}

		public static bool EditConfig(Config config)
		{
			using (var db = new AutoIDContext())
			{
				var entity = (from m in db.Configs
							  select m).FirstOrDefault();
				if (entity != null)
				{
					entity.EmailFrom = config.EmailFrom;
					entity.EmailFromPassword = config.EmailFromPassword;
					entity.EmailTo = config.EmailTo;
					entity.SMTPPort = config.SMTPPort;
					entity.SMTPServer = config.SMTPServer;
					entity.UseSSL = config.UseSSL;
					entity.EmailSubject = config.EmailSubject;
				}
				else
				{
					db.Configs.Add(config);
				}
				return db.SaveChanges() > 0;
			}
		}
	}
}