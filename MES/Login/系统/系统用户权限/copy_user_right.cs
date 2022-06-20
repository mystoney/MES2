using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.form.Login.系统.系统用户权限
{
    public partial class copy_user_right : Form
    {
        public copy_user_right()
        {
            InitializeComponent();
        }

        private void copy_user_right_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            this.TextBox1.Enabled = false;
            this.TextBox2.Enabled = false;

            this.TextBox1.Text = ((sys_user_right)this.Owner).ToolStripLabel2.Text.Trim();
            this.TextBox2.Text = ((sys_user_right)this.Owner).TreeView1.SelectedNode.Text.Trim();

            this.Label6.Text = "";



            cmd.Clear();
            cmd.Append("select distinct c.bmmc,c.bmno  ");
            cmd.Append("from sys_user a left join  ");
            cmd.Append("	sys_rs b on a.rs_id=b.id left join  ");
            cmd.Append("	sys_bm c on b.bm_id=c.id  ");
            cmd.Append("where login_id<>'admin' and a.stop_login=1 and a.login_id<>'" +this.TextBox1.Text.Trim()+ "' ");
            cmd.Append("order by bmmc");

            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            this.ComboBox1.Items.Clear();
            this.ComboBox2.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ComboBox1.Items.Add(dt.Rows[i]["bmmc"]);
                this.ComboBox4.Items.Add(dt.Rows[i]["bmno"]);
            }
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboBox3.SelectedIndex = this.ComboBox2.SelectedIndex;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Label6.Text = this.ComboBox3.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboBox4.SelectedIndex = this.ComboBox1.SelectedIndex;
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            cmd.Clear();
            cmd.Append("select distinct b.rs_name,a.login_id  ");
            cmd.Append("from sys_user a left join  ");
            cmd.Append("	sys_rs b on a.rs_id=b.id left join  ");
            cmd.Append("	sys_bm c on b.bm_id=c.id  ");
            cmd.Append("where login_id<>'admin' and a.stop_login=1 and c.bmno='" + this.ComboBox4.Text.ToString()+"' and a.login_id<>'" + this.TextBox1.Text.Trim()+ "' ");
            cmd.Append("order by b.rs_name");

            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];


            this.ComboBox2.Items.Clear();
            this.ComboBox3.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ComboBox2.Items.Add(dt.Rows[i]["rs_name"]);
                this.ComboBox3.Items.Add(dt.Rows[i]["login_id"]);
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ArrayList AL = new ArrayList();
            StringBuilder cmd = new StringBuilder();


            if (this.RadioButton1.Checked)
            {
                AL.AddRange(inheritance_user_right());
            }
            else if (this.RadioButton2.Checked)
            {

            }

            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误 "+ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;                
            }

            MessageBox.Show("操作成功！" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private ArrayList inheritance_user_right()
        {
            ArrayList AL = new ArrayList();
            StringBuilder cmd = new StringBuilder();

            cmd.Clear();
            cmd.Append("insert into Sys_Role_User (login_id,role_no) select '" + this.Label6.Text + "',role_no from sys_role_user where login_id='" + this.TextBox1.Text.Trim()+ "' and role_no not in (select role_no from sys_role_user where login_id ='" +this.Label6.Text + "')");
            AL.Add(cmd.ToString());

            cmd.Clear();
            cmd.Append("insert into Sys_User_Right (login_id,menu_no,menu_id,menu_name,in_user) ");
            cmd.Append("select '"  +this.Label6.Text + "',menu_no,menu_id,menu_name,in_user from sys_user_right where login_id='" + this.TextBox1.Text.Trim()+ "' and menu_no not in (select menu_no from Sys_User_Right where login_id='" + this.Label6.Text + "')");
            AL.Add(cmd.ToString());


            cmd.Clear();
            cmd.Append("update a set a.in_user=1 from sys_user_right a where login_id='"+ this.Label6.Text + "' and a.in_user=0 and a.menu_no in (select menu_no from sys_user_right where  in_user=1 and login_id='" + this.TextBox1.Text.Trim()+ "' )");
            AL.Add(cmd.ToString());


            return AL;
        }
    
    }
}
