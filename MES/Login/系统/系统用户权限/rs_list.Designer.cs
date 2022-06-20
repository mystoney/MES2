namespace MES.form.Login.系统.系统用户权限
{
    partial class rs_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rs_list));
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // TreeView1
            // 
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.ImageIndex = 0;
            this.TreeView1.ImageList = this.ImageList1;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.SelectedImageIndex = 0;
            this.TreeView1.Size = new System.Drawing.Size(180, 510);
            this.TreeView1.TabIndex = 2;
            this.TreeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "01923.ico");
            this.ImageList1.Images.SetKeyName(1, "01661.ico");
            this.ImageList1.Images.SetKeyName(2, "00607.ico");
            // 
            // rs_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 510);
            this.Controls.Add(this.TreeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rs_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "人员情况";
            this.Load += new System.EventHandler(this.rs_list_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.ImageList ImageList1;
    }
}