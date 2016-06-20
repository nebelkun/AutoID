using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.Helpers;
using Common.Helpers.WPF;
using DAL;
using DAL.Entities;

namespace AutoID.ViewModels
{
	public class ConfigureEmailViewModel: BaseViewModel
	{
		public ConfigureEmailViewModel()
		{
			SaveCommand = new RelayCommand<Window>(OnSave, CanSave);
			Config = ConfigWorker.GetConfig() ?? new Config();
		}

		private bool CanSave(Window obj)
		{
			return !string.IsNullOrEmpty(Config.EmailFrom) && !string.IsNullOrEmpty(Config.EmailTo) &&
			       !string.IsNullOrEmpty(Config.SMTPServer);
		}

		public Config Config { get; set; }

		private void OnSave(Window obj)
		{
			ConfigWorker.EditConfig(Config);
			obj.Close();
		}

		public RelayCommand<Window> SaveCommand { get; set; }

	}
}
