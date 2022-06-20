using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.form.Login.系统.系统角色权限
{
    public partial class role_add : Form
    {
        public string state;
        public role_add()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();


            if (this.state.ToUpper()=="ADD")
            {
                if (this.TextBox1.Text.Length==0){ return;}

                cmd.Clear();
                cmd.Append("select * from sys_role where role_name='" +this.TextBox2.Text.Trim()+ "' or role_no='" +this.TextBox1.Text.Trim()+"'");
                dt.Clear();
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

                if (dt.Rows.Count>0 )
                {
                    MessageBox.Show("角色名称或者角色编号已经存在，请检查后输入！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    cmd.Clear();
                    cmd.Append("insert into sys_role(role_no,role_name) values ('" + this.TextBox1.Text.Trim() + "','" + this.TextBox2.Text.Trim() +"')");
                    DBConn.DataAcess.SqlConn.ExecuteSql(cmd.ToString());

                    MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            else if (this.state.ToUpper()=="MOD")
            {
                cmd.Clear();
                cmd.Append("select * from sys_role where role_name='" +this.TextBox2.Text.Trim()+ "' and role_no<>'" +this.TextBox1.Text.Trim()+ "'");
                dt.Clear();
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("角色名称已经存在，请检查后输入！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    cmd.Clear();
                    cmd.Append("update sys_role set role_name='" +this.TextBox2.Text.Trim()+ "' where role_no='" +this.TextBox1.Text.Trim()+ "'");
                    DBConn.DataAcess.SqlConn.ExecuteSql(cmd.ToString());

                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
             
            }

            this.Close();

        }

        private void role_add_Load(object sender, EventArgs e)
        {

        }
    }
}
