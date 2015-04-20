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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tv_templet = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmb_DBType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_pd = new System.Windows.Forms.TextBox();
            this.txt_ui = new System.Windows.Forms.TextBox();
            this.txt_ds = new System.Windows.Forms.TextBox();
            this.te_basepath = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgv_tables = new System.Windows.Forms.DataGridView();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tablename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgv_function = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_done = new System.Windows.Forms.Button();
            this.pl_container = new System.Windows.Forms.Panel();
            this.fbd_path = new System.Windows.Forms.FolderBrowserDialog();
            this.FUNCTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tables)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_function)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 650);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pl_container);
            this.splitContainer2.Size = new System.Drawing.Size(1108, 621);
            this.splitContainer2.SplitterDistance = 283;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(283, 621);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "模板";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tv_templet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 529);
            this.panel1.TabIndex = 1;
            // 
            // tv_templet
            // 
            this.tv_templet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tv_templet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_templet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_templet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_templet.LabelEdit = true;
            this.tv_templet.Location = new System.Drawing.Point(0, 0);
            this.tv_templet.Name = "tv_templet";
            this.tv_templet.Size = new System.Drawing.Size(269, 529);
            this.tv_templet.TabIndex = 0;
            this.tv_templet.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_templet_AfterSelect);
            this.tv_templet.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_templet_NodeMouseDoubleClick);
            this.tv_templet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tv_templet_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.cmb_DBType);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmb_type);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txt_pd);
            this.tabPage2.Controls.Add(this.txt_ui);
            this.tabPage2.Controls.Add(this.txt_ds);
            this.tabPage2.Controls.Add(this.te_basepath);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            // 
            // cmb_DBType
            // 
            this.cmb_DBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DBType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_DBType.FormattingEnabled = true;
            this.cmb_DBType.Items.AddRange(new object[] {
            "Oracle",
            "SQLServer",
            "MySQL"});
            this.cmb_DBType.Location = new System.Drawing.Point(10, 337);
            this.cmb_DBType.Name = "cmb_DBType";
            this.cmb_DBType.Size = new System.Drawing.Size(255, 25);
            this.cmb_DBType.TabIndex = 21;
            this.cmb_DBType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "DBType";
            // 
            // cmb_type
            // 
            this.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Items.AddRange(new object[] {
            ".cs",
            ".cshtml",
            ".html",
            ".java",
            ".jsp",
            ".php"});
            this.cmb_type.Location = new System.Drawing.Point(10, 271);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(255, 25);
            this.cmb_type.TabIndex = 21;
            this.cmb_type.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "导出类型";
            // 
            // txt_pd
            // 
            this.txt_pd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_pd.Location = new System.Drawing.Point(10, 208);
            this.txt_pd.Name = "txt_pd";
            this.txt_pd.Size = new System.Drawing.Size(255, 23);
            this.txt_pd.TabIndex = 12;
            // 
            // txt_ui
            // 
            this.txt_ui.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ui.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ui.Location = new System.Drawing.Point(10, 153);
            this.txt_ui.Name = "txt_ui";
            this.txt_ui.Size = new System.Drawing.Size(255, 23);
            this.txt_ui.TabIndex = 11;
            // 
            // txt_ds
            // 
            this.txt_ds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ds.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ds.Location = new System.Drawing.Point(10, 99);
            this.txt_ds.Name = "txt_ds";
            this.txt_ds.Size = new System.Drawing.Size(255, 23);
            this.txt_ds.TabIndex = 10;
            // 
            // te_basepath
            // 
            this.te_basepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.te_basepath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.te_basepath.Location = new System.Drawing.Point(10, 46);
            this.te_basepath.Name = "te_basepath";
            this.te_basepath.Size = new System.Drawing.Size(220, 23);
            this.te_basepath.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(190, 379);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "测试";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(10, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(233, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(10, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Password：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "User ID：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Data Source：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(10, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "导出路径：";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(275, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "数据";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.button3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgv_tables);
            this.splitContainer3.Size = new System.Drawing.Size(269, 529);
            this.splitContainer3.SplitterDistance = 35;
            this.splitContainer3.TabIndex = 2;
            // 
            // dgv_tables
            // 
            this.dgv_tables.AllowUserToAddRows = false;
            this.dgv_tables.AllowUserToDeleteRows = false;
            this.dgv_tables.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHK,
            this.tablename});
            this.dgv_tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_tables.GridColor = System.Drawing.Color.Silver;
            this.dgv_tables.Location = new System.Drawing.Point(0, 0);
            this.dgv_tables.Name = "dgv_tables";
            this.dgv_tables.ReadOnly = true;
            this.dgv_tables.RowHeadersWidth = 5;
            this.dgv_tables.RowTemplate.Height = 23;
            this.dgv_tables.Size = new System.Drawing.Size(269, 490);
            this.dgv_tables.TabIndex = 2;
            this.dgv_tables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tables_CellClick);
            // 
            // CHK
            // 
            this.CHK.DataPropertyName = "CHK";
            this.CHK.FalseValue = "false";
            this.CHK.HeaderText = "...";
            this.CHK.MinimumWidth = 25;
            this.CHK.Name = "CHK";
            this.CHK.ReadOnly = true;
            this.CHK.TrueValue = "true";
            this.CHK.Width = 25;
            // 
            // tablename
            // 
            this.tablename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tablename.DataPropertyName = "TABLE_NAME";
            this.tablename.HeaderText = "表名";
            this.tablename.Name = "tablename";
            this.tablename.ReadOnly = true;
            this.tablename.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tablename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(269, 35);
            this.button3.TabIndex = 0;
            this.button3.Text = "刷新";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage4.Controls.Add(this.dgv_function);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(275, 588);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "方法";
            // 
            // dgv_function
            // 
            this.dgv_function.AllowUserToAddRows = false;
            this.dgv_function.AllowUserToDeleteRows = false;
            this.dgv_function.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_function.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_function.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FUNCTION});
            this.dgv_function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_function.Location = new System.Drawing.Point(3, 3);
            this.dgv_function.Name = "dgv_function";
            this.dgv_function.ReadOnly = true;
            this.dgv_function.RowHeadersWidth = 10;
            this.dgv_function.RowTemplate.Height = 23;
            this.dgv_function.Size = new System.Drawing.Size(269, 582);
            this.dgv_function.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage5.Controls.Add(this.splitContainer4);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(275, 535);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "生成";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer4.Size = new System.Drawing.Size(269, 529);
            this.splitContainer4.SplitterDistance = 34;
            this.splitContainer4.TabIndex = 1;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btn_check);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.btn_done);
            this.splitContainer5.Size = new System.Drawing.Size(269, 34);
            this.splitContainer5.SplitterDistance = 127;
            this.splitContainer5.TabIndex = 1;
            // 
            // btn_check
            // 
            this.btn_check.BackColor = System.Drawing.SystemColors.Control;
            this.btn_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_check.Location = new System.Drawing.Point(0, 0);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(127, 34);
            this.btn_check.TabIndex = 0;
            this.btn_check.Text = "校验";
            this.btn_check.UseVisualStyleBackColor = false;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_done
            // 
            this.btn_done.BackColor = System.Drawing.SystemColors.Control;
            this.btn_done.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_done.Location = new System.Drawing.Point(0, 0);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(138, 34);
            this.btn_done.TabIndex = 0;
            this.btn_done.Text = "执行";
            this.btn_done.UseVisualStyleBackColor = false;
            this.btn_done.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // pl_container
            // 
            this.pl_container.BackColor = System.Drawing.Color.LightSlateGray;
            this.pl_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_container.Location = new System.Drawing.Point(0, 0);
            this.pl_container.Name = "pl_container";
            this.pl_container.Size = new System.Drawing.Size(821, 621);
            this.pl_container.TabIndex = 0;
            // 
            // FUNCTION
            // 
            this.FUNCTION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FUNCTION.DataPropertyName = "FUNCTION";
            this.FUNCTION.HeaderText = "方法列表";
            this.FUNCTION.MinimumWidth = 200;
            this.FUNCTION.Name = "FUNCTION";
            this.FUNCTION.ReadOnly = true;
            this.FUNCTION.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1108, 650);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoCode3.0";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tv_templet_KeyPress);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tables)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_function)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pl_container;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FolderBrowserDialog fbd_path;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tv_templet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmb_DBType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_pd;
        private System.Windows.Forms.TextBox txt_ui;
        private System.Windows.Forms.TextBox txt_ds;
        private System.Windows.Forms.TextBox te_basepath;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgv_function;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_done;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.DataGridView dgv_tables;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablename;
        private System.Windows.Forms.DataGridViewTextBoxColumn FUNCTION;

    }
}