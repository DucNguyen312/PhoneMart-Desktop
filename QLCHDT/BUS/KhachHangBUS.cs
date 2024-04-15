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
    class KhachHangBUS
    {
        public static void Them_KH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.Them_MaKH(kh);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Mã KH không thành công ! ");
            }
        }
        public static void CapNhat_KH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.CapNhatKH(kh);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập Nhật KH không thành công ! ");
            }
        }
         public static void Xoa_KH(KhachHangDTO kh)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này ? \nNếu xóa hóa đơn của người này sẽ bị xóa !", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    KhachHangDAO.XoaKH(kh);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập Nhật KH không thành công ! ");
                }
            }          
        }
    }
}
