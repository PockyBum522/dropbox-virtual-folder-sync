using System.Windows.Controls;
using Microsoft.Win32;

namespace DropboxVirtualSync.Logic
{
    public class MainWindowLogic
    {
        public MainWindowLogic()
        {
        }

        internal static void SwitchTextContents(TextBox textBoxA, TextBox textBoxB)
        {
            var originalDestinationText = textBoxA.Text;

            textBoxA.Text = textBoxB.Text;

            textBoxB.Text = originalDestinationText;
        }
    }
}