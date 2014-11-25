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
            this.uctlComboxcs1 = new ToolFunction.uctlComboxcs();
            this.uctlComboxcs4 = new ToolFunction.uctlComboxcs();
            this.uctlComboxcs2 = new ToolFunction.uctlComboxcs();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uctlComboxcs1
            // 
            this.uctlComboxcs1.BackColor = System.Drawing.Color.White;
            this.uctlComboxcs1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctlComboxcs1.Location = new System.Drawing.Point(12, 61);
            this.uctlComboxcs1.Name = "uctlComboxcs1";
            this.uctlComboxcs1.Size = new System.Drawing.Size(55, 21);
            this.uctlComboxcs1.TabIndex = 7;
            // 
            // uctlComboxcs4
            // 
            this.uctlComboxcs4.BackColor = System.Drawing.Color.White;
            this.uctlComboxcs4.Font = new System.Drawing.Font("Monaco", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctlComboxcs4.Location = new System.Drawing.Point(12, 105);
            this.uctlComboxcs4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uctlComboxcs4.Name = "uctlComboxcs4";
            this.uctlComboxcs4.Size = new System.Drawing.Size(55, 20);
            this.uctlComboxcs4.TabIndex = 6;
            // 
            // uctlComboxcs2
            // 
            this.uctlComboxcs2.BackColor = System.Drawing.Color.White;
            this.uctlComboxcs2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uctlComboxcs2.Location = new System.Drawing.Point(12, 12);
            this.uctlComboxcs2.Name = "uctlComboxcs2";
            this.uctlComboxcs2.Size = new System.Drawing.Size(101, 21);
            this.uctlComboxcs2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "测试事务";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uctlComboxcs2);
            this.Controls.Add(this.uctlComboxcs1);
            this.Controls.Add(this.uctlComboxcs4);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private ToolFunction.uctlComboxcs uctlComboxcs4;
        private ToolFunction.uctlComboxcs uctlComboxcs1;
        private ToolFunction.uctlComboxcs uctlComboxcs2;
        private System.Windows.Forms.Button button1;

    }
}