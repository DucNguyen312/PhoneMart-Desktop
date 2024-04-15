using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QLCHDT.DTO;
using QLCHDT.DAO;
using QLCHDT.BUS;
namespace QLCHDT.GUI
{
    public partial class TrangCaNhan : Form
    {
        public TrangCaNhan()
        {
            InitializeComponent();
        }
        private string fN; // đường dẫn hiện tại của ảnh
        private string duongdan = Environment.CurrentDirectory + @"\img_nv\";  //bin/debug/... địa chỉ ảnh muốn lưu
        private string manv;
        public TrangCaNhan(string ma_nv) : this()
        {
            this.manv = ma_nv;
        }
        //load thông tin lên 
        public void TT_NV()
        {
            DataTable dt = new DataTable();
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = manv;
            dt = NhanVienDAO.TimMaNhanVien(nv);
            txtManv.Text = dt.Rows[0]["MaNV"].ToString();
            txtTenNV.Text = dt.Rows[0]["TenNV"].ToString();
            dtpNgaysinh.Text = dt.Rows[0]["NgaySinh"].ToString();
            // chuyển đổi bt sang strinh (giới tính)
            string gt = dt.Rows[0]["GioiTinh"].ToString();
            if (gt == "False")
            {
                cbbgt.Text = "Nữ";
            }
            else
            {
                cbbgt.Text = "Nam";
            }
            txtdiachi.Text = dt.Rows[0]["DiaChi"].ToString();
            txtsdt.Text = dt.Rows[0]["SDT"].ToString();

            string namsinh = dtpNgaysinh.Value.ToString("yyyy");
            txtTuoi.Text = (2022 - int.Parse(namsinh)).ToString();
        }

        //làm sạch dữ liệu nhập vào
        public void Clear_DL()
        {
            txtTenNV.Text = dtpNgaysinh.Text = cbbgt.Text = txtdiachi.Text = txtsdt.Text = "";
        }

        public void TTTH()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTTH();
            cbbth.DataSource = dt;
            cbbth.DisplayMember = "MaTH";
            cbbth.ValueMember = "MaTH";
        }

        private void TrangCaNhan_Load(object sender, EventArgs e)
        {
            TT_NV();
            try
            {
                picanhcanhan.Load(duongdan + txtManv.Text + ".jpg");
            }
            catch
            {
                picanhcanhan.Load(duongdan + "add.png");
            }
            TTTH();
        }

        // chọn ảnh làm ảnh đại diện
        private void picanhcanhan_Click(object sender, EventArgs e)
        {
            OpenFileDialog openpic = new OpenFileDialog();
            openpic.Title = "Chọn ảnh";
            openpic.Filter = "Image Files(*.jpg) | *.JPG";
            if (openpic.ShowDialog() == DialogResult.OK)
            {
                fN = openpic.FileName;
                using (var bitmap = new Bitmap(fN))
                    picanhcanhan.Image = new Bitmap(bitmap);

            }
        }

        //cập nhật ảnh
        private void btncapnhatanh_Click(object sender, EventArgs e)
        {

            try
            {
                picanhcanhan.Load(duongdan + "null.jpg");   // Nếu tồn tại ảnh cũ thì phải load ảnh trung gian lên r mới cập nhật
                string namepic = txtManv.Text + ".jpg";     // Tên ảnh muốn lưu
                File.Copy(fN, Path.Combine(duongdan, namepic), true);  // copy cái ảnh kia vào đường dẫn ./bin/debug/..
                picanhcanhan.Load(duongdan + txtManv.Text + ".jpg");    // load ảnh mới lưu lên
                MessageBox.Show("Cập nhật ảnh thành công", "Thông báo");
            }
            catch
            {
                picanhcanhan.Load(duongdan + txtManv.Text + ".jpg");
                MessageBox.Show("Nhấn vào ảnh đại diện nếu bạn muốn cập nhật ảnh", "Thông báo");
            }
            //Try catch : dùng để bắt lỗi người dùng , tự nhiên nhấn vào nút cập nhật
            //Nếu tự nhiên nhấn vào sẽ phát sinh lỗi nên phải dùng try catch
        }

        //hiện phần đổi mật khẩu
        private void btnDatMK_Click(object sender, EventArgs e)
        {
            grbDoiMK.Visible = true;
            panel4.BorderStyle = BorderStyle.FixedSingle;
        }

