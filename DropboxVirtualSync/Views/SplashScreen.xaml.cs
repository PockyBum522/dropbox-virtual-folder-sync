using System.Windows;
using System.Windows.Controls;

namespace DropboxVirtualSync.Views
{
    public partial class SplashScreen
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreenContinueButton_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Hide();
            mainWindow.Show();
        }
    }
}