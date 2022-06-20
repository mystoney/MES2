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
    public partial class add_user : Form
    {

        public string state="";
        public add_user()
        {
            InitializeComponent();
        }

        private void add_user_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            if (state.ToUpper()=="ADD")
            {
                this.Text = "新建用户";

                cmd.Clear();
                cmd.Append("select role_name from  sys_role order by role_name ");

                dt.Clear();
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

                this.ListBox2.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.ListBox2.Items.Add(dt.Rows[i]["role_name"].ToString());
                }
            }
            else if (state.ToUpper()=="MOD")
            {
                this.Text = "修改用户";

                this.TextBox1.Text = ((MES.form.Login.系统.系统用户权限.sys_user_right)this.Owner).TreeView1.SelectedNode.Tag.ToString().Trim();
                this.TextBox2.Text = ((MES.form.Login.系统.系统用户权限.sys_user_right)this.Owner).ToolStripLabel2.Text.Trim();

                cmd.Clear();
                cmd.Append("select stop_login from sys_user where login_id='" + ((MES.form.Login.系统.系统用户权限.sys_user_right)this.Owner).ToolStripLabel2.Text.Trim() + "'");
                
                this.CheckBox1.Checked = (int)DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString()) == 1 ? false : true;

                this.TextBox1.Enabled = false;
                this.TextBox2.Enabled = false;
                this.TextBox3.Enabled = false;
                this.TextBox4.Enabled = false;
                this.Button1.Enabled = false;

                cmd.Clear();
                cmd.Append("select role_name from Sys_Role_User a left join sys_role b on a.role_no=b.role_no where a.login_id='" +this.TextBox2.Text.Trim()+  "'");

                dt.Clear();
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

                this.ListBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.ListBox1.Items.Add(dt.Rows[i]["role_name"]);
                }




                cmd.Clear();
                cmd.Append("select role_name from  sys_role where  role_no not in (select role_no from Sys_Role_User where login_id='" +this.TextBox2.Text.Trim()+ "')");

                dt.Clear();
                dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

                this.ListBox2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.ListBox2.Items.Add(dt.Rows[i]["role_name"]);
                }

            }
           

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            rs_list rs_list = new rs_list();
            rs_list.Top = this.Top +this.GroupBox1.Top+ this.TextBox1.Top + 52;
            rs_list.Left = this.Left +this.GroupBox1.Left+ this.TextBox1.Left;

            rs_list.Owner = this;

            rs_list.ShowDialog();

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            if (this.ListBox2.SelectedItem==null ){ return; }

            this.ListBox1.Items.Add(this.ListBox2.SelectedItem);
            this.ListBox2.Items.Remove(this.ListBox2.SelectedItem);

            if (this.ListBox2.Items.Count!=0)
            {
                this.ListBox2.SelectedItem = this.ListBox2.Items[0];
            }
        
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (this.ListBox1.SelectedItem == null) { return; }

            this.ListBox2.Items.Add(this.ListBox1.SelectedItem);
            this.ListBox1.Items.Remove(this.ListBox1.SelectedItem);

            if (this.ListBox1.Items.Count != 0)
            {
                this.ListBox1.SelectedItem = this.ListBox1.Items[0];
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            ArrayList AL = new ArrayList();

            int rsid = 0;
            string B = "";
            string U = "";

            if (state.ToUpper()=="ADD")
            {
                cmd.Clear();
                cmd.Append("select count(*) from sys_rs where rs_no='" + this.TextBox1.Text.Trim() + "'");

                if ((int)DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString())==0)
                {
                    MessageBox.Show("员工编号不正确，请检查后录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    cmd.Clear();
                    cmd.Append("select id from sys_rs  where rs_no='" +this.TextBox1.Text + "'");
                    rsid = (int)DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString());
                }

                if (this.TextBox2.Text.Trim().Length==0)
                {
                    MessageBox.Show("登录帐号不能为空，请检查后录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmd.Clear();
                cmd.Append("select count(*) from sys_user where login_id='" +this.TextBox2.Text.Trim()+ "'");

                if ((int)DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString())!=0)
                {
                    MessageBox.Show("登录帐号已经存在，请更改后录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (this.TextBox3.Text.Trim()!=this.TextBox4.Text.Trim())
                {
                    MessageBox.Show("两次密码不同，请重新录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmd.Clear();
                cmd.Append("INSERT INTO Sys_User ( BeginDate,Login_ID,New_pwd,Old_pwd,rs_ID,Stop_Login,Term) values " );
                cmd.Append("( getdate(), '" +this.TextBox2.Text.Trim()+ "', '" +this.TextBox3.Text.Trim()+"', null, '" + rsid + "', " +(this.CheckBox1.Checked? "0": "1")+ ", '30')");
                AL.Add(cmd.ToString());

                AL.AddRange(save_right(this.TextBox2.Text.Trim()));
              
                try
                {
                    DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("错误！ " + ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
  
            }
            else
            {
                cmd.Clear();
                cmd.Append("select id from sys_rs  where rs_no='" +this.TextBox1.Text.ToString() +"'");
                rsid = (int)DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString());

                cmd.Clear();
                cmd.Append("update sys_user set stop_login=" + (this.CheckBox1.Checked ? "0" : "1") + " where login_id='" + ((sys_user_right)this.Owner).ToolStripLabel2.Text.Trim()+ "'");

                AL.Add(cmd.ToString());

                AL.AddRange(save_right(this.TextBox2.Text.Trim()));


                try
                {
                    DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("错误！ " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
            }


            MessageBox.Show("保存成功！ " , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ((sys_user_right)this.Owner).Refresh_TreeView();


            if (((sys_user_right)this.Owner).ToolStripButton_stop.Checked==this.CheckBox1.Checked)
            {
                cmd.Clear();
                cmd.Append("select b.bmno from sys_rs a left join sys_bm b on a.bm_id=b.id where a.id=" + rsid.ToString());

                B = "B" + DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString()).ToString();
                U = "U" + this.TextBox2.Text.Trim();

                ((sys_user_right)this.Owner).TreeView1.SelectedNode = ((sys_user_right)this.Owner).TreeView1.Nodes["alluser"].Nodes[B].Nodes[U];
            }


            this.Close();
            
        }

        private ArrayList save_right(string loginid)
        {

            ArrayList AL = new System.Collections.ArrayList();
            StringBuilder cmd = new StringBuilder();

            string s = "";

            for (int i = 0; i < this.ListBox1.Items.Count; i++)
            {
                s = s + "'" + this.ListBox1.Items[i].ToString() + "',";
            }

            cmd.Clear();
            cmd.Append("delete from sys_role_user where login_id='" + loginid + "'");
            AL.Add(cmd.ToString());

            if (s!="")
            {
                s = s.Substring(0, s.Length - 1);

                cmd.Clear();
                cmd.Append("insert into sys_role_user (login_id,role_no) select  '" + loginid + "' as login_id,role_no from sys_role where role_name in (" + s + ")");

                AL.Add(cmd.ToString());


                cmd.Clear();
                cmd.Append("delete from sys_user_right where login_id='" + loginid + "' and menu_no not in (SELECT DISTINCT b.Menu_No FROM Sys_Role_User a LEFT OUTER JOIN Sys_Role_Right b ON a.Role_No = b.Role_No WHERE (a.Login_ID = '" + loginid + "') ) ");

                AL.Add(cmd.ToString());


                cmd.Clear();
                cmd.Append("insert into sys_user_right (menu_no,login_id) SELECT DISTINCT b.Menu_No, '" + loginid + "' AS login_id FROM Sys_Role_User a LEFT OUTER JOIN Sys_Role_Right b ON a.Role_No = b.Role_No WHERE (a.Login_ID = '" + loginid + "') and menu_no not in (select menu_no from sys_user_right where login_id='" + loginid + "')");

                AL.Add(cmd.ToString());

            }
      
            return AL;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
