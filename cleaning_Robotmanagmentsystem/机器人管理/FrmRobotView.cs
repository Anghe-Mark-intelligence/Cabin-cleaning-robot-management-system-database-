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
    public partial class FrmRobotView : Form
    {
        public FrmRobotView()
        {
            InitializeComponent();
        }

        private void FrmRobotView_Load(object sender, EventArgs e)
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
            string sql = "select * from Robot";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " where name like '%" + key + "%'";
            }
            DataTable dt = SqlHelper.QueryTable(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRobotOper frmRobotOper = new FrmRobotOper();
            frmRobotOper.Owner = this;
            frmRobotOper.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string no = dataGridView1.CurrentRow.Cells["机器人编号"].Value.ToString();
                FrmRobotOper frmRobotOper = new FrmRobotOper(no);
                frmRobotOper.Owner = this;
                frmRobotOper.ShowDialog();
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
                string no = dataGridView1.CurrentRow.Cells["机器人编号"].Value.ToString();
                int r = SqlHelper.ExecuteNonQuery("delete from Robot where no='" + no + "'");
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
