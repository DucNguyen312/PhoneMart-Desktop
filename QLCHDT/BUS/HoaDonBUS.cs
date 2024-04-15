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
    class HoaDonBUS
    {
        public static void Them_HD(HoaDonDTO hd)
        {
            try
            {
                HoaDonDAO.ThemHD(hd);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Hoa Don không thành công ! ");
            }
        }
        public static void CapNhat_HD(HoaDonDTO hd)
        {
            try
            {
                HoaDonDAO.CapNhatHD(hd);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Hoa Don không thành công ! ");
            }
        }
        public static void Xoa_HD(HoaDonDTO hd)
        {
            if (MessageBox.Show("Bạn có muốn xóa hóa đơn này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    HoaDonDAO.XoaHD(hd);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa HD không thành công ! ");
                }
            }
        }
        public static void Xoa_HD_XacNhan(HoaDonDTO hd)
        {
            try
            {
                HoaDonDAO.XoaHD(hd);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa HD không thành công ! ");
            }
        }

    }
}

