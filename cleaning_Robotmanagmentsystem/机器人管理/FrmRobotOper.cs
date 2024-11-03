using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinRobotSystem
{
    public partial class FrmRobotOper : Form
    {
        private string _no = "";
        private string _operName = "";
        public FrmRobotOper(string no = "")
        {
            InitializeComponent();
            this._no = no;
            if (_no == "")
            {
                _operName = "添加";
            }
            else
            {
                _operName = "修改";
            }
            this.Text = _operName + "机器人";
            this.button2.Text = _operName;
        }

        private void FrmRobotOper_Load(object sender, EventArgs e)
        {
            if (this._no != "")
            {
                DataTable dt = SqlHelper.QueryTable("select * from Robot where no='" + this._no + "'");
                if (dt.Rows.Count > 0)
                {
                    textBox1.Text = dt.Rows[0]["no"].ToString();
                    textBox2.Text = dt.Rows[0]["category"].ToString();
                    textBox3.Text = dt.Rows[0]["name"].ToString();
                    textBox4.Text = dt.Rows[0]["generate_manufacturer"].ToString();
                    textBox5.Text = dt.Rows[0]["use_date"].ToString();
                    textBox6.Text = dt.Rows[0]["quantity_electricity"].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string no = textBox1.Text.Trim();
            string name = textBox3.Text.Trim();
            string category = textBox2.Text.Trim();
            string generate_manufacturer = textBox4.Text.Trim();
            string use_date = textBox5.Text.Trim();
            string quantity_electricity = textBox6.Text.Trim();
            if (string.IsNullOrEmpty(no))
            {
                MessageBox.Show("请输入编号！");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入名称！");
                return;
            }
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("请输入类型！");
                return;
            }
            if (string.IsNullOrEmpty(generate_manufacturer))
            {
                MessageBox.Show("请输入生产厂家！");
                return;
            }
            if (string.IsNullOrEmpty(use_date))
            {
                MessageBox.Show("请输入使用时间！");
                return;
            }
            if (string.IsNullOrEmpty(quantity_electricity))
            {
                MessageBox.Show("请输入电量！");
                return;
            }
            //根据主键查询是否已经使用
            string sqlQuery = "select * from Robot where no='" + no + "'";
            if (_no != "")
            {
                sqlQuery += " and no!='" + _no + "'";
            }
            DataTable dt = SqlHelper.QueryTable(sqlQuery);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("该编号已被使用，请更换");
                return;
            }
            string sqlOper = "";
            if (_no == "")
            {
                sqlOper = "insert into Robot Values('" + no + "','" + name + "','" + category + "','" + generate_manufacturer + "','" + use_date + "','" + quantity_electricity + "')";
            }
            else
            {
                sqlOper = "update Robot set no='" + no + "',name='" + name + "',category='" + category + "',generate_manufacturer='" + generate_manufacturer + "',use_date='" + use_date + "',quantity_electricity='" + quantity_electricity + "' where no='" + _no + "'";
            }
            int r = SqlHelper.ExecuteNonQuery(sqlOper);
            if (r >= 0)
            {
                MessageBox.Show(_operName + "成功");
                this.Close();
                if (this.Owner != null)
                {
                    FrmRobotView frmRobotView = (FrmRobotView)this.Owner;
                    frmRobotView.InitData();
                }
            }
            else
            {
                MessageBox.Show(_operName + "失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
