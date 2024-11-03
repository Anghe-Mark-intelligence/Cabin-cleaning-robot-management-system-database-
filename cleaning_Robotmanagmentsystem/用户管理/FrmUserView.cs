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
    public partial class FrmUserView : Form
    {
        public FrmUserView()
        {
            InitializeComponent();
        }


        private void FrmUserView_Load(object sender, EventArgs e)
        {
            InitData();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            InitData();
        }

        public void InitData()
        {
            string key = textBox1.Text.Trim();
            string sql = "select * from Admin";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " where user_account like '%" + key + "%'";
            }
            DataTable dt = SqlHelper.QueryTable(sql);
            this.dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUserOper frmUserOper = new FrmUserOper(0);
            frmUserOper.Owner = this;
            frmUserOper.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                FrmUserOper frmUserOper = new FrmUserOper(id);
                frmUserOper.Owner = this;
                frmUserOper.ShowDialog();
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
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                if (id == Common.id)
                {
                    MessageBox.Show("不能删除自己的账号");
                }
                else
                {
                    int r = SqlHelper.ExecuteNonQuery("delete from Admin where id='" + id + "'");
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
            }
            else
            {
                MessageBox.Show("请选择要操作的数据");
            }
        }
    }
}
