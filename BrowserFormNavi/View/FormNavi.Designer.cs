using System.Drawing;

namespace BrowserFormNavi
{
    sealed partial class FormNavi
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
            this.BFN_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAttr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.FillAutoGenertedData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BFN_ID,
            this.FormID,
            this.Tag,
            this.Action1,
            this.Type1,
            this.NameAttr,
            this.ID,
            this.Value,
            this.Checked});
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 510);
            this.dataGridView1.TabIndex = 2;
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
            // Tag
            // 
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gray;
            this.Tag.DefaultCellStyle = dataGridViewCellStyle10;
            this.Tag.Frozen = true;
            this.Tag.HeaderText = "Tag";
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            // 
            // Action1
            // 
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Gray;
            this.Action1.DefaultCellStyle = dataGridViewCellStyle11;
            this.Action1.Frozen = true;
            this.Action1.HeaderText = "Action";
            this.Action1.Name = "Action1";
            this.Action1.ReadOnly = true;
            // 
            // Type1
            // 
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Gray;
            this.Type1.DefaultCellStyle = dataGridViewCellStyle12;
            this.Type1.Frozen = true;
            this.Type1.HeaderText = "Type";
            this.Type1.Name = "Type1";
            this.Type1.ReadOnly = true;
            // 
            // NameAttr
            // 
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Gray;
            this.NameAttr.DefaultCellStyle = dataGridViewCellStyle13;
            this.NameAttr.Frozen = true;
            this.NameAttr.HeaderText = "Name";
            this.NameAttr.Name = "NameAttr";
            this.NameAttr.ReadOnly = true;
            // 
            // ID
            // 
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Gray;
            this.ID.DefaultCellStyle = dataGridViewCellStyle14;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 617);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Invoke Submit Form";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(116, 614);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 612);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.InvokeFormSubmit);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(228, 573);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 27);
            this.button3.TabIndex = 6;
            this.button3.Text = "Copy to browser";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CopyDataToBrowser);
            // 
            // FillAutoGenertedData
            // 
            this.FillAutoGenertedData.Location = new System.Drawing.Point(12, 573);
            this.FillAutoGenertedData.Name = "FillAutoGenertedData";
            this.FillAutoGenertedData.Size = new System.Drawing.Size(200, 27);
            this.FillAutoGenertedData.TabIndex = 7;
            this.FillAutoGenertedData.Text = "Fill auto generted data";
            this.FillAutoGenertedData.UseVisualStyleBackColor = true;
            this.FillAutoGenertedData.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 690);
            this.Controls.Add(this.FillAutoGenertedData);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "FormNavi";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BFN_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameAttr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Checked;
        private System.Windows.Forms.Button FillAutoGenertedData;
    }
}

