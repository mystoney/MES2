using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace MES.form.Login.人事.部门资料维护
{
    
    public partial class department : Form
    {

        


        public department()
        {
            InitializeComponent();
        }

        //用于刷新部门编码与部门名称
        public void Refresh_ExDataGridView1(string s="")
        {
            DataTable dt = new DataTable();
            string sql = "";
            string ss = "";


            if (this.ToolStripButton_OK.Checked)
            {
                ss = " and a.stop=1 ";
            }
            else
            {
                ss = " and a.stop=0 ";
            }

            if (s=="")
            {
                sql = "select * from sys_bm a where 1=1 " + ss + " order by bmno";
            }
            else
            {
                sql = "select * from sys_bm a where (bmmc like '%" + s + "%' or bmno like '%" + s + "%') " + ss + "order by bmno";
            }

            
            dt = DBConn.DataAcess.SqlConn.Query(sql).Tables[0];

            this.exDataGridView1.SetDataSource(dt);
            this.exDataGridView1.Columns.Clear();

            this.exDataGridView1.AddColumn("bmno", "部门编号");
            this.exDataGridView1.AddColumn("bmmc", "部门名称");

            if (this.exDataGridView1.Rows.Count>0)
            {
                this.exDataGridView1.Rows[0].Cells["bmno"].Selected = true;
                cellclick(0);

            }
            Refresh_save();
        }

        private void ToolStripButton_refresh_Click(object sender, EventArgs e)
        {
            Refresh_ExDataGridView1();
        }

      
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Refresh_ExDataGridView1(this.TextBox1.Text.Trim());
                this.TextBox1.Text = "";
            }
            
        }

        private void Refresh_add()
        {
            this.TextBox2.Enabled = true;
            this.TextBox3.Enabled = true;
            this.TextBox4.Enabled = true;
            this.TextBox5.Enabled = true;
            this.TextBox6.Enabled = true;
            this.TextBox7.Enabled = true;

            this.CheckBox1.Enabled = true;

            this.ToolStripButton_save.Enabled = true;
            this.ToolStripButton_cancel.Enabled = true;

            this.ToolStripButton_add.Enabled = false;
            this.ToolStripButton_mod.Enabled = false;
            this.ToolStripButton_refresh.Enabled = false;
            this.ToolStripButton_exit.Enabled = false;

            this.ToolStripButton_stop.Enabled = false;
            this.ToolStripButton_OK.Enabled = false;

            this.exDataGridView1.Enabled = false;

        }

        private void Refresh_save()
        {
            this.TextBox2.Enabled = false;
            this.TextBox3.Enabled = false;
            this.TextBox4.Enabled = false;
            this.TextBox5.Enabled = false;
            this.TextBox6.Enabled = false;
            this.TextBox7.Enabled = false;

            this.CheckBox1.Enabled = false;

            this.ToolStripButton_save.Enabled = false;
            this.ToolStripButton_cancel.Enabled = false;

            this.ToolStripButton_add.Enabled = true;
            this.ToolStripButton_mod.Enabled = true;
            this.ToolStripButton_refresh.Enabled = true;
            this.ToolStripButton_exit.Enabled = true;

            this.ToolStripButton_stop.Enabled = true;
            this.ToolStripButton_OK.Enabled = true;

            this.exDataGridView1.Enabled = true;

        }

        private void ToolStripButton_save_Click(object sender, EventArgs e)
        {
     

            DataTable dt = new DataTable();
            string cmd = "";

            try
            {
                if (this.TextBox2.Enabled==true) //说明是新建
                {
                    cmd = "INSERT INTO sys_bm ( bmmc,bmno,fax,memo,tel,zg,stop,input_date,input_man,modify_date,modify_man) values ( '" +  
                        this.TextBox3.Text.Trim() + "', '" + this.TextBox2.Text.Trim() + "', '" + this.TextBox6.Text.Trim() + "', '" + this.TextBox7.Text.Trim() + "', '" + 
                        this.TextBox5.Text.Trim() + "', '" + this.TextBox4.Text.Trim() + "'," + (this.CheckBox1.Checked? "0":"1") + ",getdate(),'" + MDI_Class.rs_name + "',getdate(),'" + MDI_Class.rs_name + "')";
                }
                else
                {
                    cmd = "update sys_bm set bmmc='" + this.TextBox3.Text.Trim() + "',fax='" + this.TextBox6.Text.Trim() + "',memo='" + this.TextBox7.Text.Trim() + "',tel='" +
                        this.TextBox5.Text.Trim() + "',zg='" + this.TextBox4.Text.Trim() + "',stop=" + (this.CheckBox1.Checked ? "0" : "1") + ",modify_man='" + MDI_Class.rs_name +
                        "',modify_date=getdate() where bmno='" + this.TextBox2.Text.Trim() + "'";
                }

                DBConn.DataAcess.SqlConn.ExecuteSql(cmd);

                Refresh_save();
                Refresh_ExDataGridView1();

            }
            catch (Exception ex)
            {

                Refresh_save();
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;   
            
            }
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK,MessageBoxIcon.Information);

            
        }

        private void ToolStripButton_cancel_Click(object sender, EventArgs e)
        {

            if (this.TextBox2.Enabled==true && this.exDataGridView1.Rows.Count>0)
            {
                cellclick(0);
            }
            Refresh_save();
            
        }

        private void ToolStripButton_add_Click(object sender, EventArgs e)
        {
            Refresh_add();
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox7.Text = "";

            this.CheckBox1.Checked = false;

        }

        private void ToolStripButton_mod_Click(object sender, EventArgs e)
        {

            if (this.exDataGridView1.SelectedCells.Count==0)
            {
                return;
            }

            try
            {
                cellclick(this.exDataGridView1.SelectedCells[0].RowIndex);
                Refresh_add();
                this.TextBox2.Enabled = false;

            }
            catch (Exception ex)
            {

                Refresh_save();
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }

        private void exDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                cellclick(e.RowIndex);
            }

        }

        private void ToolStripButton_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //如果点击了单元格则用来刷新右边界面

        private void cellclick(int index)
        {
            DataTable dt = new DataTable();
            string sql = "";


            sql = "select * from  sys_bm where bmno='" + this.exDataGridView1.Rows[index].Cells["bmno"].Value + "'";


            dt = DBConn.DataAcess.SqlConn.Query(sql).Tables[0];
            if (dt.Rows.Count>0)
            {
                this.TextBox3.Text = dt.Rows[0]["bmmc"].ToString();
                this.TextBox2.Text = dt.Rows[0]["bmno"].ToString();
                this.TextBox6.Text = dt.Rows[0]["fax"].ToString();
                this.TextBox7.Text = dt.Rows[0]["memo"].ToString();
                this.TextBox5.Text = dt.Rows[0]["tel"].ToString();
                this.TextBox4.Text = dt.Rows[0]["zg"].ToString();


                if (dt.Rows[0]["stop"].ToString() == "0")
                {
                    this.CheckBox1.Checked = true;
                }
                else
                {
                    this.CheckBox1.Checked = false;
                }
            }
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.Panel1MinSize = 40;

            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.Panel1MinSize = 250;

            this.splitContainer3.SplitterDistance = 50;
            this.splitContainer3.Panel1MinSize = 50;
            

        }

        private void ToolStripButton_OK_Click(object sender, EventArgs e)
        {
            this.ToolStripButton_OK.Checked = true;
            this.ToolStripButton_stop.Checked = false;
            Refresh_ExDataGridView1();
        }

        private void ToolStripButton_stop_Click(object sender, EventArgs e)
        {
            this.ToolStripButton_OK.Checked = false;
            this.ToolStripButton_stop.Checked = true;
            Refresh_ExDataGridView1();
        }

        private void department_Load(object sender, EventArgs e)
        {

            Refresh_ExDataGridView1();

            this.splitContainer1.SplitterDistance = 40;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }





}
