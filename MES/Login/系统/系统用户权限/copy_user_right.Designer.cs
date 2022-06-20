namespace MES.form.Login.系统.系统用户权限
{
    partial class copy_user_right
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
            this.ComboBox4 = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBox3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ComboBox4
            // 
            this.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox4.FormattingEnabled = true;
            this.ComboBox4.Location = new System.Drawing.Point(86, 136);
            this.ComboBox4.Name = "ComboBox4";
            this.ComboBox4.Size = new System.Drawing.Size(121, 20);
            this.ComboBox4.TabIndex = 31;
            this.ComboBox4.Visible = false;
            this.ComboBox4.SelectedIndexChanged += new System.EventHandler(this.ComboBox4_SelectedIndexChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(288, 136);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(41, 12);
            this.Label6.TabIndex = 30;
            this.Label6.Text = "label6";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(225, 136);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(65, 12);
            this.Label5.TabIndex = 29;
            this.Label5.Text = "登录帐号：";
            // 
            // ComboBox2
            // 
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Location = new System.Drawing.Point(290, 109);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(121, 20);
            this.ComboBox2.TabIndex = 27;
            this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(225, 112);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 12);
            this.Label4.TabIndex = 26;
            this.Label4.Text = "员工姓名：";
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(86, 109);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(121, 20);
            this.ComboBox1.TabIndex = 25;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(21, 112);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 12);
            this.Label3.TabIndex = 24;
            this.Label3.Text = "部门名称：";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(281, 171);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 23;
            this.Button2.Text = "取消";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button1.Location = new System.Drawing.Point(111, 171);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 22;
            this.Button1.Text = "确定";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // RadioButton2
            // 
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(23, 70);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(383, 16);
            this.RadioButton2.TabIndex = 21;
            this.RadioButton2.Text = "复制：先删除目标帐号的权限，再将上面的帐号权限增加到目标帐号";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton2.Visible = false;
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            this.RadioButton1.Location = new System.Drawing.Point(23, 48);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(239, 16);
            this.RadioButton1.TabIndex = 20;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "继承：将上面帐号的权限增加到目标帐号";
            this.RadioButton1.UseVisualStyleBackColor = true;
            // 
            // TextBox2
            // 
            this.TextBox2.Enabled = false;
            this.TextBox2.Location = new System.Drawing.Point(290, 12);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(115, 21);
            this.TextBox2.TabIndex = 19;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(225, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 12);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "员工姓名：";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(86, 12);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(115, 21);
            this.TextBox1.TabIndex = 17;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(21, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 12);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "登录帐号：";
            // 
            // ComboBox3
            // 
            this.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox3.FormattingEnabled = true;
            this.ComboBox3.Location = new System.Drawing.Point(317, 136);
            this.ComboBox3.Name = "ComboBox3";
            this.ComboBox3.Size = new System.Drawing.Size(121, 20);
            this.ComboBox3.TabIndex = 28;
            this.ComboBox3.Visible = false;
            this.ComboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // copy_user_right
            // 
            this.AcceptButton = this.Button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button2;
            this.ClientSize = new System.Drawing.Size(470, 218);
            this.Controls.Add(this.ComboBox4);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.RadioButton2);
            this.Controls.Add(this.RadioButton1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ComboBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "copy_user_right";
            this.Text = "权限复制／继承";
            this.Load += new System.EventHandler(this.copy_user_right_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox ComboBox4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox ComboBox2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.RadioButton RadioButton2;
        internal System.Windows.Forms.RadioButton RadioButton1;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox ComboBox3;
    }
}