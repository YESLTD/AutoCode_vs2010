namespace TestAutoCode
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uctlComboxcs3 = new ToolFunction.uctlComboxcs();
            this.uctlComboxcs1 = new ToolFunction.uctlComboxcs();
            this.uctlComboxcs2 = new ToolFunction.uctlComboxcs();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(37, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(39, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 14);
            this.textBox1.TabIndex = 5;
            // 
            // uctlComboxcs3
            // 
            this.uctlComboxcs3.BackColor = System.Drawing.Color.White;
            this.uctlComboxcs3.Location = new System.Drawing.Point(35, 101);
            this.uctlComboxcs3.Name = "uctlComboxcs3";
            this.uctlComboxcs3.Size = new System.Drawing.Size(55, 22);
            this.uctlComboxcs3.TabIndex = 3;
            // 
            // uctlComboxcs1
            // 
            this.uctlComboxcs1.BackColor = System.Drawing.Color.White;
            this.uctlComboxcs1.Location = new System.Drawing.Point(35, 55);
            this.uctlComboxcs1.Name = "uctlComboxcs1";
            this.uctlComboxcs1.Size = new System.Drawing.Size(55, 22);
            this.uctlComboxcs1.TabIndex = 2;
            // 
            // uctlComboxcs2
            // 
            this.uctlComboxcs2.BackColor = System.Drawing.Color.White;
            this.uctlComboxcs2.Location = new System.Drawing.Point(35, 12);
            this.uctlComboxcs2.Name = "uctlComboxcs2";
            this.uctlComboxcs2.Size = new System.Drawing.Size(55, 19);
            this.uctlComboxcs2.TabIndex = 1;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.uctlComboxcs3);
            this.Controls.Add(this.uctlComboxcs1);
            this.Controls.Add(this.uctlComboxcs2);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolFunction.uctlComboxcs uctlComboxcs2;
        private ToolFunction.uctlComboxcs uctlComboxcs1;
        private ToolFunction.uctlComboxcs uctlComboxcs3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;

    }
}