using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCHDT.DAO;
using QLCHDT.DTO;
using System.Windows.Forms;

namespace QLCHDT.BUS
{
    class NhanVienBUS
    {
        public static void Them_NhanVien(NhanVienDTO nv)
        {
            try
            {
                NhanVienDAO.ThemNhanVien(nv);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công ! ");
            }
        }
        public static void Xoa_NhanVien(NhanVienDTO nv)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    NhanVienDAO.XoaNhanVien(nv);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa không thành công ! ");
                }
            }
        }
        public static void CapNhat_NhanVien(NhanVienDTO nv)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật thông tin này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    NhanVienDAO.CapNhatNhanVien(nv);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công ! ");
                }
            }
        }
        public static void CapNhat_MK(NhanVienDTO nv)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật lại mật khẩu ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    NhanVienDAO.CapNhatMKMoi(nv);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập Nhật không thành công ! ");
                }
            }
        }

    }
}
