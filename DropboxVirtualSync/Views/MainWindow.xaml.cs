using System;
using System.Windows;

namespace DropboxVirtualSync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow //: Window
    {
        private readonly LazyLocalization _lazyLocalization;

        public MainWindow()
        {
            InitializeComponent();

            _lazyLocalization = new LazyLocalization(this);
        }

        private void MirrorStartButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MirrorStopButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}