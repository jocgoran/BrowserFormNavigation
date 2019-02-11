using BrowserFormNavi.Controller;
using System.Windows.Forms;

namespace BrowserFormNavi
{
    public partial class FormNavi : Form
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
            Program.dBAccess.CheckDBConnection();
        }

        private void FillAutoGenData(object sender, System.EventArgs e)
        {
            Program.navigation.AutoFillInputValue();
        }

        private void SaveBrowserFilledDataToDatabase(object sender, System.EventArgs e)
        {
            Program.navigation.SaveBrowserFilledValuesToDatabase();
        }

        private void StopTheNavigation(object sender, System.EventArgs e)
        {
            Program.navigation.StopTheNavigationLoop();
        }

        private void StartTheNavigation(object sender, System.EventArgs e)
        {
            this.button5.Enabled = false;
            Program.navigation.StartTheNavigationLoop();
            this.button5.Enabled = true;
        }

    }
}
