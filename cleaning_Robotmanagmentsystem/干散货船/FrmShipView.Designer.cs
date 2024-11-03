namespace WinRobotSystem
{
    partial class FrmShipView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.散货船编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.经停码头 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机器人编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.目的航程 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.间隔时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.长度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.船舱面积大小 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.散货船编号,
            this.类型,
            this.经停码头,
            this.机器人编号,
            this.目的航程,
            this.间隔时间,
            this.长度,
            this.船舱面积大小});
            this.dataGridView1.Location = new System.Drawing.Point(26, 96);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1550, 780);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1024, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1228, 24);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1426, 24);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(590, 22);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 46);
            this.button4.TabIndex = 4;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 35);
            this.textBox1.TabIndex = 5;
            // 
            // 散货船编号
            // 
            this.散货船编号.DataPropertyName = "ship_no";
            this.散货船编号.HeaderText = "散货船编号";
            this.散货船编号.MinimumWidth = 10;
            this.散货船编号.Name = "散货船编号";
            this.散货船编号.Width = 200;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "type";
            this.类型.HeaderText = "类型";
            this.类型.MinimumWidth = 10;
            this.类型.Name = "类型";
            this.类型.Width = 200;
            // 
            // 经停码头
            // 
            this.经停码头.DataPropertyName = "stop_wharf";
            this.经停码头.HeaderText = "经停码头";
            this.经停码头.MinimumWidth = 10;
            this.经停码头.Name = "经停码头";
            this.经停码头.Width = 200;
            // 
            // 机器人编号
            // 
            this.机器人编号.DataPropertyName = "robot_no";
            this.机器人编号.HeaderText = "机器人编号";
            this.机器人编号.MinimumWidth = 10;
            this.机器人编号.Name = "机器人编号";
            this.机器人编号.Width = 200;
            // 
            // 目的航程
            // 
            this.目的航程.DataPropertyName = "voyage";
            this.目的航程.HeaderText = "目的航程";
            this.目的航程.MinimumWidth = 10;
            this.目的航程.Name = "目的航程";
            this.目的航程.Width = 200;
            // 
            // 间隔时间
            // 
            this.间隔时间.DataPropertyName = "interval_time";
            this.间隔时间.HeaderText = "间隔时间";
            this.间隔时间.MinimumWidth = 10;
            this.间隔时间.Name = "间隔时间";
            this.间隔时间.Width = 200;
            // 
            // 长度
            // 
            this.长度.DataPropertyName = "length";
            this.长度.HeaderText = "长度";
            this.长度.MinimumWidth = 10;
            this.长度.Name = "长度";
            this.长度.Width = 200;
            // 
            // 船舱面积大小
            // 
            this.船舱面积大小.DataPropertyName = "area";
            this.船舱面积大小.HeaderText = "船舱面积大小";
            this.船舱面积大小.MinimumWidth = 10;
            this.船舱面积大小.Name = "船舱面积大小";
            this.船舱面积大小.Width = 200;
            // 
            // FrmShipView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmShipView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货船管理";
            this.Load += new System.EventHandler(this.FrmShipView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 散货船编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 经停码头;
        private System.Windows.Forms.DataGridViewTextBoxColumn 机器人编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 目的航程;
        private System.Windows.Forms.DataGridViewTextBoxColumn 间隔时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 长度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 船舱面积大小;
    }
}