using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.form.Login.视图
{
    public partial class newpassword : Form
    {
        public newpassword()
        {
            InitializeComponent();
        }

        private void newpassword_Load(object sender, EventArgs e)
        {
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            StringBuilder cmd = new StringBuilder();
            DataTable dt = new DataTable();

            cmd.Clear();
            cmd.Append("select count(*) from view_login where login_id='"+ MDI_Class.login_id + "' and new_pwd='"+ this.TextBox1.Text.Trim() + "' and stop_login=1 ");

            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];
            if (Convert.ToInt16( dt.Rows[0][0])!=0)
            {
                MessageBox.Show("原始密码不正确，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.TextBox2.Text.Length==0)
            {
                MessageBox.Show("不允许空密码登录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (this.TextBox2.Text!=this.TextBox3.Text)
            {
                MessageBox.Show("新密码两次输入的不同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cmd.Clear();
            cmd.Append("update sys_user set new_pwd='" +this.TextBox2.Text + "' where login_id='" + MDI_Class.login_id + "'");

            DBConn.DataAcess.SqlConn.ExecuteSql(cmd.ToString());

            MessageBox.Show("修改完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
