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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.button5 = new System.Windows.Forms.Button();
            this.BFN_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.comboBox1.Text = "https://sdp.newaccess.ch";
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
            this.Tag,
            this.Action1,
            this.Type,
            this.Name,
            this.ID,
            this.Value,
            this.Checked});
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
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 578);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perform recursively automated";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(156, -1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 22);
            this.button5.TabIndex = 11;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.StartTheNavigation);
            // 
            // BFN_ID
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            this.BFN_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.BFN_ID.FillWeight = 50F;
            this.BFN_ID.Frozen = true;
            this.BFN_ID.HeaderText = "BFN_ID";
            this.BFN_ID.Name = "BFN_ID";
            this.BFN_ID.ReadOnly = true;
            this.BFN_ID.Width = 50;
            // 
            // FormID
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            this.FormID.DefaultCellStyle = dataGridViewCellStyle2;
            this.FormID.FillWeight = 50F;
            this.FormID.Frozen = true;
            this.FormID.HeaderText = "FormID";
            this.FormID.Name = "FormID";
            this.FormID.ReadOnly = true;
            this.FormID.Width = 50;
            // 
            // Tag
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            this.Tag.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tag.Frozen = true;
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            // 
            // Action1
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray;
            this.Action1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Action1.Frozen = true;
            this.Action1.HeaderText = "Action";
            this.Action1.Name = "Action1";
            this.Action1.ReadOnly = true;
            // 
            // Type
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray;
            this.Type.DefaultCellStyle = dataGridViewCellStyle5;
            this.Type.Frozen = true;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Name
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray;
            this.Name.DefaultCellStyle = dataGridViewCellStyle6;
            this.Name.Frozen = true;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // ID
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray;
            this.ID.DefaultCellStyle = dataGridViewCellStyle7;
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.Frozen = true;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // Checked
            // 
            this.Checked.Frozen = true;
            this.Checked.HeaderText = "Checked";
            this.Checked.Name = "Checked";
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
            this.Text = "Automated formular extractor and formular submitter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button FillAutoGenertedData;
        private System.Windows.Forms.Button btnCheckDBConnection;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private DataGridViewTextBoxColumn BFN_ID;
        private DataGridViewTextBoxColumn FormID;
        private new DataGridViewTextBoxColumn Tag;
        private DataGridViewTextBoxColumn Action1;
        private DataGridViewTextBoxColumn Type;
        private new DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Checked;
    }
}

