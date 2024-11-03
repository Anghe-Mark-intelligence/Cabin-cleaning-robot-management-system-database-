#HEANGMAGIC1 https://github.com/Anghe-Mark-intelligence
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            label1.Text = "欢迎用户：" + Common.account + "!";
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserOper frmUserOper = new FrmUserOper(0);
            frmUserOper.Show();
        }

        private void 查看用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserView frmUserView = new FrmUserView();
            frmUserView.Show();
        }

        private void 添加机器人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRobotOper frmRobotOper = new FrmRobotOper();
            frmRobotOper.Show();
        }

        private void 查看机器人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRobotView frmRobotView = new FrmRobotView();
            frmRobotView.Show();
        }

        private void 添加路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanOper frmPlanOper = new FrmPlanOper("");
            frmPlanOper.Show();
        }

        private void 查看路径信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanView frmPlanView = new FrmPlanView();
            frmPlanView.Show();
        }

        private void 添加货船信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShipOper frmShipOper = new FrmShipOper("");
            frmShipOper.Show();
        }

        private void 查看货船信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShipView frmShipView = new FrmShipView();
            frmShipView.Show();
        }

        private void 添加货物信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGoodsOper frmGoodsOper = new FrmGoodsOper("");
            frmGoodsOper.Show();
        }

        private void 查看货物信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGoodsView frmGoodsView = new FrmGoodsView();
            frmGoodsView.Show();
        }

        private void 统计机器人路径数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportRobotPlanCount frmReportRobotPlanCount = new FrmReportRobotPlanCount();
            frmReportRobotPlanCount.Show();
        }

        private void 统计机器人货船数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportRobotShip frmReportRobotShip = new FrmReportRobotShip();
            frmReportRobotShip.Show();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
