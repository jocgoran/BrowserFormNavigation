using System.Drawing;
using System.Windows.Forms;

namespace BrowserFormNavi
{
    public partial class FormNavi
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.FillAutoGenertedData = new System.Windows.Forms.Button();
            this.btnCheckDBConnection = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BFN_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckedAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(804, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Url to navigate";
            this.comboBox1.Items.Add("https://sdp.newaccess.ch/");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(830, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenPage);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BFN_ID,
            this.FormID,
            this.TagAttribute,
            this.ActionAttribute,
            this.TypeAttribute,
            this.NameAttribute,
            this.IDAttribute,
            this.ValueAttribute,
            this.CheckedAttribute});
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 510);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 657);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Invoke Submit Form";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(126, 654);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(62, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.InvokeFormSubmit);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(179, 613);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 27);
            this.button3.TabIndex = 6;
            this.button3.Text = "Copy to browser";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CopyDataToBrowser);
            // 
            // FillAutoGenertedData
            // 
            this.FillAutoGenertedData.Location = new System.Drawing.Point(22, 613);
            this.FillAutoGenertedData.Name = "FillAutoGenertedData";
            this.FillAutoGenertedData.Size = new System.Drawing.Size(151, 27);
            this.FillAutoGenertedData.TabIndex = 7;
            this.FillAutoGenertedData.Text = "Fill auto generted data";
            this.FillAutoGenertedData.UseVisualStyleBackColor = true;
            this.FillAutoGenertedData.Click += new System.EventHandler(this.FillAutoGenData);
            // 
            // btnCheckDBConnection
            // 
            this.btnCheckDBConnection.Location = new System.Drawing.Point(810, 570);
            this.btnCheckDBConnection.Name = "btnCheckDBConnection";
            this.btnCheckDBConnection.Size = new System.Drawing.Size(123, 27);
            this.btnCheckDBConnection.TabIndex = 8;
            this.btnCheckDBConnection.Text = "Check DB Connection";
            this.btnCheckDBConnection.UseVisualStyleBackColor = true;
            this.btnCheckDBConnection.Click += new System.EventHandler(this.checkDBConnection);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(283, 613);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 27);
            this.button4.TabIndex = 9;
            this.button4.Text = "Save browser values to database";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SaveBrowserFilledDataToDatabase);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 578);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perform recursively automated";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(216, -1);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 22);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.StopTheNavigation);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(156, -1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(54, 22);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.StartTheNavigation);
            // 
            // BFN_ID
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray;
            this.BFN_ID.DefaultCellStyle = dataGridViewCellStyle8;
            this.BFN_ID.FillWeight = 50F;
            this.BFN_ID.Frozen = true;
            this.BFN_ID.HeaderText = "BFN_ID";
            this.BFN_ID.Name = "BFN_ID";
            this.BFN_ID.ReadOnly = true;
            this.BFN_ID.Width = 50;
            // 
            // FormID
            // 
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray;
            this.FormID.DefaultCellStyle = dataGridViewCellStyle9;
            this.FormID.FillWeight = 50F;
            this.FormID.Frozen = true;
            this.FormID.HeaderText = "FormID";
            this.FormID.Name = "FormID";
            this.FormID.ReadOnly = true;
            this.FormID.Width = 50;
            // 
            // TagAttribute
            // 
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gray;
            this.TagAttribute.DefaultCellStyle = dataGridViewCellStyle10;
            this.TagAttribute.Frozen = true;
            this.TagAttribute.HeaderText = "Tag";
            this.TagAttribute.Name = "TagAttribute";
            this.TagAttribute.ReadOnly = true;
            // 
            // ActionAttribute
            // 
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Gray;
            this.ActionAttribute.DefaultCellStyle = dataGridViewCellStyle11;
            this.ActionAttribute.Frozen = true;
            this.ActionAttribute.HeaderText = "Action";
            this.ActionAttribute.Name = "ActionAttribute";
            this.ActionAttribute.ReadOnly = true;
            // 
            // TypeAttribute
            // 
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Gray;
            this.TypeAttribute.DefaultCellStyle = dataGridViewCellStyle12;
            this.TypeAttribute.Frozen = true;
            this.TypeAttribute.HeaderText = "Type";
            this.TypeAttribute.Name = "TypeAttribute";
            this.TypeAttribute.ReadOnly = true;
            // 
            // NameAttribute
            // 
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Gray;
            this.NameAttribute.DefaultCellStyle = dataGridViewCellStyle13;
            this.NameAttribute.Frozen = true;
            this.NameAttribute.HeaderText = "Name";
            this.NameAttribute.Name = "NameAttribute";
            this.NameAttribute.ReadOnly = true;
            // 
            // IDAttribute
            // 
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Gray;
            this.IDAttribute.DefaultCellStyle = dataGridViewCellStyle14;
            this.IDAttribute.Frozen = true;
            this.IDAttribute.HeaderText = "ID";
            this.IDAttribute.Name = "IDAttribute";
            this.IDAttribute.ReadOnly = true;
            // 
            // ValueAttribute
            // 
            this.ValueAttribute.Frozen = true;
            this.ValueAttribute.HeaderText = "Value";
            this.ValueAttribute.Name = "ValueAttribute";
            // 
            // CheckedAttribute
            // 
            this.CheckedAttribute.Frozen = true;
            this.CheckedAttribute.HeaderText = "Checked";
            this.CheckedAttribute.Name = "CheckedAttribute";
            // 
            // FormNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 698);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCheckDBConnection);
            this.Controls.Add(this.FillAutoGenertedData);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNavi";
            this.Text = "Automated formular extractor and formular submitter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button FillAutoGenertedData;
        private System.Windows.Forms.Button btnCheckDBConnection;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button buttonStop;
        private DataGridViewTextBoxColumn BFN_ID;
        private DataGridViewTextBoxColumn FormID;
        private DataGridViewTextBoxColumn TagAttribute;
        private DataGridViewTextBoxColumn ActionAttribute;
        private DataGridViewTextBoxColumn TypeAttribute;
        private DataGridViewTextBoxColumn NameAttribute;
        private DataGridViewTextBoxColumn IDAttribute;
        private DataGridViewTextBoxColumn ValueAttribute;
        private DataGridViewTextBoxColumn CheckedAttribute;
    }
}

