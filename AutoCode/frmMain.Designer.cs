namespace AutoCode
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.连接配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模板编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据源选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件介绍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pl_container = new System.Windows.Forms.Panel();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接配置ToolStripMenuItem,
            this.模板编辑ToolStripMenuItem,
            this.数据源选择ToolStripMenuItem,
            this.软件介绍ToolStripMenuItem,
            this.测试ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 连接配置ToolStripMenuItem
            // 
            this.连接配置ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.连接配置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.连接配置ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.连接配置ToolStripMenuItem.Name = "连接配置ToolStripMenuItem";
            this.连接配置ToolStripMenuItem.ShortcutKeyDisplayString = "A";
            this.连接配置ToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.连接配置ToolStripMenuItem.Text = "连接配置";
            this.连接配置ToolStripMenuItem.Click += new System.EventHandler(this.连接配置ToolStripMenuItem_Click);
            // 
            // 模板编辑ToolStripMenuItem
            // 
            this.模板编辑ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.模板编辑ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.模板编辑ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.模板编辑ToolStripMenuItem.Name = "模板编辑ToolStripMenuItem";
            this.模板编辑ToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.模板编辑ToolStripMenuItem.Text = "模板编辑";
            this.模板编辑ToolStripMenuItem.Click += new System.EventHandler(this.模板编辑ToolStripMenuItem_Click);
            // 
            // 数据源选择ToolStripMenuItem
            // 
            this.数据源选择ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.数据源选择ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.数据源选择ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.数据源选择ToolStripMenuItem.Name = "数据源选择ToolStripMenuItem";
            this.数据源选择ToolStripMenuItem.Size = new System.Drawing.Size(91, 25);
            this.数据源选择ToolStripMenuItem.Text = "数据源选择";
            this.数据源选择ToolStripMenuItem.Click += new System.EventHandler(this.数据源选择ToolStripMenuItem_Click);
            // 
            // 软件介绍ToolStripMenuItem
            // 
            this.软件介绍ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.软件介绍ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.软件介绍ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.软件介绍ToolStripMenuItem.Name = "软件介绍ToolStripMenuItem";
            this.软件介绍ToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.软件介绍ToolStripMenuItem.Text = "软件介绍";
            this.软件介绍ToolStripMenuItem.Click += new System.EventHandler(this.软件介绍ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pl_container);
            this.splitContainer1.Size = new System.Drawing.Size(882, 650);
            this.splitContainer1.SplitterDistance = 29;
            this.splitContainer1.TabIndex = 2;
            // 
            // pl_container
            // 
            this.pl_container.BackColor = System.Drawing.Color.LightSlateGray;
            this.pl_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_container.Location = new System.Drawing.Point(0, 0);
            this.pl_container.Name = "pl_container";
            this.pl_container.Size = new System.Drawing.Size(882, 617);
            this.pl_container.TabIndex = 0;
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.测试ToolStripMenuItem.Text = "测试";
            this.测试ToolStripMenuItem.Click += new System.EventHandler(this.测试ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(882, 650);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoCode 2.0";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 连接配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模板编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据源选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件介绍ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pl_container;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;

    }
}