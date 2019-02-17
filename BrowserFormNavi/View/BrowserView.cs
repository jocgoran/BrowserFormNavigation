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
                GetHtmlDocumentUrlDelegate gebtud = new GetHtmlDocumentUrlDelegate(GetHtmlDocumentName);
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
    }
}
