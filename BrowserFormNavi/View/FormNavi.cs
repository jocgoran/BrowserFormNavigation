using System.Windows.Forms;
using BrowserFormNavi.Controller;

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
    }
}
