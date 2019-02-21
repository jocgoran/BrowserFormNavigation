using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Model
{
    public class BrowserData
    {
        public bool FormExtracted;

        public BrowserData()
            {
            FormExtracted = false;
            }

        public int GetRowNr(string colName, string searchValue)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // Need to check for null if new row is exposed
                if (row.Cells[colName].Value != null) 
                {
                    // check if the column has the searched value
                    if (row.Cells[colName].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
            }
            return rowIndex;
        }

        public int GetRowNr(int startRowIndex, string colName1, string searchValue1, string colName2, string searchValue2)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // skip the first rows
                if (row.Index < startRowIndex) continue;

                // Need to check for null if new row is exposed
                if (row.Cells[colName1].Value != null) 
                {
                    // check if bothe the columns have the searched values
                    if (row.Cells[colName1].Value.ToString().Equals(searchValue1)
                        &&
                        row.Cells[colName2].Value.ToString().Equals(searchValue2))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
            }
            return rowIndex;
        }
    }
}
