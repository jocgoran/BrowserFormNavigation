using System;
using System.Windows.Forms;
using BrowserFormNavi.Model;
using BrowserFormNavi.View;
using BrowserFormNavi.Controller;
using BrowserFormNavi.Controller.LayeredPrediction;

namespace BrowserFormNavi
{
    public static class Program
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        // Global var to stop the navigation loop from the thread 
        public static bool keepTheNavigationLoopRunning;

        // Controller objects
        public static Automation automation;
        public static Navigation navigation;
        public static HTMLDoc htmlDoc;
        public static Controller.DataGrid dataGrid;
        public static WebMiner webMiner;
        public static Random rnd;

        // Layered prediction
        public static StatisticalPrediction statisticalPrediction;
        public static UIContexter uIComponent;
        public static UserRule userRule;

        // Model Objects
        public static BrowserData browserData;
        public static DBAccess dBAccess;
        public static FormData formData;
        public static PredictedData predictedData;

        // View objects
        public static BrowserView browserView;
        public static FormNavi formNavi;

        // Globalerror code
        public static int error=0;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Controller objects
            automation = new Automation();
            navigation = new Navigation();
            htmlDoc = new HTMLDoc();
            dataGrid = new Controller.DataGrid();
            webMiner = new WebMiner();
            rnd = new Random();

            // Layered prediction
            statisticalPrediction = new StatisticalPrediction();
            uIComponent = new UIContexter();
            userRule = new UserRule();

            // Model Objects
            browserData = new BrowserData();
            dBAccess = new DBAccess();
            formData = new FormData();
            
            // View objects
            //browserView = new BrowserView();

            Application.Run(formNavi = new FormNavi());

        }
    }
}
