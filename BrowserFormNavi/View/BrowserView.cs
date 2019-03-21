using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrowserFormNavi.View
{
    public partial class BrowserView : Form
    {
        internal delegate HtmlDocument GetHtmlDocumentDelegate();
        internal delegate string GetHtmlDocumentNameDelegate();
        internal delegate string GetHtmlDocumentUrlDelegate();
        internal delegate void SetFormTextDelegate(string text);
        internal delegate void ShowBrowserViewDelegate();
        internal delegate void RefreshBrowserViewDelegate();

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

        public string GetHtmlDocumentName()
        {
            if (webBrowser1.InvokeRequired)
            {
                GetHtmlDocumentNameDelegate gebtnd = new GetHtmlDocumentNameDelegate(GetHtmlDocumentName);
                return (string)webBrowser1.Invoke(gebtnd, new object[] { });
            }
            else
            {
                return webBrowser1.DocumentTitle.ToString();
            }
        }

        public string GetHtmlDocumentUrl()
        {
            if (webBrowser1.InvokeRequired)
            {
                GetHtmlDocumentUrlDelegate gebtud = new GetHtmlDocumentUrlDelegate(GetHtmlDocumentUrl);
                return (string)webBrowser1.Invoke(gebtud, new object[] { });
            }
            else
            {
                return webBrowser1.Url.ToString();
            }
        }

        public void SetFormText(string text)
        {
            if (InvokeRequired)
            {
                SetFormTextDelegate sftd = new SetFormTextDelegate(SetFormText);
                Invoke(sftd, new object[] { text });
            }
            else
            {
                Text = text;
            }
        }

        public void ShowBrowserView()
        {
            if (InvokeRequired)
            {
                ShowBrowserViewDelegate sbw = new ShowBrowserViewDelegate(ShowBrowserView);
                Invoke(sbw, new object[] { });
            }
            else
            {
                this.Show();
            }
        }

        public void RefreshBrowserView()
        {
            if (webBrowser1.InvokeRequired)
            {
                RefreshBrowserViewDelegate rbwd = new RefreshBrowserViewDelegate(RefreshBrowserView);
                Invoke(rbwd, new object[] { });
            }
            else
            {
                webBrowser1.Refresh();
            }
        }
    }
}
