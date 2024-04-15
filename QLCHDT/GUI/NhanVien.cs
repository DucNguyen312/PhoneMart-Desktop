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
using System.IO;
namespace QLCHDT.GUI
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }


        private string duongdan = Environment.CurrentDirectory + @"\img_nv\";
        private int snv;

        public void TT_Nhanvien()
        {
            DataTable dt = new DataTable();
            dt = NhanVienDAO.TTNhanVien();
            int sonv = dt.Rows.Count;
            for (int i = 0; i < sonv; i++)
            {
                lvdsnv.Items.Add(dt.Rows[i]["MaNV"].ToString());
                lvdsnv.Items[i].SubItems.Add(dt.Rows[i]["TenNV"].ToString());
                lvdsnv.Items[i].SubItems.Add(dt.Rows[i]["NgaySinh"].ToString());

                string gt = dt.Rows[i]["GioiTinh"].ToString();

                if (gt == "False")
                {
                    lvdsnv.Items[i].SubItems.Add("Nữ");
                }
                else
                {
                    lvdsnv.Items[i].SubItems.Add("Nam");
                }

                lvdsnv.Items[i].SubItems.Add(dt.Rows[i]["DiaChi"].ToString());
                lvdsnv.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                lvdsnv.Items[i].SubItems.Add(dt.Rows[i]["Chucvu"].ToString());

            }
            snv = lvdsnv.Items.Count;
            lblslnv.Text = snv.ToString();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            TT_Nhanvien();
            cbbGT.Items.Add("Nữ");
            cbbGT.Items.Add("Nam");
            cbbtimkiem.Items.Add("Mã NV");
            cbbtimkiem.Items.Add("Tên NV");
            cbbGT.Text = "Nam";
            cbbtimkiem.Text = "Mã NV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = NhanVienDAO.MaNV_MAX();
            string manv = dt.Rows[0][0].ToString();
            txtmanv.Text = (int.Parse(manv.Substring(manv.Length - 3, 3)) + 1).ToString("nv000");
            txttennv.Text = dtpNgaySinh.Text = txtDiaChi.Text = txtSDT.Text = "";
            picanhnv.Image = null;
        }

        private void lvdsnv_Click(object sender, EventArgs e)
        {
            int vt = lvdsnv.SelectedIndices[0];
            txtmanv.Text = lvdsnv.Items[vt].SubItems[0].Text;
            txttennv.Text = lvdsnv.Items[vt].SubItems[1].Text;
            dtpNgaySinh.Value = DateTime.Parse(lvdsnv.Items[vt].SubItems[2].Text);
            cbbGT.Text = lvdsnv.Items[vt].SubItems[3].Text;
            txtDiaChi.Text = lvdsnv.Items[vt].SubItems[4].Text;
            txtSDT.Text = lvdsnv.Items[vt].SubItems[5].Text;
            try
            {
                picanhnv.Load(duongdan + txtmanv.Text + ".jpg");
            }
            catch
            {
                picanhnv.Load(duongdan+"add.png");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtmanv.Text == "nv001")
            {
                MessageBox.Show("Bạn không thể xóa thông tin người quản lí , chỉ có thể cập nhật !","Xác nhận");
            }
            else
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = txtmanv.Text;
                NhanVienBUS.Xoa_NhanVien(nv);
                lvdsnv.Items.Clear();
                TT_Nhanvien();
                snv = lvdsnv.Items.Count;
                lblslnv.Text = snv.ToString();
                try
                {
                    picanhnv.Load(duongdan + "null.jpg");
                    File.Delete(duongdan + txtmanv.Text + ".jpg");
                }
                catch { }
            }                    
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtmanv.Text;
            nv.TenNV = txttennv.Text;
            nv.NgaySinh = dtpNgaySinh.Value.ToString("MM/dd/yyyy");

            if (cbbGT.Text == "Nam")
                nv.GioiTinh = 1;
            else
                nv.GioiTinh = 0;
            nv.DiaChi = txtDiaChi.Text;
            nv.SDT = txtSDT.Text;

            NhanVienBUS.CapNhat_NhanVien(nv);
            lvdsnv.Items.Clear();
            TT_Nhanvien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            DataTable dt = new DataTable();
            if (cbbtimkiem.Text == "Mã NV")
            {
                nv.MaNV = txttimkiem.Text;
                lvdsnv.Items.Clear();
                dt = NhanVienDAO.TimMaNhanVien(nv);
                int sonv = dt.Rows.Count;
                for (int i = 0; i < sonv; i++)
                {
                    lvdsnv.Items.Add(dt.Rows[i][0].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][2].ToString());

                    string gt = dt.Rows[i][3].ToString();

                    if (gt == "False")
                    {
                        lvdsnv.Items[i].SubItems.Add("Nữ");
                    }
                    else
                    {
                        lvdsnv.Items[i].SubItems.Add("Nam");
                    }

                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][4].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][5].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][6].ToString());
                }
            }
            if (cbbtimkiem.Text == "Tên NV")
            {
                nv.TenNV = txttimkiem.Text;
                lvdsnv.Items.Clear();
                dt = NhanVienDAO.TimTenNhanVien(nv);
                int sonv = dt.Rows.Count;
                for (int i = 0; i < sonv; i++)
                {
                    lvdsnv.Items.Add(dt.Rows[i][0].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][2].ToString());

                    string gt = dt.Rows[i][3].ToString();

                    if (gt == "False")
                    {
                        lvdsnv.Items[i].SubItems.Add("Nữ");
                    }
                    else
                    {
                        lvdsnv.Items[i].SubItems.Add("Nam");
                    }

                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][4].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][5].ToString());
                    lvdsnv.Items[i].SubItems.Add(dt.Rows[i][6].ToString());
                }
            }
            snv = lvdsnv.Items.Count;
            lblslnv.Text = snv.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtmanv.Text == "")
            {
                MessageBox.Show("Vui lòng nhấn nút 'Thêm' để hệ thống tự động thêm mã nhân viên \nSau đó mới có thể lưu nhân viên mới", "Thông Báo");
            }
            else
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = txtmanv.Text;
                nv.TenNV = txttennv.Text;
                nv.MkNV = "123";
                nv.NgaySinh = dtpNgaySinh.Value.ToString("MM/dd/yyyy");

                if (cbbGT.Text == "Nam")
                    nv.GioiTinh = 1;
                if (cbbGT.Text == "Nữ")
                    nv.GioiTinh = 0;
                nv.DiaChi = txtDiaChi.Text;
                nv.SDT = txtSDT.Text;
                nv.Chucvu = "Nhân Viên";
                if (txttennv.Text.Trim() == "" && txtDiaChi.Text.Trim() == "" && txtSDT.Text.Trim() == "")
                {
                    MessageBox.Show("vui lòng nhập thông tin nhân viên", "Thông Báo");
                }
                else
                {
                    NhanVienBUS.Them_NhanVien(nv);
                    lvdsnv.Items.Clear();
                    TT_Nhanvien();
                }
                snv = lvdsnv.Items.Count;
                lblslnv.Text = snv.ToString();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void picanhnv_Click(object sender, EventArgs e)
        {

        }

        private void btnResetMK_Click(object sender, EventArgs e)
        {
            if(txtmanv.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên muốn đặt lại mật khẩu","Thông Báo");
            }
            else
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = txtmanv.Text;
                nv.MkNV = "123";
                NhanVienBUS.CapNhat_MK(nv);
                MessageBox.Show("Đặt lại mật khẩu thành công ! \nMật khẩu mặc định là: 123","Thông Báo");
            }
            
        }
    }
}
