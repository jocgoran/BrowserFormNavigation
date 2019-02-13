using System.ComponentModel;
using System.Windows.Forms;

namespace BrowserFormNavi
{
    delegate void EnableButtonDelegate(Button button, bool enable);
    delegate string GetComboBoxSelectedItemDelegate(ComboBox comboBoxName);
    delegate int GetComboBoxSelectedIndexDelegate(ComboBox comboBoxName);
    delegate void SetDataGridCellDelegate(DataGridViewRow row, string colName, string value);
    delegate string GetDataGridCellDelegate(DataGridViewRow row, string colName);
    delegate void DataGridViewClearDelegate();
    delegate void ComboBoxClearDelegate(ComboBox comboBoxName);
    delegate void EnableComboBoxDelegate(ComboBox comboBoxName, bool enable);

    public partial class FormNavi : Form
    {
        public FormNavi()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
            backgroundWorker1.WorkerSupportsCancellation = true; //Allow for the process to be cancelled
        }

        private void OpenPage(object sender, System.EventArgs e)
        {
            Program.navigation.OpenPage();
        }

        private void CopyDataToBrowser(object sender, System.EventArgs e)
        {
            Program.navigation.CopyFromGridToBrowser();
        }

        private void InvokeFormSubmit(object sender, System.EventArgs e)
        {
            Program.navigation.InvokeSubmit();
        }

        private void CheckDBConnection(object sender, System.EventArgs e)
        {
            Program.dBAccess.CheckDBConnection();
        }

        private void FillAutoGenData(object sender, System.EventArgs e)
        {
            Program.navigation.AutoFillInputValue();
        }

        private void SaveBrowserFilledDataToDatabase(object sender, System.EventArgs e)
        {
            Program.navigation.SaveBrowserFilledValuesToDatabase();
        }

        private void StopTheNavigation(object sender, System.EventArgs e)
        {
            int error=Program.navigation.StopTheNavigationLoop();
            if(error==0)
            { 
                //Check if background worker is doing anything and send a cancellation if it is
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
            }
        }

        // This event handler deals with the results of the
        // background operation.
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButton(buttonStart, true);
            EnableButton(buttonStop, false);
            EnableButton(FillAutoGenertedData, true);
            EnableButton(CopyToBrowser, true);
            EnableButton(SaveBrowserValuesToDB, true);
            EnableButton(Go, true);
            EnableButton(Submit, true);
            EnableComboBox(comboBox2, true);
        }

        private void StartTheNavigation(object sender, System.EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // FormNavi.Invoke(FormNavi.button5.Enable = false);         
            EnableButton(buttonStart, false);
            EnableButton(buttonStop, true);
            EnableButton(FillAutoGenertedData, false);
            EnableButton(CopyToBrowser, false);
            EnableButton(SaveBrowserValuesToDB, false);
            EnableButton(Go, false);
            EnableButton(Submit, false);
            EnableComboBox(comboBox2, false);
            Program.navigation.StartTheNavigationLoop();
        }

        private void EnableButton(Button button, bool enable)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (button.InvokeRequired)
            {
                EnableButtonDelegate ebd = new EnableButtonDelegate(EnableButton);
                button.Invoke(ebd, new object[] { button, enable });
            }
            else
            {
                button.Enabled = enable;
            }
        }

        public string GetComboBoxSelectedItem(ComboBox comboBoxName)
        {
            if (comboBoxName.InvokeRequired)
            {
                GetComboBoxSelectedItemDelegate gsid = new GetComboBoxSelectedItemDelegate(GetComboBoxSelectedItem);
                return (string)comboBoxName.Invoke(gsid, new object[] { comboBoxName });
            }
            else
            {
                return comboBoxName.SelectedItem.ToString();
            }
        }

        public int GetComboBoxSelectedIndex(ComboBox comboBoxName)
        {
            if (comboBoxName.InvokeRequired)
            {
                GetComboBoxSelectedIndexDelegate gsid = new GetComboBoxSelectedIndexDelegate(GetComboBoxSelectedIndex);
                return (int)comboBoxName.Invoke(gsid, new object[] { comboBoxName });
            }
            else
            {
                return comboBoxName.SelectedIndex;
            }
        }

        public void SetDataGridCell(DataGridViewRow row, string colName, string value)
        {
            if (dataGridView1.InvokeRequired)
            {
                SetDataGridCellDelegate sdgcd = new SetDataGridCellDelegate(SetDataGridCell);
                dataGridView1.Invoke(sdgcd, new object[] { row, colName, value});
            }
            else
            {
                row.Cells[colName].Value = value;
            }
        }

        public string GetDataGridCell(DataGridViewRow row, string colName)
        {
            if (Program.formNavi.dataGridView1.InvokeRequired)
            {
                GetDataGridCellDelegate gdgcd = new GetDataGridCellDelegate(GetDataGridCell);
                return (string)Program.formNavi.dataGridView1.Invoke(gdgcd, new object[] { row, colName });
            }
            else
            {
                return row.Cells[colName].Value.ToString();
            }
        }

        public void DataGridViewClear()
        {
            if (dataGridView1.InvokeRequired)
            {
                DataGridViewClearDelegate dgwcl = new DataGridViewClearDelegate(DataGridViewClear);
                dataGridView1.Invoke(dgwcl, new object[] { });
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        public void ComboBoxClear(ComboBox comboBoxName)
        {
            if (comboBoxName.InvokeRequired)
            {
                ComboBoxClearDelegate cbcd = new ComboBoxClearDelegate(ComboBoxClear);
                comboBoxName.Invoke(cbcd, new object[] { });
            }
            else
            {
                comboBoxName.Items.Clear();
            }
        }

        public void EnableComboBox(ComboBox comboBoxName, bool enable)
        {
            if (comboBoxName.InvokeRequired)
            {
                EnableComboBoxDelegate ebd = new EnableComboBoxDelegate(EnableComboBox);
                comboBoxName.Invoke(ebd, new object[] { comboBoxName, enable });
            }
            else
            {
                comboBoxName.Enabled = enable;
            }
        }
    }
}
