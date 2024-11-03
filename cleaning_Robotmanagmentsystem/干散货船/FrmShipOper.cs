using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinRobotSystem
{
    public partial class FrmShipOper : Form
    {
        private string _ship_no = "";
        private string _operName = "";
        public FrmShipOper(string ship_no = "")
        {
            InitializeComponent();
            this._ship_no = ship_no;
            if (_ship_no == "")
            {
                _operName = "添加";
            }
            else
            {
                _operName = "修改";
            }
            this.Text = _operName + "货船";
            this.button2.Text = _operName;
        }
        private void FrmShipOper_Load(object sender, EventArgs e)
        {
            //加载机器人信息到下拉框
            DataTable dt = SqlHelper.QueryTable("select no,name from Robot");
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "no";
            this.comboBox1.ValueMember = "no";
            //编辑信息需要把值赋值到控件上
            if (_ship_no != "")
            {
                DataTable dtInfo = SqlHelper.QueryTable("select * from Ship where ship_no='" + _ship_no + "'");
                if (dtInfo.Rows.Count > 0)
                {
                    textBox1.Text = dtInfo.Rows[0]["ship_no"].ToString();
                    textBox2.Text = dtInfo.Rows[0]["type"].ToString();
                    textBox3.Text = dtInfo.Rows[0]["stop_wharf"].ToString();
                    comboBox1.Text = dtInfo.Rows[0]["robot_no"].ToString();
                    textBox4.Text = dtInfo.Rows[0]["voyage"].ToString();
                    textBox5.Text = dtInfo.Rows[0]["interval_time"].ToString();
                    textBox6.Text = dtInfo.Rows[0]["length"].ToString();
                    textBox7.Text = dtInfo.Rows[0]["area"].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ship_no = textBox1.Text.Trim();
            string type = textBox2.Text.Trim();
            string stop_wharf = textBox3.Text.Trim();
            string robot_no = comboBox1.Text.Trim();
            string voyage = textBox4.Text.Trim();
            string interval_time = textBox5.Text.Trim();
            string length = textBox6.Text.Trim();
            string area = textBox7.Text.Trim();
            if (string.IsNullOrEmpty(ship_no))
            {
                MessageBox.Show("请输入编号！");
                return;
            }
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("请输入类型！");
                return;
            }
            if (string.IsNullOrEmpty(stop_wharf))
            {
                MessageBox.Show("请输入经停码头！");
                return;
            }
            if (string.IsNullOrEmpty(robot_no))
            {
                MessageBox.Show("请选择机器人！");
                return;
            }
            if (string.IsNullOrEmpty(voyage))
            {
                MessageBox.Show("请输入目的航程！");
                return;
            }
            if (string.IsNullOrEmpty(interval_time))
            {
                MessageBox.Show("请输入间隔时间！");
                return;
            }
            if (string.IsNullOrEmpty(length))
            {
                MessageBox.Show("请输入长度！");
                return;
            }
            if (string.IsNullOrEmpty(area))
            {
                MessageBox.Show("请输入船舱面积！");
                return;
            }
            //根据主键查询是否已经使用
            string sqlQuery = "select * from Ship where ship_no='" + ship_no + "'";
            if (_ship_no != "")
            {
                sqlQuery += " and ship_no!='" + _ship_no + "'";
            }
            DataTable dt = SqlHelper.QueryTable(sqlQuery);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("该编号已被使用，请更换");
                return;
            }
            string sqlOper = "";
            if (_ship_no == "")
            {
                sqlOper = "insert into Ship Values('" + ship_no + "','" + type + "','" + stop_wharf + "','" + robot_no + "','" + voyage + "','" + interval_time + "','" + length + "','" + area + "')";
            }
            else
            {
                sqlOper = "update Ship set ship_no='" + ship_no + "',type='" + type + "',stop_wharf='" + stop_wharf + "',robot_no='" + robot_no + "',voyage='" + voyage + "',interval_time='" + interval_time + "',length='" + length + "',area='" + area + "' where ship_no='" + _ship_no + "'";
            }
            int r = SqlHelper.ExecuteNonQuery(sqlOper);
            if (r >= 0)
            {
                MessageBox.Show(_operName + "成功");
                this.Close();
                if (this.Owner != null)
                {
                    FrmShipView frmShipView = (FrmShipView)this.Owner;
                    frmShipView.InitData();
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
