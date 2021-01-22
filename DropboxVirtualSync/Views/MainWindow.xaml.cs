using System;
using System.Windows;
using DropboxVirtualSync.DokanyNetMirrorSample;
using DropboxVirtualSync.Logistics;

namespace DropboxVirtualSync.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow //: Window
    {
        private LazyLocalization _lazyLocalization;

        public MainWindow()
        {
            InitializeComponent();
            PrefillTextboxesPerLocalUsername();
        }

        private void MirrorStartButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Inject this so we can get the text from gui textboxes
            var doakanyProgram = new DoakanyProgram(this);
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
    }
}