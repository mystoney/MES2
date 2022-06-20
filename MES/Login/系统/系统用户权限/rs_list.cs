using System;
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
    public partial class rs_list : Form
    {
        public rs_list()
        {
            InitializeComponent();
        }

        private void rs_list_Load(object sender, EventArgs e)
        {

            DataTable   dt=new DataTable();
            StringBuilder cmd = new StringBuilder();

            string bmno = "";
            cmd.Clear();
            cmd.Append("select b.id,c.bmmc,b.rs_name,c.bmno,b.rs_no  ");
            cmd.Append("from sys_rs b  left join  ");
            cmd.Append("	sys_bm c on b.bm_id=c.id  ");
            cmd.Append("where  b.stop=1 and b.id not in (select rs_id from sys_user)");
            cmd.Append("order by bmmc,rs_name ");


            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            TreeNode Anode;
            TreeNode Bnode = null;
            TreeNode Unode = null;

            this.TreeView1.Nodes.Clear();
            Anode = this.TreeView1.Nodes.Add("alluser", "全部人员", 0, 1);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (bmno!=dt.Rows[i]["bmno"].ToString())
                {
                    Bnode = Anode.Nodes.Add("B" + dt.Rows[i]["bmno"].ToString().Trim(), dt.Rows[i]["bmno"].ToString().Trim(), 0, 1);
                }

                Unode = Bnode.Nodes.Add("U" + dt.Rows[i]["id"].ToString().Trim(), dt.Rows[i]["rs_name"].ToString().Trim(), 2, 2);
                Unode.Tag = dt.Rows[i]["rs_no"];

                bmno = dt.Rows[i]["bmno"] == null ? "" : dt.Rows[i]["bmno"].ToString().Trim();
            }

            this.TreeView1.Nodes[0].Expand();

            
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.ToString().Substring(0, 1).ToUpper() != "U") { return; }

            ((add_user)this.Owner).TextBox1.Text = e.Node.Tag.ToString();
            this.Close();
        }
    }
}
