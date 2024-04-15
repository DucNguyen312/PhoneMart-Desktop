namespace QLCHDT.GUI
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbldoanhthungay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblsosp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblsodonhang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.flptopsp = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpngayd = new System.Windows.Forms.DateTimePicker();
            this.dtpngayt = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXuatThongKe = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(50)))), ((int)(((byte)(193)))));
            this.panel1.Controls.Add(this.lbldoanhthungay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(367, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 100);
            this.panel1.TabIndex = 0;
            // 
            // lbldoanhthungay
            // 
            this.lbldoanhthungay.AutoSize = true;
            this.lbldoanhthungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbldoanhthungay.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbldoanhthungay.Location = new System.Drawing.Point(23, 48);
            this.lbldoanhthungay.Name = "lbldoanhthungay";
            this.lbldoanhthungay.Size = new System.Drawing.Size(79, 25);
            this.lbldoanhthungay.TabIndex = 2;
            this.lbldoanhthungay.Text = "0 VND";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doanh Thu Trong Ngày :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(50)))), ((int)(((byte)(193)))));
            this.panel2.Controls.Add(this.lblsosp);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(56, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 100);
            this.panel2.TabIndex = 1;
            // 
            // lblsosp
            // 
            this.lblsosp.AutoSize = true;
            this.lblsosp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsosp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblsosp.Location = new System.Drawing.Point(101, 48);
            this.lblsosp.Name = "lblsosp";
            this.lblsosp.Size = new System.Drawing.Size(25, 25);
            this.lblsosp.TabIndex = 3;
            this.lblsosp.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(2, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Sản Phẩm Bán Trong Ngày :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(50)))), ((int)(((byte)(193)))));
            this.panel3.Controls.Add(this.lblsodonhang);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(678, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 100);
            this.panel3.TabIndex = 1;
            // 
            // lblsodonhang
            // 
            this.lblsodonhang.AutoSize = true;
            this.lblsodonhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblsodonhang.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblsodonhang.Location = new System.Drawing.Point(108, 48);
            this.lblsodonhang.Name = "lblsodonhang";
            this.lblsodonhang.Size = new System.Drawing.Size(25, 25);
            this.lblsodonhang.TabIndex = 4;
            this.lblsodonhang.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(1, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Đơn Hàng Bán Trong Ngày :";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(56, 235);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.LegendText = "Doanh thu";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(553, 300);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title1.Name = "Title1";
            title1.Text = "BIỂU ĐỔ DOANH THU";
            this.chart1.Titles.Add(title1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(675, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Top 3 sản phẩm bán chạy nhất :";
            // 
            // flptopsp
            // 
            this.flptopsp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flptopsp.Location = new System.Drawing.Point(678, 201);
            this.flptopsp.Name = "flptopsp";
            this.flptopsp.Size = new System.Drawing.Size(242, 342);
            this.flptopsp.TabIndex = 5;
            // 
            // dtpngayd
            // 
            this.dtpngayd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayd.Location = new System.Drawing.Point(248, 22);
            this.dtpngayd.Name = "dtpngayd";
            this.dtpngayd.Size = new System.Drawing.Size(117, 20);
            this.dtpngayd.TabIndex = 6;
            // 
            // dtpngayt
            // 
            this.dtpngayt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayt.Location = new System.Drawing.Point(70, 22);
            this.dtpngayt.Name = "dtpngayt";
            this.dtpngayt.Size = new System.Drawing.Size(117, 20);
            this.dtpngayt.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXuatThongKe);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpngayd);
            this.groupBox2.Controls.Add(this.dtpngayt);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(56, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 55);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tra cứu";
            // 
            // btnXuatThongKe
            // 
            this.btnXuatThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(50)))), ((int)(((byte)(193)))));
            this.btnXuatThongKe.FlatAppearance.BorderSize = 0;
            this.btnXuatThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatThongKe.Location = new System.Drawing.Point(452, 20);
            this.btnXuatThongKe.Name = "btnXuatThongKe";
            this.btnXuatThongKe.Size = new System.Drawing.Size(95, 23);
            this.btnXuatThongKe.TabIndex = 12;
            this.btnXuatThongKe.Text = "Xuất Thống Kê";
            this.btnXuatThongKe.UseVisualStyleBackColor = false;
            this.btnXuatThongKe.Click += new System.EventHandler(this.btnXuatThongKe_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(50)))), ((int)(((byte)(193)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(371, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Text = "Tra cứu";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đến :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Từ ngày :";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(992, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.flptopsp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldoanhthungay;
        private System.Windows.Forms.Label lblsosp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblsodonhang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flptopsp;
        private System.Windows.Forms.DateTimePicker dtpngayd;
        private System.Windows.Forms.DateTimePicker dtpngayt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXuatThongKe;
    }
}