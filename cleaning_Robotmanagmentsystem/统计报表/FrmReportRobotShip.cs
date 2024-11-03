using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinRobotSystem
{
    public partial class FrmReportRobotShip : Form
    {
        public FrmReportRobotShip()
        {
            InitializeComponent();
        }

        private void FrmReportRobotShip_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            string robot_no = textBox1.Text.Trim();
            string ship_no = textBox2.Text.Trim();
            SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("robot_no",robot_no),
                new SqlParameter("ship_no",ship_no),
            };
            DataTable dt = SqlHelper.QueryTable("pro_getRobotShipInfo", CommandType.StoredProcedure, p);
            dataGridView1.DataSource = dt;
        }
    }
}
