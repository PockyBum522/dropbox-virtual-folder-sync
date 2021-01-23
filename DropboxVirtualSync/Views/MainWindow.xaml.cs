using System;
using System.Windows;
using System.Windows.Controls;
using DropboxVirtualSync.Dokany;
using DropboxVirtualSync.Logistics;

namespace DropboxVirtualSync.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private LazyLocalization _lazyLocalization;
        private readonly MainWindowLogic _mainWindowLogic;

        public MainWindow()
        {
            InitializeComponent();
            PrefillTextboxesPerLocalUsername();
            _mainWindowLogic = new MainWindowLogic();
        }

        private void MirrorStartButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Inject this so we can get the text from gui textboxes
            var doakanyProgram = new MirrorSample(this);
            
            doakanyProgram.MountMirror();
        }

        private void MirrorStopButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void PrefillTextboxesPerLocalUsername()
        {
            // Inject this into LazyLocalization so we can get references to the textboxes to fill them
            _lazyLocalization = new LazyLocalization(this);
            _lazyLocalization.AddTextBoxPrefillPerUsername();
        }

        private void SwapTextboxButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindowLogic.SwitchTextContents(SourcePathTextBox, DestinationPathTextBox);
        }

        private void BrowseSourceButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BrowseDestinationButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}