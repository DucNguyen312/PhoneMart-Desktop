using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCHDT.DTO;
using QLCHDT.DAO;
using QLCHDT.BUS;
using QLCHDT.GUI;

namespace QLCHDT.GUI
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }

        private string manv;
        public BanHang(string ma_nv) : this()
        {
            this.manv = ma_nv;
        }

        private string duongdan = Environment.CurrentDirectory + @"\img_sp\";

        void LoadTable()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTSP();
            int sosp = dt.Rows.Count;
            for (int i = 0; i < sosp; i++)
            {
                Label ten = new Label();
                ten.Text = dt.Rows[i][1].ToString();
                ten.Dock = DockStyle.Bottom;
                ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                ten.ForeColor = Color.White;

                Label gia = new Label();
                gia.Text = string.Format("{0:#,##0 VND}", long.Parse(dt.Rows[i][2].ToString()));
                gia.Dock = DockStyle.Bottom;
                gia.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                gia.BackColor = Color.FromArgb(97, 50, 193);
                gia.ForeColor = Color.White;

                PictureBox pic = new PictureBox();
                pic.Width = 170; pic.Height = 240; // set kích thước của ảnh
                try
                {
                    pic.Load(duongdan + dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(duongdan + "null.jpg");
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Margin = new Padding(10, 5, 5, 15);
                pic.Tag = dt.Rows[i][0].ToString();

                pic.Click += new EventHandler(Onclick); // sự kiện click

                pic.Controls.Add(ten);    // add tên vào ảnh
                pic.Controls.Add(gia);    // add giá vào ảnh
                flpSanPham.Controls.Add(pic);  // add hình vào FlowlayoutPanel
            }
        }

        // hàm kiểm tra số lượng
        int Kiemtra(string masp)
        {
            int sodong = lvgiohang.Items.Count;
            for (int i = 0; i < sodong; i++)
                if (masp == lvgiohang.Items[i].SubItems[5].Text)
                    return i;
            return -1;

        }

        public void Onclick(object sender, EventArgs e)
        {
            string masp = ((PictureBox)sender).Tag.ToString();  // trả về mã sản phẩm khi click vào ảnh sp
            SanPhamDTO sp = new SanPhamDTO();
            sp.MaSP = masp;
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTSP_MaSP(sp);
            int stt = lvgiohang.Items.Count;
            stt++;

            string tensp = dt.Rows[0][1].ToString();
            int soluong;
            long dongia = long.Parse(dt.Rows[0][2].ToString());

            if (Kiemtra(masp) == -1)
            {
                soluong = 1;
                lvgiohang.Items.Add(stt.ToString());
                lvgiohang.Items[stt - 1].SubItems.Add(tensp);
                lvgiohang.Items[stt - 1].SubItems.Add(soluong.ToString());
                lvgiohang.Items[stt - 1].SubItems.Add(string.Format("{0:N0}", dongia));
                lvgiohang.Items[stt - 1].SubItems.Add(string.Format("{0:N0}", (soluong * dongia)));
                lvgiohang.Items[stt - 1].SubItems.Add(masp);
            }
            else
            {
                int i = Kiemtra(masp);
                soluong = int.Parse(lvgiohang.Items[i].SubItems[2].Text);
                soluong++;
                lvgiohang.Items[i].SubItems[2].Text = soluong.ToString();
                
                lvgiohang.Items[i].SubItems[4].Text = string.Format("{0:N0}",(soluong * dongia));
                lvgiohang.Items[i].SubItems.Add(masp);
            }
        }
        private void BanHang_Load(object sender, EventArgs e)
        {
            TT_ThuongHieu();
            flpSanPham.Controls.Clear();
            LoadTable();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vt = lvgiohang.SelectedIndices[0];
                if (MessageBox.Show("Bạn có muốn xóa sản phẩm này ra khỏi giỏ hàng ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    lvgiohang.Items.RemoveAt(vt);
                btnXacNhanHD.Visible = false;
            }

            catch
            {
                MessageBox.Show("Vui lòng chọn 1 dòng sản phẩm trong giỏ hàng mà bạn muốn xóa", "Thông báo");
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int stt = lvgiohang.Items.Count;
            
            if (stt == 0)
            {
                MessageBox.Show("Không có sản phẩm trong giỏ hàng", "Thông Báo");
            }
            else
            {
                double tong = 0;
                double sl = 0;
                for (int i = 0; i < stt; i++)
                {

                    tong += double.Parse(string.Format("{0:D}", lvgiohang.Items[i].SubItems[4].Text));
                    sl += double.Parse(string.Format("{0:D}", lvgiohang.Items[i].SubItems[2].Text));
                }
                lbltongtien.Text = string.Format("{0:#,##0}", tong) + " VND";
                lblsosp.Text = sl.ToString();
                btnXacNhanHD.Visible = true;
            }
        }

        public void TT_ThuongHieu()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TT_ThuongHieu();
            cbbtimkiem.DataSource = dt;
            cbbtimkiem.ValueMember = "MaTH";
            cbbtimkiem.DisplayMember = "TenTH";
        }

        private void cbbtimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SanPhamDTO sp = new SanPhamDTO();
            sp.MaTH = cbbtimkiem.SelectedValue.ToString();
            dt = SanPhamDAO.TTSP_MaTH(sp);
            flpSanPham.Controls.Clear();
            int sosp = dt.Rows.Count;
            for (int i = 0; i < sosp; i++)
            {
                Label ten = new Label();
                ten.Text = dt.Rows[i][1].ToString();
                ten.Dock = DockStyle.Bottom;
                ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                ten.ForeColor = Color.White;
               // ten.Font = new Font(ten.Font, ten.Font.Style ^ FontStyle.Bold);  Font chữ

                Label gia = new Label();
                gia.Text = string.Format("{0:#,##0}", long.Parse(dt.Rows[i][2].ToString())) + " VND";
                gia.Dock = DockStyle.Bottom;
                gia.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                gia.BackColor = Color.FromArgb(97, 50, 193);
                gia.ForeColor = Color.White;

                PictureBox pic = new PictureBox();
                pic.Width = 170; pic.Height = 240; // set kích thước của ảnh
                try
                {
                    pic.Load(duongdan + dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(duongdan + "null.jpg");
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Margin = new Padding(10, 5, 5, 15);
                pic.Tag = dt.Rows[i][0].ToString();

                pic.Click += new EventHandler(Onclick); // sự kiện click

                pic.Controls.Add(ten);    // add tên vào ảnh
                pic.Controls.Add(gia);    // add giá vào ảnh
                flpSanPham.Controls.Add(pic);  // add hình vào FlowlayoutPanel
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            flpSanPham.Controls.Clear();
            LoadTable();
        }

        private void btnLMHD_Click(object sender, EventArgs e)
        {
            lvgiohang.Items.Clear();
            btnXacNhanHD.Visible = false;
            lblsosp.Text = "0";
            lbltongtien.Text = "0 VND";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SanPhamDTO sp = new SanPhamDTO();
            sp.TenSP = txttimkiem.Text;
            dt = SanPhamDAO.TimSPTheoTen(sp);
            flpSanPham.Controls.Clear();
            int sosp = dt.Rows.Count;
            for (int i = 0; i < sosp; i++)
            {
                Label ten = new Label();
                ten.Text = dt.Rows[i]["TenSP"].ToString();
                ten.Dock = DockStyle.Bottom;
                ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                ten.ForeColor = Color.White;

                Label gia = new Label();
                gia.Text = string.Format("{0:#,##0}", long.Parse(dt.Rows[i]["Gia"].ToString())) + " VND";
                gia.Dock = DockStyle.Bottom;
                gia.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                gia.BackColor = Color.FromArgb(97, 50, 193);
                gia.ForeColor = Color.White;

                PictureBox pic = new PictureBox();
                pic.Width = 170; pic.Height = 240; // set kích thước của ảnh
                try
                {
                    pic.Load(duongdan + dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(duongdan + "null.jpg");
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Margin = new Padding(10, 5, 5, 15);
                pic.Tag = dt.Rows[i]["MaSP"].ToString();

                pic.Click += new EventHandler(Onclick); // sự kiện click

                pic.Controls.Add(ten);    // add tên vào ảnh
                pic.Controls.Add(gia);    // add giá vào ảnh
                flpSanPham.Controls.Add(pic);  // add hình vào FlowlayoutPanel
            }

        }

        private void btnXacNhanHD_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dt_sp_mua = new DataTable();
                DataTable dt_hd = new DataTable();
                DataTable dt_kh = new DataTable();

                GioHangDTO gh = new GioHangDTO();
                HoaDonDTO hd = new HoaDonDTO();
                KhachHangDTO kh = new KhachHangDTO();
                SPMuaDTO spm = new SPMuaDTO();

                dt = GioHangDAO.TT_GH();
                dt_hd = HoaDonDAO.TT_MaHD();
                dt_kh = KhachHangDAO.TT_KH();

                DateTime dtn = DateTime.Now;   // lấy ngày giờ ở hiện tại
                int stt = dt.Rows.Count;
                int stt_hd = dt_hd.Rows.Count;
                int stt_kh = dt_kh.Rows.Count;
                // điều kiện nếu ko có mã hàng thì mặc định là GH001 , có thì tăng 1 Lấy cái maHG lớn nhất tăng 1 lên
                if (stt == 0)
                {
                    gh.MaGh = "GH001";

                }
                else
                {
                    dt = GioHangDAO.MaGH_MAX();
                    string magh = dt.Rows[0][0].ToString();
                    gh.MaGh = (int.Parse(magh.Substring(magh.Length - 3, 3)) + 1).ToString("GH000");
                }

                // hóa dơn
                if (stt_hd == 0)
                {
                    hd.MaHD = "HD001";
                }
                else
                {
                    dt_hd = HoaDonDAO.MaHD_MAX();
                    string magh = dt_hd.Rows[0][0].ToString();
                    hd.MaHD = (int.Parse(magh.Substring(magh.Length - 3, 3)) + 1).ToString("HD000");

                }
                //Khách Hàng
                if (stt_kh == 0)
                {
                    kh.MaKH = "KH001";
                }
                else
                {
                    dt_kh = KhachHangDAO.MaKH_MAX();
                    string makh = dt_kh.Rows[0][0].ToString();
                    kh.MaKH = (int.Parse(makh.Substring(makh.Length - 3, 3)) + 1).ToString("KH000");
                }

                //tính tổng tiền
                double tongtien = 0;
                for (int i = 0; i < lvgiohang.Items.Count; i++)
                {
                    tongtien += double.Parse(string.Format("{0:D}", lvgiohang.Items[i].SubItems[4].Text));
                }

                gh.NgayBan = dtn.ToString("MM/dd/yyyy hh:mm:ss tt");
                gh.TongSoLuong = long.Parse(lblsosp.Text);
                gh.ThanhTien = (long) tongtien;
                KhachHangBUS.Them_KH(kh);
                GioHangBUS.ThemSP_GioHang(gh);

                for (int i = 0; i < lvgiohang.Items.Count; i++)
                {
                    spm.MaGH = gh.MaGh;
                    spm.Stt = int.Parse(lvgiohang.Items[i].SubItems[0].Text);
                    spm.MaSP = lvgiohang.Items[i].SubItems[5].Text;
                    spm.Soluong = int.Parse(lvgiohang.Items[i].SubItems[2].Text);
                    SPMuaBUS.ThemSP(spm);
                }

                hd.MaGH = gh.MaGh;
                hd.MaKH = kh.MaKH;
                hd.MaNV = manv;
                hd.TrangThai = "Chưa Thanh Toán";
                HoaDonBUS.Them_HD(hd);

                XacNhanHD nhaphd = new XacNhanHD(gh.MaGh, hd.MaHD, kh.MaKH);
                nhaphd.ShowDialog();
                btnXacNhanHD.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
