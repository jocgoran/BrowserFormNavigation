using System;
using System.Windows.Forms;
using BrowserFormNavi.Model;
using BrowserFormNavi.View;
using BrowserFormNavi.Controller;

namespace BrowserFormNavi
{
    static class Program
    {
        // Controller objects
        public static AutomatedFiller automatedFiller;
        public static Navigation navigation;
        public static ReadingBrowserForm readingBrowserForm;
        public static WritingBrowserForm writingBrowserForm;

        // Model Objects
        public static BrowserData browserData;
        public static FormData formData;

        // View objects
        public static BrowserView browserView;
        public static FormNavi formNavi;

        // Globalerror code
        public static int error=0;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Controller objects
            automatedFiller = new AutomatedFiller();
            navigation = new Navigation();
            readingBrowserForm = new ReadingBrowserForm();
            writingBrowserForm = new WritingBrowserForm();

            // Model Objects
            browserData = new BrowserData();
            formData = new FormData();

            // View objects
            browserView = new BrowserView();

            Application.Run(formNavi = new FormNavi());
        }
    }
}
