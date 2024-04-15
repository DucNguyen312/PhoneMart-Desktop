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
namespace QLCHDT.GUI
{
    public partial class XacNhanHD : Form
    {
        public XacNhanHD()
        {
            InitializeComponent();
        }

        private string magh;
        private string mahd;
        private string makh;


        //hàm khởi tạo (Contructor) lấy dữ liệu bên form DangNhap qua
        public XacNhanHD(string ma_gh, string ma_hd, string ma_kh) : this()
        {
            this.magh = ma_gh;
            this.mahd = ma_hd;
            this.makh = ma_kh;
        }

        public void Load_SPMua()
        {
            SPMuaDTO spm = new SPMuaDTO();
            GioHangDTO gh = new GioHangDTO();
            gh.MaGh = magh;
            spm.MaGH = magh;
            DataTable dt = new DataTable();
            DataTable dt_gh = new DataTable();
            dt = SPMuaDAO.TT_SPMua(spm);
            dt_gh = GioHangDAO.TT_GH_MaGH(gh);

            lvgiohang.Items.Clear();
            int stt = dt.Rows.Count;
            for (int i = 0; i < stt; i++)
            {
                int sl = int.Parse(dt.Rows[i][1].ToString());
                int dongia = int.Parse(dt.Rows[i][2].ToString());
                lvgiohang.Items.Add(dt.Rows[i][0].ToString());
                lvgiohang.Items[i].SubItems.Add(sl.ToString());
                lvgiohang.Items[i].SubItems.Add(string.Format("{0:N0}", double.Parse(dongia.ToString())));
                lvgiohang.Items[i].SubItems.Add(string.Format("{0:N0}", double.Parse((sl*dongia).ToString())));
            }
            lblsl.Text = dt_gh.Rows[0][2].ToString();
            int tongtien = int.Parse(dt_gh.Rows[0][3].ToString());
            lbltongtien.Text = string.Format("{0:#,##0}", tongtien) + " VND";

        }
        private void NhapThongTinKhachHang_Load(object sender, EventArgs e)
        {
            Load_SPMua();
            txtmakh.Text = makh;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            if (txttenkh.Text.Trim() != "" && txtsdt.Text.Trim() != "" && txtdiachi.Text.Trim() != "")
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = makh;
                kh.TenKH = txttenkh.Text;
                kh.DiaChi = txtdiachi.Text;
                kh.SDT = txtsdt.Text;
                if (MessageBox.Show("Xác Nhận Đơn Hàng ?", "Xác Nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KhachHangBUS.CapNhat_KH(kh);
                    MessageBox.Show("Xác nhận thành công !", "Thông Báo");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng", "Thông Báo");
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy Đơn Hàng ?", "Xác Nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HoaDonDTO hd = new HoaDonDTO();
                GioHangDTO gh = new GioHangDTO();
                KhachHangDTO kh = new KhachHangDTO();
                hd.MaHD = mahd;
                gh.MaGh = magh;
                kh.MaKH = makh;
                HoaDonBUS.Xoa_HD_XacNhan(hd);
                GioHangBUS.Xoa_GioHang(gh);
                KhachHangDAO.XoaKH(kh);
                this.Close();
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
