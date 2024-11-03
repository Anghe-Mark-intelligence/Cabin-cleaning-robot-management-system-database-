#HEANG 2024.8.10 https://github.com/Anghe-Mark-intelligence
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinRobotSystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(account))
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码");
                return;
            }
            DataTable dt = SqlHelper.QueryTable("select * from Admin where user_account='" + account + "' and password='" + password + "'");
            if (dt.Rows.Count > 0)
            {
                Common.id = int.Parse(dt.Rows[0]["id"].ToString());
                Common.account = account;
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("登录账号或密码错误，请检查！");
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
