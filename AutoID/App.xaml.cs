using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoID
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
	{
	    void Application_Startup(object sender, StartupEventArgs e)
		{
			Application.Current.Resources.MergedDictionaries.Add(LoadComponent(
													 new Uri("AutoID;component/DataTemplates/DataTemplates.xaml", UriKind.Relative)) as ResourceDictionary);
		}
	}

}
