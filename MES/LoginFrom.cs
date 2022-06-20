using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.form
{
    
    public partial class LoginFrom : Form
    {
        private int k=0;
        public LoginFrom()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder cmd = new StringBuilder();

            if (this.PasswordTextBox.Text.Length==0)
            {
                MessageBox.Show("不允许空密码登录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cmd.Clear();
            cmd.Append("select * from view_login where login_id='" + this.UsernameTextBox.Text.Trim() + "' and new_pwd='" + this.PasswordTextBox.Text + "' and stop_login=1");

            dt.Clear();
            dt = DBConn.DataAcess.SqlConn.Query(cmd.ToString()).Tables[0];


            if (dt.Rows.Count==1)
            {
                MDI_Class.login_id = dt.Rows[0]["login_id"].ToString();

                if (MDI_Class.login_id=="admin")
                {
                    MDI_Class.rs_name = "系统管理员";
                    MDI_Class.RS_ID = 0;
                }
                else
                {
                    MDI_Class.rs_name = dt.Rows[0]["rs_name"].ToString();
                    MDI_Class.RS_ID = Convert.ToInt32(dt.Rows[0]["rs_id"].ToString());
                }


                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["UserName"].Value = MDI_Class.login_id;
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                k = k + 1;
                if (k==3)
                {
                    MessageBox.Show("输入错三次密码,系统关闭！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误,请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }



            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginFrom_Load(object sender, EventArgs e)
        {

            StringBuilder cmd = new StringBuilder();

            //string[] files;

            //string[] CMD;
            string[] myArg;

            //Boolean b = false;
            //string[] s = null;

            //string path = "";

            myArg = System.Environment.GetCommandLineArgs();

           // s = Regex.Split(myArg[0],"\\");

            //s[s.Length - 1].Trim();

            /*-------------这块注释就是自动更新的程序，可以以后需要时取消注释-----------------
#if !DEBUG

            cmd.Clear();
            cmd.Append("select update_path from t_update where name='" + s[s.Length - 1].Trim().Replace(".exe", "") + "'");
            path = DBConn.DataAcess.SqlConn.GetSingle(cmd.ToString()).ToString();

            files = System.IO.Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                CMD = Regex.Split(files[i], "\\");
                CMD[CMD.Length - 1].Trim();

                if (File.Exists(Application.StartupPath.ToString()+"\\"+CMD[CMD.Length-1].Trim()))
                {
                    if (File.GetLastWriteTime(files[i])>File.GetLastWriteTime(Application.StartupPath.ToArray()+"\\"+CMD[CMD.Length-1].Trim()))
                    {
                        b = true;
                    }
                }
                else
                {
                    b = true;
                }
            }

            if (b)
            {
                Process process = new Process();
                //process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = Application.StartupPath + "\\自动更新.exe /" + s[s.Length - 1].Trim().Replace(".exe", "");
                //process.StartInfo.CreateNoWindow = true;
                process.Start();

                this.Close();
            }


#endif
*/
           

           this.UsernameTextBox.Text= System.Configuration.ConfigurationManager.AppSettings["UserName"];  //通过属性索引获取值
            if (this.UsernameTextBox.Text == "")
            {
                UsernameTextBox.Select();
            }
            else
            {
                PasswordTextBox.Select();
            }

        }

   
    }
}
