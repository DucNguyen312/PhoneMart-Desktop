using QLCHDT.DAO;
using QLCHDT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHDT.GUI
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        private string duongdan = Environment.CurrentDirectory + @"\img_sp\";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void DoanhThu()
        {
            DataTable dt = new DataTable();

            GioHangDTO gh = new GioHangDTO();
            DateTime dtn = DateTime.Now;
            gh.NgayBan = dtn.ToString("MM/dd/yyyy");
            dt = GioHangDAO.DoanhThuNgay(gh);

            if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "")
            {
                lbldoanhthungay.Text = "0 VND";
                lblsosp.Text = lblsodonhang.Text = "0";
                lbldoanhthungay.Location = new Point(91, 48);
            }
            else
            {
                int tongtien = int.Parse(dt.Rows[0][0].ToString());
                lbldoanhthungay.Text = string.Format("{0:#,##0}", tongtien) + " VND";
                lblsosp.Text = dt.Rows[0][1].ToString();
                lblsodonhang.Text = dt.Rows[0][2].ToString();
            }
        }

        public void BieuDo()
        {
            DataTable dt = new DataTable();
            GioHangDTO gh1 = new GioHangDTO();
            GioHangDTO gh2 = new GioHangDTO();

            DateTime dtn = DateTime.Now;
            gh1.NgayBan = dtn.ToString("MM/dd/yyyy");
            gh2.NgayBan = dtn.ToString("MM/dd/yyyy");
            dt = GioHangDAO.BieuDo(gh1, gh2);

            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày Bán";

            chart1.Series["Series1"].XValueMember = "NgayBan";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

            chart1.Series["Series1"].YValueMembers = "TongTien";
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart1.Series["Series1"].Color = Color.FromArgb(97, 50, 193);
            chart1.Series["Series1"].LabelFormat = "{0:#,##0} VND";
        }

        public void LOAD_TOPSP()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.SPMUA_NhieuNhat();
            int stt = dt.Rows.Count;

            for(int i = 0; i < stt; i++)
            {
                Panel pn = new Panel();
                pn.Width = 242; pn.Height = 108;     
                pn.Dock = DockStyle.Top;
                pn.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pic = new PictureBox();
                pic.Width = 100; pic.Height = 100;
               
                try
                {
                    pic.Load(duongdan + dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(duongdan + "null.jpg");
                }

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Dock = DockStyle.Left;

                Panel pnname = new Panel();
                pnname.Width = 142; pnname.Height = 100;
                pnname.Dock = DockStyle.Right;
                pnname.BorderStyle = BorderStyle.FixedSingle;

                Label lblten = new Label();
                lblten.Text = dt.Rows[i][1].ToString();
                lblten.ForeColor = Color.White;
                lblten.TextAlign = ContentAlignment.MiddleCenter;
                lblten.Location = new Point(20, 30);
                

                Label lblgia = new Label();
                lblgia.Text = string.Format("{0:#,##0 VND}", int.Parse(dt.Rows[i][2].ToString()));
                lblgia.ForeColor = Color.Red;
                lblgia.Location = new Point(20, 55);
                lblgia.TextAlign = ContentAlignment.MiddleCenter;
                lblgia.ForeColor = Color.FromArgb(97, 50, 193);

                pn.Controls.Add(pic);
                pn.Controls.Add(pnname);

                pnname.Controls.Add(lblten);
                pnname.Controls.Add(lblgia);

                flptopsp.Controls.Add(pn);
            }
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            DoanhThu();
            BieuDo();
            LOAD_TOPSP();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            GioHangDTO gh1 = new GioHangDTO();
            GioHangDTO gh2 = new GioHangDTO();

            gh1.NgayBan = dtpngayt.Value.ToString("MM/dd/yyyy");
            gh2.NgayBan = dtpngayd.Value.ToString("MM/dd/yyyy");
            dt = GioHangDAO.BieuDo(gh1, gh2);

            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày Bán";

            chart1.Series["Series1"].XValueMember = "NgayBan";
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            
            chart1.Series["Series1"].YValueMembers = "TongTien";
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

          
        }

        private void btnXuatThongKe_Click(object sender, EventArgs e)
        {
            RP_ThongKe rp = new RP_ThongKe();
            rp.tungay = dtpngayt.Value.ToString("dd/MM/yyyy");
            rp.denngay = dtpngayd.Value.ToString("dd/MM/yyyy");
            rp.Show();
        }
    }
}
