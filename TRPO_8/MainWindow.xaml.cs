using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPO_8.Pages;
using TRPO_8.Styles.ClassStyle;

namespace TRPO_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }
        private bool _isDarkTheme = false;

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            var resources = Application.Current.Resources.MergedDictionaries;

            // Удаляем текущую тему
            var currentTheme = resources.FirstOrDefault(d =>
                d.Source?.OriginalString.Contains("DefaultColors.xaml") == true ||
                d.Source?.OriginalString.Contains("DarkTheme.xaml") == true);
            if (currentTheme != null)
                resources.Remove(currentTheme);

            // Переключаем
            _isDarkTheme = !_isDarkTheme;
            string themePath = _isDarkTheme
                ? "/Styles/Colors/DarkTheme.xaml"
                : "/Styles/Colors/DefaultColors.xaml";

            resources.Add(new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) });
        }

       
    }
}