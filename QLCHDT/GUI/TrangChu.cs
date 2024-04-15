using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCHDT.DAO;
using QLCHDT.BUS;
using QLCHDT.DTO;
using QLCHDT.GUI;

namespace QLCHDT.GUI
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private string maNV;
        private string tenNV;
        private string chucvu;


        //hàm khởi tạo (Contructor) lấy dữ liệu bên form DangNhap qua
        public TrangChu(string ma_NV, string Ten_NV, string chuc_vu) : this()
        {
            maNV = ma_NV;
            tenNV = Ten_NV;
            chucvu = chuc_vu;
            lblTenNV.Text = tenNV;
            lblchucvu.Text = chucvu;
        }

        //khởi tạo hàm form con
        private Form currentFormChild;
        private void OpendChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelformchild.Controls.Add(childForm);
            panelformchild.Tag = childForm;
            childForm.Show();
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {
            if (lblchucvu.Text == "Nhân Viên")
            {
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
                btnKhachHang.Visible = false;
            }
            else
            {
                OpendChildForm(new ThongKe());
            }
            timer1.Enabled = true;

        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            OpendChildForm(new TrangCaNhan(maNV));
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpendChildForm(new NhanVien());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpendChildForm(new TrangCaNhan(maNV));
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpendChildForm(new KhachHang());
        }
        private bool isthoat = true;
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            isthoat = false;
            this.Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isthoat)
                Application.Exit();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpendChildForm(new SanPham());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpendChildForm(new BanHang(maNV));

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            OpendChildForm(new TrangCaNhan(maNV));

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpendChildForm(new HoaDon(maNV));
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpendChildForm(new ThongKe());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
