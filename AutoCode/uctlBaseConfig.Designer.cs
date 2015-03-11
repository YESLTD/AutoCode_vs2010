namespace AutoCode
{
    partial class uctlBaseConfig
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_savebasepath = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.te_basepath = new DevExpress.XtraEditors.TextEdit();
            this.modellab = new DevExpress.XtraEditors.LabelControl();
            this.te_modelpath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.te_daopath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.te_servicepath = new DevExpress.XtraEditors.TextEdit();
            this.fbd_path = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.te_strconn = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.te_namespace = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.rtb_dll = new System.Windows.Forms.RichTextBox();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.te_basepath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_modelpath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_daopath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_servicepath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_strconn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_namespace.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_savebasepath
            // 
            this.btn_savebasepath.Location = new System.Drawing.Point(357, 13);
            this.btn_savebasepath.Name = "btn_savebasepath";
            this.btn_savebasepath.Size = new System.Drawing.Size(75, 23);
            this.btn_savebasepath.TabIndex = 0;
            this.btn_savebasepath.Text = "浏览";
            this.btn_savebasepath.Click += new System.EventHandler(this.btn_savebasepath_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "BasePath";
            // 
            // te_basepath
            // 
            this.te_basepath.Location = new System.Drawing.Point(119, 14);
            this.te_basepath.Name = "te_basepath";
            this.te_basepath.Size = new System.Drawing.Size(232, 21);
            this.te_basepath.TabIndex = 2;
            // 
            // modellab
            // 
            this.modellab.Location = new System.Drawing.Point(20, 60);
            this.modellab.Name = "modellab";
            this.modellab.Size = new System.Drawing.Size(80, 14);
            this.modellab.TabIndex = 1;
            this.modellab.Text = "ModelFileName";
            // 
            // te_modelpath
            // 
            this.te_modelpath.Location = new System.Drawing.Point(119, 57);
            this.te_modelpath.Name = "te_modelpath";
            this.te_modelpath.Size = new System.Drawing.Size(313, 21);
            this.te_modelpath.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "DaoFileName";
            // 
            // te_daopath
            // 
            this.te_daopath.Location = new System.Drawing.Point(119, 99);
            this.te_daopath.Name = "te_daopath";
            this.te_daopath.Size = new System.Drawing.Size(313, 21);
            this.te_daopath.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 146);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 14);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "ServiceFileName";
            // 
            // te_servicepath
            // 
            this.te_servicepath.Location = new System.Drawing.Point(119, 142);
            this.te_servicepath.Name = "te_servicepath";
            this.te_servicepath.Size = new System.Drawing.Size(313, 21);
            this.te_servicepath.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(135, 602);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "保存 [s]";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 330);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(93, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "DBConnectString";
            this.labelControl2.Visible = false;
            // 
            // te_strconn
            // 
            this.te_strconn.Location = new System.Drawing.Point(32, 327);
            this.te_strconn.Name = "te_strconn";
            this.te_strconn.Size = new System.Drawing.Size(21, 21);
            this.te_strconn.TabIndex = 5;
            this.te_strconn.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(20, 189);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "NameSpace";
            // 
            // te_namespace
            // 
            this.te_namespace.Location = new System.Drawing.Point(119, 188);
            this.te_namespace.Name = "te_namespace";
            this.te_namespace.Size = new System.Drawing.Size(313, 21);
            this.te_namespace.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(20, 232);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 14);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "UsingDLL";
            // 
            // rtb_dll
            // 
            this.rtb_dll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_dll.Location = new System.Drawing.Point(119, 232);
            this.rtb_dll.Name = "rtb_dll";
            this.rtb_dll.Size = new System.Drawing.Size(313, 353);
            this.rtb_dll.TabIndex = 6;
            this.rtb_dll.Text = "";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(242, 602);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "关闭 [esc]";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // uctlBaseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtb_dll);
            this.Controls.Add(this.te_strconn);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.te_namespace);
            this.Controls.Add(this.te_servicepath);
            this.Controls.Add(this.te_daopath);
            this.Controls.Add(this.te_modelpath);
            this.Controls.Add(this.te_basepath);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.modellab);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_savebasepath);
            this.Name = "uctlBaseConfig";
            this.Size = new System.Drawing.Size(453, 646);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uctlBaseConfig_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.te_basepath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_modelpath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_daopath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_servicepath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_strconn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_namespace.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_savebasepath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit te_basepath;
        private DevExpress.XtraEditors.LabelControl modellab;
        private DevExpress.XtraEditors.TextEdit te_modelpath;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit te_daopath;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit te_servicepath;
        private System.Windows.Forms.FolderBrowserDialog fbd_path;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit te_strconn;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit te_namespace;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.RichTextBox rtb_dll;
        private DevExpress.XtraEditors.SimpleButton btn_close;
    }
}
