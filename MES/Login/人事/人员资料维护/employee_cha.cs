using System;
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
    public partial class employee_cha : Form
    {
        public employee_cha()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s = "";
           // string s1 = "";

            if (this.CheckBox1.Checked)
            {
                s = s + " and a.rs_name like '%" + TextBox6.Text.Trim() + "%'";
            }

            if (this.CheckBox2.Checked)
            {
                s = s + " and a.rs_no like '%" + this.TextBox3.Text.Trim() + "%'";
            }

            if (this.CheckBox4.Checked)
            {
                s = s + " and a.Xb = '" + this.ComboBox3.Text.Trim() + "'";
            }

            if (this.CheckBox7.Checked)
            {
                s = s + " and a.Hf = " + this.ComboBox5.SelectedIndex + "";
            }

            if (this.CheckBox5.Checked)
            {
                s = s + " and a.Card like '%" + this.TextBox7.Text.Trim() + "%'";
            }



            if (this.CheckBox9.Checked ){
                s = s + " and a.Tel like '%" + this.TextBox8.Text.Trim() + "%'";
            }





            if (this.CheckBox26.Checked ){
                s = s + " and a.memo like '%" + this.TextBox5.Text.Trim() + "%'";
            }


            this.Owner.Tag = s;
            this.DialogResult = DialogResult.OK;
            
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox3.Text.Trim().ToString().Length!=0)
            {
                this.CheckBox2.Checked = true;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox1.Checked)
            {
                this.TextBox6.Text = "";
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox2.Checked)
            {
                this.TextBox3.Text = "";
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

            if (!this.CheckBox4.Checked)
            {
                this.ComboBox3.SelectedIndex = -1;
            }
        }

        private void employee_cha_Load(object sender, EventArgs e)
        {
            StringBuilder cmd = new StringBuilder();
            DataTable dt = new DataTable();

            #region 部门
            this.ComboBox1.Items.Clear();
            this.ComboBox16.Items.Clear();

            cmd.Clear();
            cmd.Append("select * from sys_bm");
            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ComboBox1.Items.Add(dt.Rows[i]["id"].ToString());
                this.ComboBox16.Items.Add(dt.Rows[i]["bmmc"].ToString());
            }
            #endregion

            #region 文化程度
            this.ComboBox11.Items.Clear();
            this.ComboBox4.Items.Clear();

            cmd.Clear();
            cmd.Append("select * from sys_xl");
            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ComboBox11.Items.Add(dt.Rows[i]["xl_name"].ToString());
                this.ComboBox4.Items.Add(dt.Rows[i]["id"].ToString());
            }
            #endregion

            #region 性别
            this.ComboBox3.Items.Clear();
            
            this.ComboBox3.Items.Add("男");
            this.ComboBox3.Items.Add("女");

            #endregion

            #region 婚否
            this.ComboBox5.Items.Clear();
            
            this.ComboBox5.Items.Add("已婚");
            this.ComboBox5.Items.Add("未婚");
            #endregion
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox6.Text.Trim().ToString().Length != 0)
            {
                this.CheckBox1.Checked = true;
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox3.SelectedIndex!=-1)
            {
                this.CheckBox4.Checked = true;
            }
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox5.SelectedIndex != -1)
            {
                this.CheckBox7.Checked = true;
            }
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox7.Text.Trim().Length!=0)
            {
                this.CheckBox5.Checked = true;
            }
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox8.Text.Trim().Length != 0)
            {
                this.CheckBox9.Checked = true;
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox5.Text.Trim().Length != 0)
            {
                this.CheckBox26.Checked = true;
            }
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {

            if (!this.CheckBox7.Checked)
            {
                this.ComboBox5.SelectedIndex = -1;
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

            if (!this.CheckBox5.Checked)
            {
                this.TextBox7.Text = "";
            }
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox9.Checked)
            {
                this.TextBox8.Text = "";
            }
        }

        private void CheckBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox26.Checked)
            {
                this.TextBox5.Text = "";
            }
        }

        private void ComboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox16.SelectedIndex != -1)
            {
                this.CheckBox3.Checked = true;
            }
        }

        private void ComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComboBox11.SelectedIndex != -1)
            {
                this.CheckBox6.Checked = true;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox3.Checked)
            {
                this.ComboBox16.SelectedIndex = -1;
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.CheckBox6.Checked)
            {
                this.ComboBox11.SelectedIndex = -1;
            }
        }
    }
}
