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
    class SPMuaBUS
    {
        public static void ThemSP(SPMuaDTO spm)
        {
            try
            {
                SPMuaDAO.ThemSP(spm);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm SP Mua không thành công ! ");
            }
        }
    }
}
