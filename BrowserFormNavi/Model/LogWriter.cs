using System;
using System.IO;
using System.Reflection;
using static BrowserFormNavi.Program;

namespace BrowserFormNavi.Model
{
    public static class LogWriter
    {
        private static string m_exePath = string.Empty;
        public static void LogWrite(LogLevel logLevel, string logMessage)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    { 
                    break;
                    }
                case LogLevel.Warning:
                    { 
                    break;
                    }
                case LogLevel.Info:
                    {
                    // don't write info logs    
                    return;
                    break;
                    }
            }
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!File.Exists(m_exePath + "\\" + "log.txt"))
                File.Create(m_exePath + "\\" + "log.txt");

            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                    AppendLog(logMessage, w);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine(" " + logMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
