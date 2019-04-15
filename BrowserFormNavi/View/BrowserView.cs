using BrowserFormNavi.Model;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BrowserFormNavi.View
{
    public partial class BrowserView : Form
    {
        internal delegate void WebBrowserNavigateDelegate(string Url);
        internal delegate void ShowBrowserViewDelegate();
        internal delegate void CleanUpDelegate();
        internal delegate void InitializeComponentDelegate();

        internal delegate object GetPropertyValueDelegate(object instance, string strPropertyName);
        internal delegate void SetPropertyValueDelegate(dynamic instance, string strPropertyName, object newValue);
        internal delegate void GetMethodDelegate(object instance, string strMethodName, object[] arguments);

        public BrowserView()
        {
            InitializeComponent();
        }

        public void WebBrowserNavigate(string Url)
        {
            if (InvokeRequired)
            {
                WebBrowserNavigateDelegate wbn = new WebBrowserNavigateDelegate(WebBrowserNavigate);
                Invoke(wbn, new object[] { Url });
            }
            else
            {
                webBrowser1.Navigate(Url);
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
                Show();
            }
        }

        public void InitializeWebBrowser()
        {
            if (InvokeRequired)
            {
                InitializeComponentDelegate icd = new InitializeComponentDelegate(InitializeComponent);
                Invoke(icd, new object[] { });
            }
            else
            {
                InitializeComponent();
            }
        }


        public void CleanUp()
        {
            if (InvokeRequired)
            {
                CleanUpDelegate cud = new CleanUpDelegate(CleanUp);
                Invoke(cud, new object[] { });
            }
            else
            {
                if (webBrowser1 != null)
                {
                    webBrowser1.Dispose();
                    webBrowser1 = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }


        public object GetPropertyValue(dynamic instance, string strPropertyName)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (instance.InvokeRequired)
            {
                GetPropertyValueDelegate gpvd = new GetPropertyValueDelegate(GetPropertyValue);
                return instance.Invoke(gpvd, new object[] { instance, strPropertyName });
            }
            else
            {
                Type type = instance.GetType();
                PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
                return propertyInfo.GetValue(instance, new object[] { });
            }
        }

        public void SetPropertyValue(dynamic instance, string strPropertyName, object newValue)
        {
            if (instance.InvokeRequired)
            {
                SetPropertyValueDelegate spvd = new SetPropertyValueDelegate(SetPropertyValue);
                instance.Invoke(spvd, new object[] { instance, strPropertyName, newValue });
            }
            else
            {
                Type type = instance.GetType();
                PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
                propertyInfo.SetValue(instance, newValue);
            }
        }

        public void GetMethod(dynamic instance, string strMethodName, object[] arguments)
        {
            if (instance.InvokeRequired)
            {
                GetMethodDelegate gmd = new GetMethodDelegate(GetMethod);
                instance.Invoke(gmd, new object[] { instance, strMethodName, arguments });
            }
            else
            {
                Type type = instance.GetType();
                MethodInfo methodInfo = type.GetMethod(strMethodName);
                methodInfo.Invoke(instance, arguments);
            }
        }
    }
}
