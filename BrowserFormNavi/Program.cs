using System;
using System.Windows.Forms;
using BrowserFormNavi.Model;
using BrowserFormNavi.View;
using BrowserFormNavi.Controller;

namespace BrowserFormNavi
{
    public static class Program
    {
        // Global var to stop the navigation loop from the thread 
        public static bool keepTheNavigationLoopRunning;

        // Controller objects
        public static AutomatedFiller automatedFiller;
        public static Navigation navigation;
        public static ReadingBrowserForm readingBrowserForm;
        public static WritingBrowserForm writingBrowserForm;
        public static SpecialSubmitter specialSubmitter;
        public static WebMiner webMiner;
        public static Random rnd;

        // Model Objects
        public static BrowserData browserData;
        public static DBAccess dBAccess;
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
            specialSubmitter = new SpecialSubmitter();
            webMiner = new WebMiner();
            rnd = new Random();

            // Model Objects
            browserData = new BrowserData();
            dBAccess = new DBAccess();
            formData = new FormData();

            // View objects
            browserView = new BrowserView();

            Application.Run(formNavi = new FormNavi());
        }
    }
}
