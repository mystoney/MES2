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
using Microsoft.VisualBasic;



namespace MES.form.Login.系统.系统用户权限
{
    public partial class sys_user_right : Form
    {
        public sys_user_right()
        {
            InitializeComponent();
        }

    
        private void ToolStripButton_add_Click(object sender, EventArgs e)
        {
            
            add_user add_user = new add_user();
            add_user.state = "add";
            add_user.Owner = this;

            add_user.Show();

            SelectNode(this.TreeView1.SelectedNode);

        }


        private void sys_user_right_Load(object sender, EventArgs e)
        {
            Refresh_TreeView();
        }

     
        public void Refresh_TreeView()
        {

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();
            string bmno = "";
            string ss = "";

            this.ToolStripLabel2.Text = "";

            if (this.ToolStripButton_OK.Checked)
            {
                ss = " and a.stop_login=1";
            }
            else if (this.ToolStripButton_stop.Checked)
            {
                ss = " and a.stop_login=0";
            }

            cmd.Clear();
            cmd.Append("select a.*,c.bmmc,b.rs_name,c.bmno,b.rs_no  ");
            cmd.Append("from sys_user a left join  ");
            cmd.Append("	sys_rs b on a.rs_id=b.id left join  ");
            cmd.Append("	sys_bm c on b.bm_id=c.id  " );
            cmd.Append("where login_id<>'admin' " + ss);
            cmd.Append("order by bmmc,rs_name ");

            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            TreeNode Tnode;
            TreeNode Bnode = null;
            TreeNode Unode = null;

            this.TreeView1.Nodes.Clear();
            Tnode = this.TreeView1.Nodes.Add("alluser", "全部用户", 0, 1);

            for (int i =   0; i < dt.Rows.Count; i++)
            {
                if (bmno != dt.Rows[i]["bmno"].ToString())
                {
                    Bnode = Tnode.Nodes.Add("B" + dt.Rows[i]["bmno"].ToString().Trim(), dt.Rows[i]["bmmc"].ToString().Trim(), 0, 1);
                }
                Unode = Bnode.Nodes.Add("U" + dt.Rows[i]["login_id"].ToString().Trim(), dt.Rows[i]["rs_name"].ToString().Trim(), 2, 2);
                Unode.Tag = dt.Rows[i]["rs_no"].ToString().Trim();

                bmno = (dt.Rows[i]["bmno"]==null?"":dt.Rows[i]["bmno"].ToString().Trim());
            }

            this.TreeView1.Nodes[0].Expand();
            this.tvUser1.Nodes.Clear();
            this.TreeView1.SelectedNode = this.TreeView1.Nodes["alluser"];
            Refresh_ToolButton(false);

            
        }


