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
    class SanPhamBUS
    {
        public static void Them_SP(SanPhamDTO sp)
        {
            try
            {
                SanPhamDAO.ThemSP(sp);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công ! ");
            }
        }
        public static void Xoa_SP(SanPhamDTO sp)
        {
            try
            {
                SanPhamDAO.XoaSP(sp);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công ! ");
            }

        }
        public static void CapNhat_SP(SanPhamDTO sp)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật sản phẩm này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SanPhamDAO.CapNhatSP(sp);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công ! ");
                }
            }
        }
    }
}
