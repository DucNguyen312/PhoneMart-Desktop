using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCHDT.DTO;
using System.Data;
using QLCHDT.DAO;

namespace QLCHDT.DAO
{
    class SPMuaDAO
    {
        public static void ThemSP(SPMuaDTO spm)
        {
            string sql = "insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values ("+spm.Stt+","+spm.Soluong+",'"+spm.MaGH+"','"+spm.MaSP+"')";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static DataTable TT_SPMua_LV(SPMuaDTO spm)
        {
            string sql = "select TenSP, SoLuong , MaGH from SPMua,SanPham where SPMua.MaSP = SanPham.MaSP and MaGH = '"+spm.MaGH+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_SPMua(SPMuaDTO spm)
        {
            string sql = "select TenSP , SoLuong , Gia from SPMua,GioHang,SanPham where SPMua.MaSP = SanPham.MaSP and SPMua.MaGH = GioHang.MaGH and GioHang.MaGH = '"+spm.MaGH+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

    }
}
