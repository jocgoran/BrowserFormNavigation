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
            comboBox1 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            label1 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(12, 13);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(804, 21);
            comboBox1.TabIndex = 0;
            comboBox1.Text= "https://sdp.newaccess.ch";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(830, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(93, 22);
            button1.TabIndex = 1;
            button1.Text = "Go";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(OpenPage);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 54);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(921, 510);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 583);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 13);
            label1.TabIndex = 3;
            label1.Text = "Invoke Submit Form";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(128, 575);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(121, 21);
            comboBox2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(266, 575);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "submit";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormNavi
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(945, 690);
            Controls.Add(button2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Name = "FormNavi";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public static System.Windows.Forms.ComboBox comboBox1;
        public static System.Windows.Forms.Button button1;
        public static System.Windows.Forms.DataGridView dataGridView1;
        public static System.Windows.Forms.Label label1;
        public static System.Windows.Forms.ComboBox comboBox2;
        public static System.Windows.Forms.Button button2;
    }
}

