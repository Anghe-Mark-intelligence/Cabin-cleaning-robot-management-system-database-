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
    public partial class FrmShipView : Form
    {
        public FrmShipView()
        {
            InitializeComponent();
        }

        private void FrmShipView_Load(object sender, EventArgs e)
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
            string sql = "select * from Ship";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " where ship_no like '%" + key + "%'";
            }
            DataTable dt = SqlHelper.QueryTable(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmShipOper frmShipOper = new FrmShipOper();
            frmShipOper.Owner = this;
            frmShipOper.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string ship_no = dataGridView1.CurrentRow.Cells["散货船编号"].Value.ToString();
                FrmShipOper frmShipOper = new FrmShipOper(ship_no);
                frmShipOper.Owner = this;
                frmShipOper.ShowDialog();
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
                string ship_no = dataGridView1.CurrentRow.Cells["散货船编号"].Value.ToString();
                int r = SqlHelper.ExecuteNonQuery("delete from Ship where ship_no='" + ship_no + "'");
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
