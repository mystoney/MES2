namespace MES.form.Login.系统.系统用户权限
{
    partial class sys_user_right
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sys_user_right));
            this.ToolStripButton_exit = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_add = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_mod = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_copy = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_begin = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_refresh = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripButton_OK = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_stop = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tvUser1 = new MyContrals.TvUser();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripButton_exit
            // 
            this.ToolStripButton_exit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_exit.Image")));
            this.ToolStripButton_exit.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButton_exit.Name = "ToolStripButton_exit";
            this.ToolStripButton_exit.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_exit.Text = "退出";
            this.ToolStripButton_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_exit.Click += new System.EventHandler(this.ToolStripButton_exit_Click);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.TreeView1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
            this.SplitContainer1.Size = new System.Drawing.Size(808, 473);
            this.SplitContainer1.SplitterDistance = 268;
            this.SplitContainer1.SplitterWidth = 1;
            this.SplitContainer1.TabIndex = 1;
            // 
            // TreeView1
            // 
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.ImageIndex = 0;
            this.TreeView1.ImageList = this.ImageList1;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.SelectedImageIndex = 0;
            this.TreeView1.Size = new System.Drawing.Size(264, 469);
            this.TreeView1.StateImageList = this.ImageList1;
            this.TreeView1.TabIndex = 0;
            this.TreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseClick);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "01923.ico");
            this.ImageList1.Images.SetKeyName(1, "01661.ico");
            this.ImageList1.Images.SetKeyName(2, "00607.ico");
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.ToolStrip1);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.tvUser1);
            this.SplitContainer2.Size = new System.Drawing.Size(535, 469);
            this.SplitContainer2.SplitterDistance = 37;
            this.SplitContainer2.SplitterWidth = 1;
            this.SplitContainer2.TabIndex = 0;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_add,
            this.ToolStripButton_mod,
            this.ToolStripButton_save,
            this.ToolStripButton_copy,
            this.ToolStripButton_begin,
            this.ToolStripButton_refresh,
            this.ToolStripButton_exit,
            this.ToolStripSeparator1,
            this.ToolStripButton_OK,
            this.ToolStripButton_stop,
            this.ToolStripButton1,
            this.ToolStripLabel1,
            this.ToolStripLabel2});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(535, 40);
            this.ToolStrip1.TabIndex = 3;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton_add
            // 
            this.ToolStripButton_add.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_add.Image")));
            this.ToolStripButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_add.Name = "ToolStripButton_add";
            this.ToolStripButton_add.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_add.Text = "新建";
            this.ToolStripButton_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_add.Click += new System.EventHandler(this.ToolStripButton_add_Click);
            // 
            // ToolStripButton_mod
            // 
            this.ToolStripButton_mod.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_mod.Image")));
            this.ToolStripButton_mod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_mod.Name = "ToolStripButton_mod";
            this.ToolStripButton_mod.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_mod.Text = "修改";
            this.ToolStripButton_mod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_mod.Click += new System.EventHandler(this.ToolStripButton_mod_Click);
            // 
            // ToolStripButton_save
            // 
            this.ToolStripButton_save.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_save.Image")));
            this.ToolStripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_save.Name = "ToolStripButton_save";
            this.ToolStripButton_save.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_save.Text = "保存";
            this.ToolStripButton_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_save.Click += new System.EventHandler(this.ToolStripButton_save_Click);
            // 
            // ToolStripButton_copy
            // 
            this.ToolStripButton_copy.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_copy.Image")));
            this.ToolStripButton_copy.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButton_copy.Name = "ToolStripButton_copy";
            this.ToolStripButton_copy.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_copy.Text = "复制";
            this.ToolStripButton_copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_copy.Click += new System.EventHandler(this.ToolStripButton_copy_Click);
            // 
            // ToolStripButton_begin
            // 
            this.ToolStripButton_begin.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_begin.Image")));
            this.ToolStripButton_begin.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButton_begin.Name = "ToolStripButton_begin";
            this.ToolStripButton_begin.Size = new System.Drawing.Size(48, 37);
            this.ToolStripButton_begin.Text = "初始化";
            this.ToolStripButton_begin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_begin.Click += new System.EventHandler(this.ToolStripButton_begin_Click);
            // 
            // ToolStripButton_refresh
            // 
            this.ToolStripButton_refresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_refresh.Image")));
            this.ToolStripButton_refresh.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButton_refresh.Name = "ToolStripButton_refresh";
            this.ToolStripButton_refresh.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_refresh.Text = "刷新";
            this.ToolStripButton_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_refresh.Click += new System.EventHandler(this.ToolStripButton_refresh_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // ToolStripButton_OK
            // 
            this.ToolStripButton_OK.Checked = true;
            this.ToolStripButton_OK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripButton_OK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_OK.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_OK.Image")));
            this.ToolStripButton_OK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_OK.Name = "ToolStripButton_OK";
            this.ToolStripButton_OK.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_OK.Text = "正常";
            this.ToolStripButton_OK.Click += new System.EventHandler(this.ToolStripButton_OK_Click);
            // 
            // ToolStripButton_stop
            // 
            this.ToolStripButton_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_stop.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_stop.Image")));
            this.ToolStripButton_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_stop.Name = "ToolStripButton_stop";
            this.ToolStripButton_stop.Size = new System.Drawing.Size(36, 37);
            this.ToolStripButton_stop.Text = "停用";
            this.ToolStripButton_stop.Click += new System.EventHandler(this.ToolStripButton_stop_Click);
            // 
            // ToolStripButton1
            // 
            this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton1.Image")));
            this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton1.Name = "ToolStripButton1";
            this.ToolStripButton1.Size = new System.Drawing.Size(23, 37);
            this.ToolStripButton1.Text = "ToolStripButton1";
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(68, 37);
            this.ToolStripLabel1.Text = "登录帐号：";
            // 
            // ToolStripLabel2
            // 
            this.ToolStripLabel2.Name = "ToolStripLabel2";
            this.ToolStripLabel2.Size = new System.Drawing.Size(44, 37);
            this.ToolStripLabel2.Text = "??????";
            // 
            // tvUser1
            // 
            this.tvUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUser1.Location = new System.Drawing.Point(0, 0);
            this.tvUser1.Name = "tvUser1";
            this.tvUser1.Size = new System.Drawing.Size(535, 431);
            this.tvUser1.TabIndex = 0;
            this.tvUser1.AfterCheck += new MyContrals.TvUser.AfterCheckEventHandler(this.tvUser1_AfterCheck);
            // 
            // sys_user_right
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 473);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "sys_user_right";
            this.Text = "系统用户权限";
            this.Load += new System.EventHandler(this.sys_user_right_Load);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel1.PerformLayout();
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripButton ToolStripButton_exit;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_add;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_mod;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_save;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_copy;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_begin;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_refresh;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_OK;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_stop;
        internal System.Windows.Forms.ToolStripButton ToolStripButton1;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel2;
        private MyContrals.TvUser tvUser1;
    }
}