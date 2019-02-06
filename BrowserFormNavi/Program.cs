using System;
using System.Windows.Forms;
using BrowserFormNavi.Model;
using BrowserFormNavi.View;
using BrowserFormNavi.Controller;

namespace BrowserFormNavi
{
    static class Program
    {
        public static FormNavi formNavi;
        public static BrowserView browserView;
        public static BrowserData browserData;
        public static Navigation navigation;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            browserData = new BrowserData();           
            navigation = new Navigation();
            Application.Run(formNavi = new FormNavi());
        }
    }
}
