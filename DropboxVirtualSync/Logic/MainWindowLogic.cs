using System.Windows.Controls;

namespace DropboxVirtualSync.Views
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