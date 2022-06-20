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


namespace MES.form.Login.人事.人员资料维护
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }


        #region 窗体或者控件刷新的代码
        /// <summary>
        /// 用户刷新人员的名字与编号
        /// </summary>
        /// <param name="s">传入的条件</param>
        public void Refresh_ExDataGridView1(string s = "")
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();
            string ss = "";

            if (ToolStripButton_OK.Checked)
            {
                ss = " and a.stop=1";
            }
            else
            {
                ss = " and a.stop=0";
            }


            if (s == "")
            {
                cmd.Clear();
                cmd.AppendLine("select a.id as rsid,*   ");
                cmd.AppendLine("from sys_rs a left join   ");
                cmd.AppendLine("     sys_bm b on a.bm_id=b.id	left join  ");
                cmd.AppendLine("     sys_xl c on a.xl_id=c.id  ");
                cmd.AppendLine("where 1=1  " + ss + "  ");
                cmd.AppendLine("order by a.rs_no  ");
            }
            else
            {
                cmd.Clear();
                cmd.AppendLine("select a.id as rsid,* ");
                cmd.AppendLine("        from sys_rs a left join ");
                cmd.AppendLine("            sys_bm b on a.bm_id= b.id  left join ");
                cmd.AppendLine("            sys_xl c on a.xl_id= c.id ");
                cmd.AppendLine("        where (a.rs_no like '%" + this.TextBox1.Text.Trim() + "%' or a.rs_name like '%" + this.TextBox1.Text.Trim() + "%' )" + ss + s   );
                cmd.AppendLine("        order by a.rs_no ");
            }

            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            this.exDataGridView1.SetDataSource(dt);
            this.exDataGridView1.Columns.Clear();

            this.exDataGridView1.AddColumn("rs_no", "员工编号");
            this.exDataGridView1.AddColumn("rs_name", "员工姓名");
            this.exDataGridView1.AddColumn("id", "id", 80, true, null, DataGridViewContentAlignment.MiddleLeft, null, false);


            if(this.exDataGridView1.Rows.Count > 0)
            {
                this.exDataGridView1.Rows[0].Cells["rs_no"].Selected = true;
                cellclick(0);
            }


            Refresh_save();
        }
        
        private void cellclick(int index)
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();


            cmd.Clear();
            cmd.Append("select * from sys_rs a left join sys_bm b on a.bm_id=b.id	left join sys_xl c on a.xl_id=c.id ");
            cmd.Append("where a.id='" + this.exDataGridView1.Rows[index].Cells["id"].Value + "'");

            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            if (dt.Rows.Count>0)
            {
                this.TextBox3.Text = dt.Rows[0]["rs_name"].ToString();
                this.TextBox2.Text = dt.Rows[0]["rs_no"].ToString();


                this.TextBox8.Text = dt.Rows[0]["Tel"].ToString();
                this.TextBox10.Text = dt.Rows[0]["Home_Address"].ToString();



                this.TextBox5.Text = dt.Rows[0]["memo"].ToString();
                this.TextBox4.Text = dt.Rows[0]["card"].ToString();


                if (dt.Rows[0]["stop"].ToString() == "0")
                {
                    this.CheckBox1.Checked = true;
                }
                else if (dt.Rows[0]["stop"].ToString() == "1")
                {
                    this.CheckBox1.Checked = false;
                }

                if (dt.Rows[0]["hf"].ToString() == "0")
                {
                    this.CheckBox2.Checked = true;
                }
                else if (dt.Rows[0]["hf"].ToString() == "1")
                {
                    this.CheckBox2.Checked = false;
                }


                this.ComboBox1.Text = dt.Rows[0]["xb"].ToString();
                this.ComboBox3.Text = dt.Rows[0]["bm_id"].ToString();
                this.ComboBox5.Text = dt.Rows[0]["xl_id"].ToString();

            }





        }
        private void Refresh_add()
        {
         
            this.TextBox2.Enabled = true;
            this.TextBox3.Enabled = true;
            this.TextBox4.Enabled = true;
            this.TextBox5.Enabled = true;
            this.TextBox8.Enabled = true;
            this.TextBox10.Enabled = true;

            this.ComboBox1.Enabled = true;
            this.ComboBox2.Enabled = true;
            this.ComboBox3.Enabled = true;
            this.ComboBox4.Enabled = true;
            this.ComboBox5.Enabled = true;

            this.CheckBox1.Enabled = true;
            this.CheckBox2.Enabled = true;


            this.ToolStripButton_save.Enabled = true;
            this.ToolStripButton_cancel.Enabled = true;

            this.ToolStripButton_add.Enabled = false;
            this.ToolStripButton_mod.Enabled = false;
            this.ToolStripButton_refresh.Enabled = false;
            this.ToolStripButton_exit.Enabled = false;
            this.ToolStripButton_question.Enabled = false;
            
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
            this.TextBox8.Enabled = false;
            this.TextBox10.Enabled = false;

            this.ComboBox1.Enabled = false;
            this.ComboBox2.Enabled = false;
            this.ComboBox3.Enabled = false;
            this.ComboBox4.Enabled = false;
            this.ComboBox5.Enabled = false;


            this.CheckBox1.Enabled = false;
            this.CheckBox2.Enabled = false;



            this.ToolStripButton_save.Enabled = false;
            this.ToolStripButton_cancel.Enabled = false;

            this.ToolStripButton_add.Enabled = true;
            this.ToolStripButton_mod.Enabled = true;
            this.ToolStripButton_refresh.Enabled = true;
            this.ToolStripButton_exit.Enabled = true;

            this.ToolStripButton_stop.Enabled = true;
            this.ToolStripButton_OK.Enabled = true;
            this.ToolStripButton_question.Enabled = true;


            this.exDataGridView1.Enabled = true;

        }
        #endregion

        
        #region combobox联动的代码
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboBox3.SelectedIndex = this.ComboBox2.SelectedIndex;
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboBox5.SelectedIndex = this.ComboBox4.SelectedIndex;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboBox2.SelectedIndex = this.ComboBox3.SelectedIndex;
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboBox4.SelectedIndex = this.ComboBox5.SelectedIndex;
        }
        #endregion



        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Refresh_ExDataGridView1(" and (a.rs_no like '%" + this.TextBox1.Text.Trim() + "%' or a.rs_name like '%" +this.TextBox1.Text.Trim()+ "%') ");
                this.TextBox1.Text = "";
            }

           
        }

        
        private void employee_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();


            this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ComboBox1.Items.Clear();
            this.ComboBox1.Items.Add("男");
            this.ComboBox1.Items.Add("女");

            cmd.Clear();
            cmd.Append("select * from sys_bm");

            dt=DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            this.ComboBox2.Items.Clear();
            this.ComboBox3.Items.Clear();

            for (int i = 0; i <dt.Rows.Count; i++)
            {
                this.ComboBox2.Items.Add(dt.Rows[i]["bmmc"].ToString());
                this.ComboBox3.Items.Add(dt.Rows[i]["id"].ToString());
            }


            cmd.Clear();
            cmd.Append("select * from sys_xl");

            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];

            this.ComboBox4.Items.Clear();
            this.ComboBox5.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ComboBox4.Items.Add(dt.Rows[i]["xl_name"].ToString());
                this.ComboBox5.Items.Add(dt.Rows[i]["id"].ToString());
            }

            Refresh_ExDataGridView1();

            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.Panel1MinSize = 40;

            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.Panel1MinSize = 250;

            this.splitContainer3.SplitterDistance = 50;
            this.splitContainer3.Panel1MinSize = 50;
        }


        private void exDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }
            else
            {
                cellclick(e.RowIndex);
            }
            
        }

        private void ToolStripButton_add_Click(object sender, EventArgs e)
        {
            Refresh_add();

            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox8.Text = "";
            this.TextBox10.Text = "";

            this.ComboBox1.SelectedIndex = 0;

            this.ComboBox2.SelectedIndex = 0;
            this.ComboBox4.SelectedIndex = 0;

            this.CheckBox1.Checked = false;
            this.CheckBox2.Checked = false;
        }

        private void ToolStripButton_mod_Click(object sender, EventArgs e)
        {
            if (this.exDataGridView1.SelectedCells==null )
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

        private void ToolStripButton_save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            ArrayList AL = new ArrayList();


            try
            {
                if (this.TextBox2.Enabled) //说明是新建
                {
                   


                        cmd.Clear();
                        cmd.AppendLine("INSERT INTO sys_rs(BM_id, Card, Hf, input_date, input_man, memo, modify_date, modify_man, rs_name, rs_no, stop, Xb, xl_id, Tel, Home_Address ");
                        cmd.AppendLine(") values('" + this.ComboBox3.Text.ToString() + "', '" + this.TextBox4.Text.Trim() + "', '" + (this.CheckBox2.Checked ? "0" : "1") + "', getdate(), '" + MDI_Class.rs_name + "', ");
                        cmd.AppendLine("'" + this.TextBox5.Text.Trim() + "', getdate(), '" + MDI_Class.rs_name + "', '" + this.TextBox3.Text.Trim() + "', '" + this.TextBox2.Text.Trim() + "', '" + (this.CheckBox1.Checked ? "0" : "1") + "', ");
                        cmd.AppendLine("'" + this.ComboBox1.Text + "', '" + this.ComboBox5.Text + "', '" + this.TextBox8.Text.Trim() + "', ");
                        cmd.AppendLine("'" + this.TextBox10.Text.Trim() + "')");

                        DBConn.DataAcess.SqlConn.ExecuteSql(cmd.ToString());
                

                    
                    
                }
                else
                {
                    cmd.Clear();
                    cmd.Append("update sys_rs set bm_id='" + this.ComboBox3.Text + "',Card='" + this.TextBox4.Text.Trim() + "',Tel='" + this.TextBox8.Text.Trim() + "',");
                    cmd.Append("Home_Address='" + this.TextBox10.Text.Trim() + "',Hf='" + (this.CheckBox2.Checked ? "0" : "1") + "',");
                    cmd.Append("memo='" + this.TextBox5.Text.Trim() + "',modify_date=getdate(),modify_man='" + MDI_Class.rs_name + "',rs_name='" + this.TextBox3.Text.Trim() + "',stop='" + (this.CheckBox1.Checked ? "0" : "1") + "',Xb='" + this.ComboBox1.Text + "',");
                    cmd.Append("xl_id='" + this.ComboBox5.Text + "' where rs_no='" + this.TextBox2.Text.Trim() + "'");

                    AL.Add(cmd.ToString());

                    
                    if (this.CheckBox1.Checked)
                    {
                        //如果停用了用户则连登陆帐户也停用
                        cmd.Clear();
                        cmd.Append("update sys_user set stop_login=0 where rs_id=" + this.exDataGridView1.Rows[this.exDataGridView1.SelectedCells[0].RowIndex].Cells["id"].Value);
                        AL.Add(cmd.ToString());
                    }
                    
                    DBConn.DataAcess.SqlConn.ExecuteSqlTran(AL);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Refresh_save();
            Refresh_ExDataGridView1();

            MessageBox.Show("保存成功！","成功",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }

        private void ToolStripButton_cancel_Click(object sender, EventArgs e)
        {
            if (this.TextBox3.Enabled && this.exDataGridView1.Rows.Count>0)
            {
                this.exDataGridView1.Rows[0].Cells["rs_no"].Selected = true;
                cellclick(0);
            }
            Refresh_save();
        }

        private void ToolStripButton_refresh_Click(object sender, EventArgs e)
        {
            Refresh_ExDataGridView1();
        }

        private void ToolStripButton_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ToolStripButton_question_Click(object sender, EventArgs e)
        {
            employee_cha employee_cha = new employee_cha();
            this.Tag = "";
            employee_cha.Owner = this;

            employee_cha.ShowDialog();

            if (employee_cha.DialogResult==DialogResult.OK)
            {
                this.Refresh_ExDataGridView1(this.Tag.ToString());
                this.Tag = "";
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
