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
    public partial class FrmReportRobotPlanCount : Form
    {
        public FrmReportRobotPlanCount()
        {
            InitializeComponent();
        }

        private void FrmReportRobotPlanCount_Load(object sender, EventArgs e)
        {
            DataTable dt = SqlHelper.QueryTable("select * from v_robotPlan");
            this.dataGridView1.DataSource = dt;
        }
    }
}
