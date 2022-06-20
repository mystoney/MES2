namespace MES.form.Login.视图
{
    partial class newpassword
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
            this.Label3 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(68, 172);
            this.Label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(163, 30);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "确认密码：";
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(230, 165);
            this.TextBox3.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.PasswordChar = '*';
            this.TextBox3.Size = new System.Drawing.Size(244, 42);
            this.TextBox3.TabIndex = 13;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(68, 105);
            this.Label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(133, 30);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "新密码：";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(230, 98);
            this.TextBox2.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.PasswordChar = '*';
            this.TextBox2.Size = new System.Drawing.Size(244, 42);
            this.TextBox2.TabIndex = 11;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(312, 292);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(168, 52);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(82, 292);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(168, 52);
            this.OK_Button.TabIndex = 7;
            this.OK_Button.Text = "确定";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(68, 38);
            this.Label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(163, 30);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "原始密码：";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(230, 30);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.PasswordChar = '*';
            this.TextBox1.Size = new System.Drawing.Size(244, 42);
            this.TextBox1.TabIndex = 9;
            // 
            // newpassword
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(548, 402);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newpassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.newpassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox1;
    }
}