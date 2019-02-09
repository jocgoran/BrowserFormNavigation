namespace BrowserFormNavi.Controller
{
    sealed class AutomatedFiller
    {

        public int SaveHistoricData()
        {
            return 0;
        }

        public int ReadHistoricData()
        {
            Program.formData.GetHistoricalData();
            return 0;
        }

        public int GetStatisticValue()
        {
            return 0;
        }

    }
}
