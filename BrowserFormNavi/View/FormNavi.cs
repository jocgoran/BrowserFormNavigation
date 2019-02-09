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
            Program.navigation.CopyFromGridToBrowser();
        }

        private void InvokeFormSubmit(object sender, System.EventArgs e)
        {
            Program.navigation.InvokeSubmit();
        }

        private void checkDBConnection(object sender, System.EventArgs e)
        {
            Program.dBAccess.checkDBConnection();
        }

        private void FillAutoGenData(object sender, System.EventArgs e)
        {
            Program.navigation.AutoFillInputValue();
        }
    }
}
