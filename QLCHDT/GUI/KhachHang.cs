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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        public void LoadLV()
        {
            DataTable dt = new DataTable();
            dt = KhachHangDAO.TT_KH_TongTien();
            int sodong = dt.Rows.Count;
            int stt = 0;
            for (int i = 0; i < sodong; i++)
            {
                stt++;
                lvkh.Items.Add(stt.ToString());
                lvkh.Items[i].SubItems.Add(dt.Rows[i]["MaKH"].ToString());
                lvkh.Items[i].SubItems.Add(dt.Rows[i]["TenKH"].ToString());
                lvkh.Items[i].SubItems.Add(dt.Rows[i]["Diachi"].ToString());
                lvkh.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                lvkh.Items[i].SubItems.Add(dt.Rows[i]["NgayBan"].ToString());
                lvkh.Items[i].SubItems.Add(string.Format("{0:#,##0}", int.Parse(dt.Rows[i]["TongTien"].ToString())) + " VND");
            }
            int sokh = lvkh.Items.Count;
            lblsokh.Text = sokh.ToString();
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadLV();
            cbbtimkiem.Items.Add("Mã KH");
            cbbtimkiem.Items.Add("Tên KH");
        }

        private void lvkh_Click(object sender, EventArgs e)
        {
            txtmakh.Text = lvkh.SelectedItems[0].SubItems[1].Text;
            txttennv.Text = lvkh.SelectedItems[0].SubItems[2].Text;
            txtDiaChi.Text = lvkh.SelectedItems[0].SubItems[3].Text;
            txtSDT.Text = lvkh.SelectedItems[0].SubItems[4].Text;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text != "")
            {
                if (MessageBox.Show("Bạn có muốn CẬP NHẬT khách hàng này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    kh.MaKH = txtmakh.Text;
                    kh.TenKH = txttennv.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    kh.SDT = txtSDT.Text.Trim();
                    KhachHangBUS.CapNhat_KH(kh);
                    lvkh.Items.Clear();
                    LoadLV();
                    MessageBox.Show("Cập nhật khách hàng thành công", "Thông Báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng trong danh sách mà bạn muốn cập nhật", "Thông Báo");
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text != "")
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = txtmakh.Text;
                KhachHangBUS.Xoa_KH(kh);
                lvkh.Items.Clear();
                LoadLV();
                MessageBox.Show("Xóa khách hàng thành công !","Thông Báo");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng trong danh sách mà bạn muốn xóa !", "Thông Báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            DataTable dt = new DataTable();
            if (cbbtimkiem.Text == "Mã KH")
            {
                kh.MaKH = txttimkiem.Text;
                lvkh.Items.Clear();
                dt = KhachHangDAO.TT_KH_TheoMa(kh);
                int sokh = dt.Rows.Count;
                int stt = 0;
                for (int i = 0; i < sokh; i++)
                {
                    stt++;
                    lvkh.Items.Add(stt.ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["MaKH"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["TenKH"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["Diachi"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["NgayBan"].ToString());
                    lvkh.Items[i].SubItems.Add(string.Format("{0:#,##0}", int.Parse(dt.Rows[i]["TongTien"].ToString())) + " VND");
                }
            }
            else
            {
                kh.TenKH = txttimkiem.Text;
                lvkh.Items.Clear();
                dt = KhachHangDAO.TT_KH_TheoTen(kh);
                int sokh = dt.Rows.Count;
                int stt = 0;
                for (int i = 0; i < sokh; i++)
                {
                    stt++;
                    lvkh.Items.Add(stt.ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["MaKH"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["TenKH"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["Diachi"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                    lvkh.Items[i].SubItems.Add(dt.Rows[i]["NgayBan"].ToString());
                    lvkh.Items[i].SubItems.Add(string.Format("{0:#,##0}", int.Parse(dt.Rows[i]["TongTien"].ToString())) + " VND");
                }
            }
        }

        private void cbbtimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            lvkh.Items.Clear();
            LoadLV();
        }
    }
}
