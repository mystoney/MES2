using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = DBCon.DBUtility.DESEncrypt.Encrypt(textBox2.Text);
        }

        private void Decrypt_Load(object sender, EventArgs e)
        {

        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            string s = DBConn.AllConn.connectionString;
            textBox1.Text = s;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = DBCon.DBUtility.DESEncrypt.Decrypt(textBox1.Text);
        }


    }
}
