using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinRobotSystem
{
    public partial class FrmUserOper : Form
    {
        private int _id = 0;
        private string _operName = "";
        public FrmUserOper(int id)
        {
            InitializeComponent();
            this._id = id;
            if (_id == 0)
            {
                _operName = "添加";
            }
            else
            {
                _operName = "修改";
            }
            this.Text = _operName + "用户";
            this.button2.Text = _operName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUserOper_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                DataTable dtInfo = SqlHelper.QueryTable("select * from Admin where id='" + _id + "'");
                if (dtInfo.Rows.Count > 0)
                {
                    textBox1.Text = dtInfo.Rows[0]["user_account"].ToString();
                    textBox2.Text = dtInfo.Rows[0]["password"].ToString();
                    if (_id == Common.id)
                    {
                        textBox1.ReadOnly = true;
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(account))
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            //根据用户名查询是否已经被使用
            string sqlQuery = "select * from Admin where user_account='" + account + "'";
            if (_id > 0)
            {
                sqlQuery += " and id!='" + _id + "'";
            }
            DataTable dt = SqlHelper.QueryTable(sqlQuery);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("该用户名已被使用，请更换");
                return;
            }
            string sqlOper = "";
            if (_id == 0)
            {
                sqlOper = "insert into Admin Values('" + account + "','" + password + "')";
            }
            else
            {
                sqlOper = "update Admin set user_account='" + account + "',password='" + password + "' where id='" + _id + "'";
            }
            int r = SqlHelper.ExecuteNonQuery(sqlOper);
            if (r >= 0)
            {
                MessageBox.Show(_operName + "成功");
                this.Close();
                if (this.Owner != null)
                {
                    FrmUserView frmUserView = (FrmUserView)this.Owner;
                    frmUserView.InitData();
                }
            }
            else
            {
                MessageBox.Show(_operName + "失败");
            }
        }

    }
}
