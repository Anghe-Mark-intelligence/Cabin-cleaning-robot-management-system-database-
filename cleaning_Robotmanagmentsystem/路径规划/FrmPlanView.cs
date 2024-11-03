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
    public partial class FrmPlanView : Form
    {
        public FrmPlanView()
        {
            InitializeComponent();
        }

        private void FrmPlanView_Load(object sender, EventArgs e)
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
            string sql = "select Robot_Plan.*,Robot.name from Robot_Plan left join Robot on robot_no=no";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " where plan_no like '%" + key + "%'";
            }
            DataTable dt = SqlHelper.QueryTable(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPlanOper frmPlanOper = new FrmPlanOper("");
            frmPlanOper.Owner = this;
            frmPlanOper.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string plan_no = dataGridView1.CurrentRow.Cells["路径编号"].Value.ToString();
                FrmPlanOper frmPlanOper = new FrmPlanOper(plan_no);
                frmPlanOper.Owner = this;
                frmPlanOper.ShowDialog();
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
                string plan_no = dataGridView1.CurrentRow.Cells["路径编号"].Value.ToString();
                int r = SqlHelper.ExecuteNonQuery("delete from Robot_Plan where plan_no='" + plan_no + "'");
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
