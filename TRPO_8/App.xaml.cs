using System.Configuration;
using System.Data;
using System.Windows;
using TRPO_8.Styles.ClassStyle;

namespace TRPO_8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemeHelper.ApplySaved();
        }
    }

}
