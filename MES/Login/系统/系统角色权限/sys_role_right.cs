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

namespace MES.form.Login.系统.系统角色权限
{
    public partial class sys_role_right : Form
    {
        public sys_role_right()
        {
            InitializeComponent();
        }

        public void FlashList()
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            TreeNode Tnode = new TreeNode();

            this.treeView1.Nodes.Clear();

            TreeNode node;

            node = this.treeView1.Nodes.Add("角色");

            cmd.Clear();
            cmd.Append("select * from sys_role order by role_name");

            dt.Clear();
            dt=DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tnode = node.Nodes.Add(dt.Rows[i]["role_name"].ToString());
                Tnode.Tag = dt.Rows[i]["role_no"];
            }

            node.Expand();


        }
    
        private void sys_role_right_Load(object sender, EventArgs e)
        {
            FlashList();
            this.splitContainer2.SplitterDistance = 40;
            this.splitContainer2.Panel1MinSize = 40;
            this.splitContainer3.SplitterDistance = 40;
            this.splitContainer3.Panel1MinSize = 40;

            this.splitContainer1.Panel1MinSize = 250;

        }

        private void ToolStripButton_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton_add_Click(object sender, EventArgs e)
        {
            role_add role_add = new role_add();
            role_add.state = "ADD";
            role_add.Text = "角色添加";
            role_add.ShowDialog();

            FlashList();


        }

        private void ToolStripButton_mod_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode==null || this.treeView1.SelectedNode.Parent ==null)
            {
                MessageBox.Show("请选择要修改的角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            role_add role_add = new role_add();
            role_add.state = "MOD";
            role_add.Text = "角色修改";
            role_add.TextBox1.Enabled = false;
            role_add.TextBox1.Text = this.treeView1.SelectedNode.Tag.ToString();
            role_add.TextBox2.Text = this.treeView1.SelectedNode.Text.ToString();

            role_add.ShowDialog();
             this.treeView1.SelectedNode.Text=role_add.TextBox2.Text.ToString();
        }

        private void ToolStripButton_del_Click(object sender, EventArgs e)
        {
            StringBuilder cmd = new StringBuilder();
            ArrayList AL = new ArrayList();

            if (this.treeView1.SelectedNode==null || this.treeView1.SelectedNode.Parent ==null)
            {
                MessageBox.Show("请选择要删除的角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (MessageBox.Show("是否确定删除角色"+ this.treeView1.SelectedNode.Text + "？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }

            //删除角色权限
            cmd.Clear();
            cmd.Append("delete a from  sys_role_right a left join sys_role b on a.role_no=b.role_no where b.role_no='" + this.treeView1.SelectedNode.Tag + "' ");

            AL.Add(cmd.ToString());

            //删除角色用户
            cmd.Clear();
            cmd.Append("delete a from sys_role_user a left join sys_role b on a.role_no=b.role_no where b.role_no='" + this.treeView1.SelectedNode.Tag + "' ");
            AL.Add(cmd.ToString());

            //删除角色
            cmd.Clear();
            cmd.Append("delete  from sys_role where role_no='" + this.treeView1.SelectedNode.Tag + "'");
            AL.Add(cmd.ToString());


            //删除用户权限
            cmd.Clear();
            cmd.AppendLine("delete bb   ");
            cmd.AppendLine("from sys_user_right bb left join  ");
            cmd.AppendLine("	(select a.login_id,c.menu_no  ");
            cmd.AppendLine("		from sys_user a left join  ");
            cmd.AppendLine("			sys_role_user b on a.login_id=b.login_id left join sys_role_right c on b.role_no=c.role_no ) aa on aa.login_id=bb.login_id and aa.menu_no=bb.menu_no  ");
            cmd.AppendLine("where aa.menu_no is null ");
            AL.Add(cmd.ToString());

            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);
            }
            catch (Exception ex)
            {

                MessageBox.Show("出现错误！ " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("角色删除成功！ "  , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FlashList();

       
        }

   


        private void RefreshTvUser()
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            cmd.Clear();
            cmd.Append("select * from sys_menu where in_user=1 and menu_index is not null order by menu_index");
            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            this.tvUser1.AddTree(dt, "father_no", "menu_no", "menu_name");


            cmd.Clear();
            cmd.AppendLine("select c.*  ");
            cmd.AppendLine("from sys_role a left join   ");
            cmd.AppendLine("	sys_role_right b on a.role_no=b.role_no left join  ");
            cmd.AppendLine("	sys_menu c on b.menu_no=c.menu_no  ");
            cmd.AppendLine("where a.role_no='"+this.treeView1.SelectedNode.Tag + "' and c.in_user=1 and menu_index is not null  ");
            cmd.AppendLine("order by c.menu_index  ");


            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            int j = 0;
            this.tvUser1.SelectNode(ref dt, "menu_no", this.tvUser1.Nodes[0] ,ref j);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode.Parent == null)
            {
                this.tvUser1.Nodes.Clear();
                return;
            }

            RefreshTvUser();
        }

        private void tvUser1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tvUser1.CheckNode(e.Node);
        }

        private void ToolStripButton_refresh_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode==null || this.treeView1.SelectedNode ==null) {return;}
            RefreshTvUser();
        }

        private void ToolStripButton_save_Click(object sender, EventArgs e)
        {
            StringBuilder cmd = new StringBuilder();
            ArrayList AL = new ArrayList();

            string s = "";

            if (this.treeView1.SelectedNode == null || this.treeView1.SelectedNode == null) { return; }


            s = MDI_Class.SaveCheck(this.tvUser1.Nodes[0]);

            s = s.Substring(0, s.Length - 1);
            
            cmd.Clear();
            cmd.Append("delete a from sys_role_right a left join sys_role b on a.role_no = b.role_no where b.role_no = '" +this.treeView1.SelectedNode.Tag+ "'");

            AL.Add(cmd.ToString());


            cmd.Clear();
            cmd.Append("insert into sys_role_right(role_no,menu_no)  select (select role_no from sys_role where role_no='" +this.treeView1.SelectedNode.Tag + "') as role_no,menu_no from sys_menu where menu_no in (" + s + ")");

            AL.Add(cmd.ToString());

            cmd.Clear();
            cmd.Append("exec save_role_right '" +this.treeView1.SelectedNode.Text + "'");

            AL.Add(cmd.ToString());
            try
            {
                DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误！ " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("设置成功！ " , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }
    }
}
