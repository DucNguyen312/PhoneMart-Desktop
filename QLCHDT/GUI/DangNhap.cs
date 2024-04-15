using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCHDT.GUI;
using QLCHDT.DAO;
using QLCHDT.DTO;

namespace QLCHDT
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txttk.Text;
            nv.MkNV = txtmk.Text;
            DataTable dt = new DataTable();
            dt = NhanVienDAO.TK_MK(nv);
            int stt = dt.Rows.Count;
            if (stt == 1)
            {
                TrangChu tc = new TrangChu(dt.Rows[0][0].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][7].ToString());
                tc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu \nVui lòng Kiểm tra lại !!", "Thông Báo");
                txttk.Focus();
            }
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txttk_Enter(object sender, EventArgs e)
        {
            if (txttk.Text == "Tài Khoản")
            {
                txttk.Text = "";
                txttk.ForeColor = Color.Black;
            }
        }

        private void txttk_Leave(object sender, EventArgs e)
        {
            if (txttk.Text == "")
            {
                txttk.Text = "Tài Khoản";
                txttk.ForeColor = Color.DarkGray;
            }
        }

        private void txtmk_Enter(object sender, EventArgs e)
        {
            if (txtmk.Text == "Mật Khẩu")
            {
                txtmk.Text = "";  
            }
        }

        private void txtmk_Leave(object sender, EventArgs e)
        {
            if (txtmk.Text == "")
            {
                txtmk.Text = "Mật Khẩu";
            }
        }
    }
}
