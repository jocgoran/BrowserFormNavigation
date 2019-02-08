using System.Windows.Forms;

namespace BrowserFormNavi
{
    public sealed partial class FormNavi : Form
    {
        public FormNavi()
        {
            InitializeComponent();
        }

        private void OpenPage(object sender, System.EventArgs e)
        {
            Program.navigation.OpenPage();
        }

        private void CopyDataToBrowser(object sender, System.EventArgs e)
        {
            Program.writingBrowserForm.CopyDataToBrowser();
        }

        private void InvokeFormSubmit(object sender, System.EventArgs e)
        {
            Program.writingBrowserForm.InvokeFormSubmit();
        }
    }
}
