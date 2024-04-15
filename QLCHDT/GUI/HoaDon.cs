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
using QLCHDT.BUS;
using QLCHDT.DAO;

namespace QLCHDT.GUI
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        private string manv;
        public HoaDon(string ma_nv) : this()
        {
            this.manv = ma_nv;
        }

        public void TT_HD()
        {
            DataTable dt = new DataTable();
            dt = HoaDonDAO.TT_HD();
            int stt = dt.Rows.Count;
            for (int i = 0; i < stt; i++)
            {
                lvhd.Items.Add(dt.Rows[i]["MaHD"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaNV"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TenNV"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaKH"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TenKH"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaGH"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TongSoLuong"].ToString());
                lvhd.Items[i].SubItems.Add(string.Format("{0:N0}" ,int.Parse(dt.Rows[i]["TongTien"].ToString())));
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["NgayBan"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TrangThai"].ToString());
            }
            int sohd = lvhd.Items.Count;
            lblsl.Text = sohd.ToString();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            if(manv != "nv001")
            {
                btnXoa.Enabled = false;
            }
            
            lvhd.Items.Clear();
            TT_HD();
            txtsdt.ResetText();

            cbbtimkiem.Items.Add("Mã hóa đơn");
            cbbtimkiem.Items.Add("Tên nhân viên");
            cbbtimkiem.Items.Add("Tên khách hàng");
            cbbtimkiem.Text = "Mã hóa đơn";

            cbbsapxep.Items.Add("Trị giá hóa đơn (giảm)");
            cbbsapxep.Items.Add("Trị giá hóa đơn (tăng)");
            cbbsapxep.Items.Add("Ngày thanh toán (gần)");
            cbbsapxep.Items.Add("Trạng Thái");
            cbbsapxep.Text = "Trạng Thái";
        }

        private void cbbsapxep_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cbbsapxep.Text == "Trị giá hóa đơn (giảm)")
            {
                dt = HoaDonDAO.TT_HD_Giam("TongTien");
            }
            if (cbbsapxep.Text == "Trị giá hóa đơn (tăng)")
            {
                dt = HoaDonDAO.TT_HD_Tang("TongTien");
            }
            if (cbbsapxep.Text == "Ngày thanh toán (gần)")
            {
                dt = HoaDonDAO.TT_HD_Giam("NgayBan");
            }
            if (cbbsapxep.Text == "Trạng Thái")
            {
                dt = HoaDonDAO.TT_HD_Tang("TrangThai");
            }

            lvhd.Items.Clear();
            int stt = dt.Rows.Count;
            for (int i = 0; i < stt; i++)
            {
                lvhd.Items.Add(dt.Rows[i]["MaHD"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaNV"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TenNV"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaKH"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TenKH"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaGH"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TongSoLuong"].ToString());
                lvhd.Items[i].SubItems.Add(string.Format("{0:N0}", int.Parse(dt.Rows[i]["TongTien"].ToString())));
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["NgayBan"].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i]["TrangThai"].ToString());
            }
            int sohd = lvhd.Items.Count;
            lblsl.Text = sohd.ToString();

        }

        private void lvhd_Click(object sender, EventArgs e)
        {
            // Thông tin bình thường
            txtMaHD.Text = lvhd.SelectedItems[0].SubItems[0].Text;
            txtMaNV.Text = lvhd.SelectedItems[0].SubItems[1].Text;
            txtTenNV.Text = lvhd.SelectedItems[0].SubItems[2].Text;
            txtMaKH.Text = lvhd.SelectedItems[0].SubItems[3].Text;
            txtmagh.Text = lvhd.SelectedItems[0].SubItems[5].Text;
            try
            {
                txtTenKH.Text = lvhd.SelectedItems[0].SubItems[4].Text;
            }
            catch { }
            lblsoluong.Text = lvhd.SelectedItems[0].SubItems[6].Text;
           
            dtpngayban.Text = lvhd.SelectedItems[0].SubItems[8].Text;
            lblthanhtien.Text = lvhd.SelectedItems[0].SubItems[7].Text + " VND";
            if (lvhd.SelectedItems[0].SubItems[9].Text == "Chưa Thanh Toán")
            {
                RadChuaTT.Checked = true;
            }
            else
            {
                radDaTT.Checked = true;
            }

            // Hiện Thông tin của khách Hàng
            DataTable dt_kh = new DataTable();
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text = lvhd.SelectedItems[0].SubItems[3].Text;
            dt_kh = KhachHangDAO.TT_KH_MaKH(kh);

            txtTenKH.Text = dt_kh.Rows[0][1].ToString();
            txtDiachiKH.Text = dt_kh.Rows[0][2].ToString();
            txtsdt.Text = dt_kh.Rows[0][3].ToString();

            // hiện sản phẩm đã mua hàng
            SPMuaDTO spm = new SPMuaDTO();
            spm.MaGH = lvhd.SelectedItems[0].SubItems[5].Text;
            DataTable dt = new DataTable();
            dt = SPMuaDAO.TT_SPMua_LV(spm);
            lvdssp.Items.Clear();
            int stt = dt.Rows.Count;
            for (int i = 0; i < stt; i++)
            {
                lvdssp.Items.Add(dt.Rows[i][0].ToString());
                lvdssp.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim() != "" && txtsdt.Text.Trim() != "" && txtDiachiKH.Text.Trim() != "")
            {
                if (MessageBox.Show("Bạn muốn cập nhật đơn hàng này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // cập nhật khách hàng
                        DataTable dt_kh = new DataTable();
                        KhachHangDTO kh = new KhachHangDTO();
                        kh.MaKH = txtMaKH.Text;
                        kh.TenKH = txtTenKH.Text;
                        kh.DiaChi = txtDiachiKH.Text;
                        kh.SDT = txtsdt.Text;
                        KhachHangBUS.CapNhat_KH(kh);

                        // cập nhật ngày bán
                        int ngayht = DateTime.Now.Day;
                        int thanght = DateTime.Now.Month;
                        int namht = DateTime.Now.Year;

                        int ngay = int.Parse(dtpngayban.Value.ToString("dd"));
                        int thang = int.Parse(dtpngayban.Value.ToString("MM"));
                        int nam = int.Parse(dtpngayban.Value.ToString("yyyy"));

                        if (ngay <= ngayht && thang <= thanght && nam <= namht)
                        {
                            GioHangDTO gh = new GioHangDTO();
                            gh.NgayBan = dtpngayban.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
                            gh.MaGh = txtmagh.Text;
                            GioHangBUS.CapNhat_GioHang(gh);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng cập nhật lại ngày bán cho chính xác !", "Thông Báo");
                        }

                        // cập nhật trạng thái hóa đơn
                        HoaDonDTO hd = new HoaDonDTO();
                        if (radDaTT.Checked == true)
                            hd.TrangThai = "Thành Công";
                        else
                        {
                            hd.TrangThai = "Chưa Thanh Toán";
                        }
                        hd.MaHD = txtMaHD.Text;
                        HoaDonBUS.CapNhat_HD(hd);
                        lvhd.Items.Clear();
                        TT_HD();
                        int sohd = lvhd.Items.Count;
                        lblsl.Text = sohd.ToString();

                        MessageBox.Show("Cập nhật thành công !","Thông Báo");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng chọn thông tin cần cập nhật !", "Thông Báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần cập nhật !", "Thông Báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn mà bạn muốn xóa !", "Thông Báo");
            }
            else
            {
                HoaDonDTO hd = new HoaDonDTO();
                hd.MaHD = txtMaHD.Text;
                GioHangDTO gh = new GioHangDTO();
                gh.MaGh = txtmagh.Text;

                HoaDonBUS.Xoa_HD(hd);
                GioHangBUS.Xoa_GioHang(gh);
                lvhd.Items.Clear();
                TT_HD();
                int sohd = lvhd.Items.Count;
                lblsl.Text = sohd.ToString();
                MessageBox.Show("Xóa thành công !", "Thông Báo");
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lvhd.Items.Clear();
            TT_HD();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (txttimkiem.Text != "")
            {
                if (cbbtimkiem.Text == "Mã hóa đơn")
                {
                    dt = HoaDonDAO.TimKiemHD("HoaDon.MaHD", txttimkiem.Text);
                }
                if (cbbtimkiem.Text == "Tên nhân viên")
                {
                    dt = HoaDonDAO.TimKiemHD("TenNV", txttimkiem.Text);
                }
                if (cbbtimkiem.Text == "Tên khách hàng")
                {
                    dt = HoaDonDAO.TimKiemHD("TenKH", txttimkiem.Text);
                }

                lvhd.Items.Clear();
                int stt = dt.Rows.Count;
                for (int i = 0; i < stt; i++)
                {
                    lvhd.Items.Add(dt.Rows[i]["MaHD"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaNV"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["TenNV"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaKH"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["TenKH"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["MaGH"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["TongSoLuong"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["TongTien"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["NgayBan"].ToString());
                    lvhd.Items[i].SubItems.Add(dt.Rows[i]["TrangThai"].ToString());
                }
                int sohd = lvhd.Items.Count;
                lblsl.Text = sohd.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa mà bạn muốn tìm kiếm");
                txttimkiem.Focus();
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui Lòng Chọn Hóa Đơn mà bạn muốn xuất !", "Thông báo");
            }
            else
            {
                RP_CTHD rp = new RP_CTHD(txtMaHD.Text);
                rp.ShowDialog();
            }
        }
    }
}
