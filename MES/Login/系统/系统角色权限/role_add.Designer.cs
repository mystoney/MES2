namespace MES.form.Login.系统.系统角色权限
{
    partial class role_add
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
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(91, 45);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(100, 21);
            this.TextBox2.TabIndex = 11;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(91, 18);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(100, 21);
            this.TextBox1.TabIndex = 10;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(20, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 12);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "角色名称：";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(20, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 12);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "角色编号：";
            // 
            // Button2
            // 
            this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button2.Location = new System.Drawing.Point(106, 81);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 7;
            this.Button2.Text = "取消";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button1.Location = new System.Drawing.Point(24, 81);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "确定";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // role_add
            // 
            this.AcceptButton = this.Button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button2;
            this.ClientSize = new System.Drawing.Size(213, 125);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "role_add";
            this.Text = "角色添加";
            this.Load += new System.EventHandler(this.role_add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
    }
}