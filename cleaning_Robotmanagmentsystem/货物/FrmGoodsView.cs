using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinRobotSystem
{
    public partial class FrmGoodsView : Form
    {
        public FrmGoodsView()
        {
            InitializeComponent();
        }

        private void FrmGoodsView_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitData();
        }

        public void InitData()
        {
            string key = textBox1.Text.Trim();
            string sql = "select * from Goods";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " where goods_no like '%" + key + "%'";
            }
            DataTable dt = SqlHelper.QueryTable(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGoodsOper frmGoodsOper = new FrmGoodsOper();
            frmGoodsOper.Owner = this;
            frmGoodsOper.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string goods_no = dataGridView1.CurrentRow.Cells["货物编号"].Value.ToString();
                FrmGoodsOper frmGoodsOper = new FrmGoodsOper(goods_no);
                frmGoodsOper.Owner = this;
                frmGoodsOper.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择要操作的数据");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string goods_no = dataGridView1.CurrentRow.Cells["货物编号"].Value.ToString();
                int r = SqlHelper.ExecuteNonQuery("delete from Goods where goods_no='" + goods_no + "'");
                if (r >= 0)
                {
                    MessageBox.Show("删除成功");
                    InitData();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else
            {
                MessageBox.Show("请选择要操作的数据");
            }
        }
    }
}
