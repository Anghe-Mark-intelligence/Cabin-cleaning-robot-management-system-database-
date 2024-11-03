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
    public partial class FrmPlanOper : Form
    {
        private string _plan_no = "";
        private string _operName = "";
        public FrmPlanOper(string plan_no)
        {
            InitializeComponent();
            this._plan_no = plan_no;
            if (_plan_no == "")
            {
                _operName = "添加";
            }
            else
            {
                _operName = "修改";
            }
            this.Text = _operName + "路径";
            this.button2.Text = _operName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmPlanOper_Load(object sender, EventArgs e)
        {
            DataTable dtRobot = SqlHelper.QueryTable("select no,name from Robot");
            comboBox1.DataSource = dtRobot;
            comboBox1.ValueMember = "no";

            if (this._plan_no != "")
            {
                DataTable dt = SqlHelper.QueryTable("select * from Robot_Plan where plan_no='" + this._plan_no + "'");
                if (dt.Rows.Count > 0)
                {
                    textBox1.Text = dt.Rows[0]["plan_no"].ToString();
                    textBox2.Text = dt.Rows[0]["length"].ToString();
                    textBox3.Text = dt.Rows[0]["count"].ToString();
                    comboBox1.Text = dt.Rows[0]["robot_no"].ToString();
                    comboBox2.Text = dt.Rows[0]["is_need_avoid"].ToString();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string plan_no = textBox1.Text.Trim();
            string length = textBox2.Text.Trim();
            string count = textBox3.Text.Trim();
            string robot_no = comboBox1.Text.Trim();
            string is_need_avoid = comboBox2.Text.Trim();
            if (string.IsNullOrEmpty(plan_no))
            {
                MessageBox.Show("请输入路径编号！");
                return;
            }
            if (string.IsNullOrEmpty(robot_no))
            {
                MessageBox.Show("请选择机器人编号！");
                return;
            }
            if (string.IsNullOrEmpty(length))
            {
                MessageBox.Show("请输入长度！");
                return;
            }
            if (string.IsNullOrEmpty(count))
            {
                MessageBox.Show("请输入障碍物数量！");
                return;
            }
            if (string.IsNullOrEmpty(is_need_avoid))
            {
                MessageBox.Show("请选择是否需要避障！");
                return;
            }
            //根据主键查询是否已经使用
            string sqlQuery = "select * from Robot_Plan where plan_no='" + plan_no + "'";
            if (_plan_no != "")
            {
                sqlQuery += " and plan_no!='" + _plan_no + "'";
            }
            DataTable dt = SqlHelper.QueryTable(sqlQuery);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("该路径编号已被使用，请更换");
                return;
            }
            string sqlOper = "";
            if (_plan_no == "")
            {
                sqlOper = "insert into Robot_Plan Values('" + plan_no + "','" + comboBox1.SelectedValue.ToString() + "','" + length + "','" + count + "','" + is_need_avoid + "')";
            }
            else
            {
                sqlOper = "update Robot_Plan set plan_no='" + plan_no + "',robot_no='" + comboBox1.SelectedValue.ToString() + "',length='" + length + "',count='" + count + "',is_need_avoid='" + is_need_avoid + "' where plan_no='" + _plan_no + "'";
            }
            int r = SqlHelper.ExecuteNonQuery(sqlOper);
            if (r >= 0)
            {
                MessageBox.Show(_operName + "成功");
                this.Close();
                if (this.Owner != null)
                {
                    FrmPlanView frmPlanView = (FrmPlanView)this.Owner;
                    frmPlanView.InitData();
                }
            }
            else
            {
                MessageBox.Show(_operName + "失败");
            }
        }
    }
}
