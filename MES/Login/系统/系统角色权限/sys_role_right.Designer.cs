namespace MES.form.Login.系统.系统角色权限
{
    partial class sys_role_right
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sys_role_right));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_add = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_mod = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_del = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_exit = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_refresh = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_save = new System.Windows.Forms.ToolStripButton();
            this.tvUser1 = new MyContrals.TvUser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.ToolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1807, 1316);
            this.splitContainer1.SplitterDistance = 766;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ToolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeView1);
            this.splitContainer2.Size = new System.Drawing.Size(766, 1316);
            this.splitContainer2.SplitterDistance = 80;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 2;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_add,
            this.ToolStripButton_mod,
            this.ToolStripButton_del,
            this.ToolStripButton_exit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStrip1.Size = new System.Drawing.Size(762, 62);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton_add
            // 
            this.ToolStripButton_add.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_add.Image")));
            this.ToolStripButton_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_add.Name = "ToolStripButton_add";
            this.ToolStripButton_add.Size = new System.Drawing.Size(81, 59);
            this.ToolStripButton_add.Text = "新建";
            this.ToolStripButton_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_add.Click += new System.EventHandler(this.ToolStripButton_add_Click);
            // 
            // ToolStripButton_mod
            // 
            this.ToolStripButton_mod.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_mod.Image")));
            this.ToolStripButton_mod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_mod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_mod.Name = "ToolStripButton_mod";
            this.ToolStripButton_mod.Size = new System.Drawing.Size(81, 59);
            this.ToolStripButton_mod.Text = "修改";
            this.ToolStripButton_mod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_mod.Click += new System.EventHandler(this.ToolStripButton_mod_Click);
            // 
            // ToolStripButton_del
            // 
            this.ToolStripButton_del.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_del.Image")));
            this.ToolStripButton_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_del.Name = "ToolStripButton_del";
            this.ToolStripButton_del.Size = new System.Drawing.Size(81, 59);
            this.ToolStripButton_del.Text = "删除";
            this.ToolStripButton_del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_del.Click += new System.EventHandler(this.ToolStripButton_del_Click);
            // 
            // ToolStripButton_exit
            // 
            this.ToolStripButton_exit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_exit.Image")));
            this.ToolStripButton_exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_exit.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButton_exit.Name = "ToolStripButton_exit";
            this.ToolStripButton_exit.Size = new System.Drawing.Size(81, 59);
            this.ToolStripButton_exit.Text = "退出";
            this.ToolStripButton_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_exit.Click += new System.EventHandler(this.ToolStripButton_exit_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.ImageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(762, 1230);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "closefolder.ico");
            this.ImageList1.Images.SetKeyName(1, "open.ico");
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ToolStrip2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tvUser1);
            this.splitContainer3.Size = new System.Drawing.Size(1039, 1316);
            this.splitContainer3.SplitterDistance = 80;
            this.splitContainer3.SplitterWidth = 2;
            this.splitContainer3.TabIndex = 2;
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_refresh,
            this.ToolStripButton_save});
            this.ToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStrip2.Size = new System.Drawing.Size(1035, 62);
            this.ToolStrip2.TabIndex = 1;
            this.ToolStrip2.Text = "ToolStrip2";
            // 
            // ToolStripButton_refresh
            // 
            this.ToolStripButton_refresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_refresh.Image")));
            this.ToolStripButton_refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_refresh.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripButton_refresh.Name = "ToolStripButton_refresh";
            this.ToolStripButton_refresh.Size = new System.Drawing.Size(81, 59);
            this.ToolStripButton_refresh.Text = "刷新";
            this.ToolStripButton_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_refresh.Click += new System.EventHandler(this.ToolStripButton_refresh_Click);
            // 
            // ToolStripButton_save
            // 
            this.ToolStripButton_save.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_save.Image")));
            this.ToolStripButton_save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_save.Name = "ToolStripButton_save";
            this.ToolStripButton_save.Size = new System.Drawing.Size(81, 59);
            this.ToolStripButton_save.Text = "保存";
            this.ToolStripButton_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_save.Click += new System.EventHandler(this.ToolStripButton_save_Click);
            // 
            // tvUser1
            // 
            this.tvUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUser1.Location = new System.Drawing.Point(0, 0);
            this.tvUser1.Margin = new System.Windows.Forms.Padding(8);
            this.tvUser1.Name = "tvUser1";
            this.tvUser1.Size = new System.Drawing.Size(1035, 1230);
            this.tvUser1.TabIndex = 0;
            this.tvUser1.AfterCheck += new MyContrals.TvUser.AfterCheckEventHandler(this.tvUser1_AfterCheck);
            // 
            // sys_role_right
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1807, 1316);
            this.Controls.Add(this.splitContainer1);
            this.Name = "sys_role_right";
            this.Text = "角色权限";
            this.Load += new System.EventHandler(this.sys_role_right_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ToolStrip2.ResumeLayout(false);
            this.ToolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        internal System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.TreeView treeView1;
        private MyContrals.TvUser tvUser1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_add;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_mod;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_del;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_exit;
        internal System.Windows.Forms.ToolStrip ToolStrip2;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_refresh;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_save;
    }
}