using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrowserFormNavi.View
{
    public partial class BrowserView : Form
    {
        delegate HtmlDocument GetHtmlDocumentDelegate();
        public BrowserView()
        {
            InitializeComponent();
        }

        public HtmlDocument GetHtmlDocument()
        {
            if (webBrowser1.InvokeRequired)
            {
                GetHtmlDocumentDelegate gebtnd = new GetHtmlDocumentDelegate(GetHtmlDocument);
                return (HtmlDocument)webBrowser1.Invoke(gebtnd, new object[] {});
            }
            else
            {
                return webBrowser1.Document;
            }
        }
    }
}
