using System;
using System.Reflection;
using System.Windows.Forms;

namespace BrowserFormNavi.View
{
    public partial class BrowserView : Form
    {
        internal delegate WebBrowserReadyState GetReadyStateDelegate();
        internal delegate HtmlDocument GetHtmlDocumentDelegate();
        internal delegate string GetHtmlDocumentNameDelegate();
        internal delegate string GetHtmlDocumentUrlDelegate();
        internal delegate void ShowBrowserViewDelegate();

        internal delegate object GetPropertyValueDelegate(object instance, string strPropertyName);
        internal delegate void SetPropertyValueDelegate(dynamic instance, string strPropertyName, object newValue);
        internal delegate void GetMethodDelegate(object instance, string strMethodName, object[] arguments);

        public BrowserView()
        {
            InitializeComponent();
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
                //Thread viewerThread = new Thread(delegate ()
                //{
                Show();
                //});

                //viewerThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
                //viewerThread.Start();
                
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