        //cập nhật mật khẩu
        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if(txtmkcu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ trước khi đổi mật khẩu");
            }
            else
            {
                DataTable dt = new DataTable();
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = txtManv.Text;
                nv.MkNV = txtmkmoi.Text;
                dt = NhanVienDAO.MkCu(nv);
                if (txtmkcu.Text == dt.Rows[0][0].ToString())
                {
                    if (txtmkmoi.Text.Trim() == "")
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu mới !", "Thông Báo");
                    }
                    else
                    {
                        NhanVienBUS.CapNhat_MK(nv);
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông Báo");
                        grbDoiMK.Visible = false;
                        panel4.BorderStyle = BorderStyle.None;
                    }
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu cũ", "Thông Báo");
                }
            }
        }
        // lưu thông tin cá nhân
        private void btnluu_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtManv.Text;
            nv.TenNV = txtTenNV.Text;
            nv.NgaySinh = dtpNgaysinh.Value.ToString("MM/dd/yyyy");
            if (cbbgt.Text == "Nam")
                nv.GioiTinh = 1;
            else
                nv.GioiTinh = 0;
            nv.SDT = txtsdt.Text;
            nv.DiaChi = txtdiachi.Text;
            NhanVienBUS.CapNhat_NhanVien(nv);
            MessageBox.Show("Cập nhật thông tin thành công !", "Thông Báo");
            Clear_DL();
            TT_NV();
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLuuTH_Click(object sender, EventArgs e)
        {
            if (txtmath.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã thương hiệu", "Thông Báo");
            }
            else
            {
                ThuongHieuDTO th = new ThuongHieuDTO();
                th.MaTH = txtmath.Text;
                DataTable dt = new DataTable();
                dt = SanPhamDAO.KTTH(th);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Mã Thương Hiệu đã tồn tại", "Thông Báo");
                }
                else
                {
                    th.MaTH = txtmath.Text;
                    th.TenTH = txttenth.Text;
                    SanPhamDAO.ThemTH(th);
                    txtmath.Visible = false;
                    cbbth.Visible = true;
                    TTTH();
                    MessageBox.Show("Thêm Thương Hiệu Thành Công !", "Thông Báo");
                }
            }
            
        }

        private void cbbth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                ThuongHieuDTO th = new ThuongHieuDTO();
                th.MaTH = cbbth.SelectedValue.ToString();
                dt = SanPhamDAO.KTTH(th);
                txttenth.Text = dt.Rows[0][1].ToString();
            }
            catch { }
        }

        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            if (ck.Checked == true)
            {
                cbbth.Visible = btnCapNhatTH.Enabled = btnXoaTH.Enabled = false;
                txtmath.Visible = btnLuuTH.Enabled = true;
                txttenth.Text = "";
            }
            else
            {
                cbbth.Visible = btnCapNhatTH.Enabled = btnXoaTH.Enabled = true;
                txtmath.Visible = btnLuuTH.Enabled = false;
            }

        }

        private void btnCapNhatTH_Click(object sender, EventArgs e)
        {
            if(cbbth.Text == "")
            {
                MessageBox.Show("Bạn vui lòng chọn mã thương hiệu muốn cập nhật !", "Thông Báo ");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn cập nhật lại tên thương hiệu ?", "Xác Nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if(txttenth.Text.Trim() == "") { MessageBox.Show("Bạn vui lòng nhập tên thương hiệu !", "Thông Báo "); }
                    else
                    {
                        ThuongHieuDTO th = new ThuongHieuDTO();
                        th.MaTH = cbbth.SelectedValue.ToString();
                        th.TenTH = txttenth.Text;
                        SanPhamDAO.CapNhatTH(th);
                        MessageBox.Show("Cập nhật Tên Thành Công", "Thông Báo");
                        TTTH();
                    }
                }
            }
        }

        private void btnXoaTH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Nếu bạn xóa mã thương hiệu này !!\nThì tất cả sản phẩm thuộc thương hiệu này sẽ bị xóa", "Xác Nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ThuongHieuDTO th = new ThuongHieuDTO();
                th.MaTH = cbbth.SelectedValue.ToString();
                SanPhamDAO.XoaTH(th);
                TTTH();
                MessageBox.Show("Xóa thương hiệu thành công !", "Thông Báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grbDoiMK.Visible = false;
            panel4.BorderStyle = BorderStyle.None;
        }
    }
}