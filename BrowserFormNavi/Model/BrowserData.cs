using System;

namespace BrowserFormNavi.Model
{
    sealed class BrowserData
    {
        public string URLToLoad;
        public string DOM;

        public BrowserData()
            {
            URLToLoad = "";
            DOM = "";
            }
    }
}