        private void Refresh_ToolButton(Boolean show)
        {


            this.ToolStripButton_mod.Enabled = show;
            this.ToolStripButton_save.Enabled = show;
            this.ToolStripButton_copy.Enabled = show;
            this.ToolStripButton_begin.Enabled = show;

            if( this.ToolStripButton_stop.Checked )
            {
                this.ToolStripButton_save.Enabled = false;
                this.ToolStripButton_copy.Enabled = false;
            }
            
    
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void SelectNode(TreeNode TN)
        {

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            this.tvUser1.Nodes.Clear();

            if (TN.Name.Substring(0,1).ToUpper()!="U")
            {
                this.ToolStripLabel2.Text = "";
                Refresh_ToolButton(false);
                return;
            }
            else
            {
                this.ToolStripLabel2.Text = TN.Name.ToUpper().Replace("U", "");
                Refresh_ToolButton(true);
            }

            cmd.Clear();
            cmd.Append("select distinct d.menu_no,d.menu_name,d.father_no,d.menu_index ");
            cmd.Append("from sys_user a inner join ");
            cmd.Append("	sys_role_user b on a.login_id=b.login_id left join  ");
            cmd.Append("	sys_role_right c on b.role_no=c.role_no left join ");
            cmd.Append("	sys_menu d on c.menu_no=d.menu_no ");
            cmd.Append("where a.login_id='" +TN.Name.ToUpper().Replace("U", "") + "' and d.in_user=1 and d.menu_index is not null ");
            cmd.Append("order by d.menu_index");

            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            if (dt.Rows.Count==0){ return; }

            this.tvUser1.AddTree(dt, "father_no", "menu_no", "menu_name");


            cmd.Clear();
            cmd.Append("select b.* ");
            cmd.Append("from sys_user_right a left join  ");
            cmd.Append("	sys_menu b on a.menu_no=b.menu_no ");
            cmd.Append("where b.menu_index is not null and a.in_user=1 and b.in_user=1 and a.login_id='" +TN.Name.ToUpper().Replace("U", "") + "' ");
            cmd.Append("order by b.menu_index ");

            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            int j = 0;
            this.tvUser1.SelectNode(ref dt, "menu_no", this.tvUser1.Nodes[0],ref j);
            
        }

    
        private void ToolStripButton_OK_Click(object sender, EventArgs e)
        {

            this.ToolStripButton_OK.Checked = true;
            this.ToolStripButton_stop.Checked = false;
            Refresh_TreeView();
        }

        private void ToolStripButton_stop_Click(object sender, EventArgs e)
        {
            this.ToolStripButton_OK.Checked = false;
            this.ToolStripButton_stop.Checked = true;
            Refresh_TreeView();
        }

        private void tvUser1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tvUser1.CheckNode(e.Node);
        }

        private void ToolStripButton_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton_refresh_Click(object sender, EventArgs e)
        {
            Refresh_TreeView();
        }

        private void ToolStripButton_save_Click(object sender, EventArgs e)
        {
            ArrayList AL = new ArrayList();

            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();
            string s = "";


            s = MDI_Class.SaveCheck(this.tvUser1.Nodes[0]);
            s = s.Substring(0, s.Length - 1);


            cmd.Clear();
            cmd.Append("update sys_user_right set in_user=0 where login_id='" +this.ToolStripLabel2.Text.Trim() + "'");
            AL.Add(cmd.ToString());


            cmd.Clear();
            cmd.Append("update a set in_user=1 from sys_user_right a left join sys_menu b on a.menu_no=b.menu_no where b.menu_no in (" + s + ") and a.login_id='" +this.ToolStripLabel2.Text.Trim()+ "'");
            AL.Add(cmd.ToString());


            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误 " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("保存成功！ ","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripButton_begin_Click(object sender, EventArgs e)
        {

            StringBuilder cmd = new StringBuilder();
            string s = "";

            
            s = Interaction.InputBox("请输入初始化密码！", "初始化密码", "");

            if (s == "") { return; }
            
            cmd.Clear();
            cmd.Append("update sys_user set old_pwd=new_pwd,new_pwd='" + s+ "' where login_id='" +this.ToolStripLabel2.Text.Trim()+ "'");
            DBConn.DataAcess.SqlConn.ExecuteSql(cmd.ToString());

            

            MessageBox.Show("初始化完成！ ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void ToolStripButton_mod_Click(object sender, EventArgs e)
        {

            if (this.TreeView1.SelectedNode ==null || this.TreeView1.SelectedNode.Name.Substring(0, 1).ToUpper() != "U")
            {
                MessageBox.Show("请选择用户后操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            //if (this.TreeView1.SelectedNode.Name.Substring(0, 1).ToUpper() != "U")
            //{
            //    MessageBox.Show("请选择用户后操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            add_user add_user = new add_user();
            add_user.state = "mod";
            add_user.Owner = this;

            add_user.Show();

            SelectNode(this.TreeView1.SelectedNode);
        }

        private void ToolStripButton_copy_Click(object sender, EventArgs e)
        {
            copy_user_right copy_user_right = new copy_user_right();
            copy_user_right.Owner = this;


            copy_user_right.ShowDialog();
        }
    }
}
