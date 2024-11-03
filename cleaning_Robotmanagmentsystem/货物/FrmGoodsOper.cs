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
    public partial class FrmGoodsOper : Form
    {
        private string _goods_no = "";
        private string _operName = "";
        public FrmGoodsOper(string goods_no = "")
        {
            InitializeComponent();
            this._goods_no = goods_no;
            if (_goods_no == "")
            {
                _operName = "添加";
            }
            else
            {
                _operName = "修改";
            }
            this.Text = _operName + "货物";
            this.button2.Text = _operName;
        }

        private void FrmGoodsOper_Load(object sender, EventArgs e)
        {
            //加载散货船信息到下拉框
            DataTable dtShip = SqlHelper.QueryTable("select ship_no from Ship");
            this.comboBox1.DataSource = dtShip;
            this.comboBox1.DisplayMember = "ship_no";
            this.comboBox1.ValueMember = "ship_no";

            if (this._goods_no != "")
            {
                DataTable dt = SqlHelper.QueryTable("select * from Goods where goods_no='" + this._goods_no + "'");
                if (dt.Rows.Count > 0)
                {
                    textBox1.Text = dt.Rows[0]["goods_no"].ToString();
                    textBox2.Text = dt.Rows[0]["start_address"].ToString();
                    textBox3.Text = dt.Rows[0]["transport_address"].ToString();
                    comboBox1.Text = dt.Rows[0]["ship_no"].ToString();
                    comboBox2.Text = dt.Rows[0]["is_liquid"].ToString();
                    textBox4.Text = dt.Rows[0]["count"].ToString();
                    textBox5.Text = dt.Rows[0]["weight"].ToString();
                }
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string goods_no = textBox1.Text.Trim();
            string start_address = textBox2.Text.Trim();
            string transport_address = textBox3.Text.Trim();
            string ship_no = comboBox1.Text.Trim();
            string is_liquid = comboBox2.Text.Trim();
            string count = textBox4.Text.Trim();
            string weight = textBox5.Text.Trim();
            if (string.IsNullOrEmpty(goods_no))
            {
                MessageBox.Show("请输入编号！");
                return;
            }
            if (string.IsNullOrEmpty(start_address))
            {
                MessageBox.Show("请输入始发地址！");
                return;
            }
            if (string.IsNullOrEmpty(transport_address))
            {
                MessageBox.Show("请输入运输地址！");
                return;
            }
            if (string.IsNullOrEmpty(ship_no))
            {
                MessageBox.Show("请选择散货船！");
                return;
            }
            if (string.IsNullOrEmpty(is_liquid))
            {
                MessageBox.Show("请选择是否为液体！");
                return;
            }
            if (string.IsNullOrEmpty(count))
            {
                MessageBox.Show("请输入数量！");
                return;
            }
            if (string.IsNullOrEmpty(weight))
            {
                MessageBox.Show("请输入重量！");
                return;
            }
            //根据主键查询是否已经使用
            string sqlQuery = "select * from Goods where goods_no='" + goods_no + "'";
            if (_goods_no != "")
            {
                sqlQuery += " and goods_no!='" + _goods_no + "'";
            }
            DataTable dt = SqlHelper.QueryTable(sqlQuery);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("该编号已被使用，请更换");
                return;
            }
            string sqlOper = "";
            if (_goods_no == "")
            {
                sqlOper = "insert into Goods Values('" + goods_no + "','" + start_address + "','" + transport_address + "','" + ship_no + "','" + is_liquid + "','" + count + "','" + weight + "')";
            }
            else
            {
                sqlOper = "update Goods set goods_no='" + goods_no + "',start_address='" + start_address + "',transport_address='" + transport_address + "',ship_no='" + ship_no + "',is_liquid='" + is_liquid + "',count='" + count + "',weight='" + weight + "' where goods_no='" + _goods_no + "'";
            }
            int r = SqlHelper.ExecuteNonQuery(sqlOper);
            if (r >= 0)
            {
                MessageBox.Show(_operName + "成功");
                this.Close();
                if (this.Owner != null)
                {
                    FrmGoodsView frmGoodsView = (FrmGoodsView)this.Owner;
                    frmGoodsView.InitData();
                }
            }
            else
            {
                MessageBox.Show(_operName + "失败");
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
