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
    class GioHangBUS
    {
        public static void ThemSP_GioHang(GioHangDTO gh)
        {
            try
            {
                GioHangDAO.ThemSP_GioHang(gh);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm SP vào giỏ hàng không thành công ! ");
            }
        }
        public static void CapNhat_GioHang(GioHangDTO gh)
        {
            try
            {
                GioHangDAO.CapNhat_GioHang(gh);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập Nhật Ngày bán không thành công ! ");
            }
        }
        public static void Xoa_GioHang(GioHangDTO gh)
        {
            try
            {
                GioHangDAO.Xoa_GioHang(gh);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa  không thành công ! ");
            }
        }
    }
}
