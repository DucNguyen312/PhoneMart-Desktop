using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCHDT.DTO;
using System.Data;

namespace QLCHDT.DAO
{
    class SanPhamDAO
    {
        public static DataTable TTThongtinSP()
        {
            string sql = "select * from SanPham";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TTTH()
        {
            string sql = "select * from ThuongHieu";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable KTTH(ThuongHieuDTO th)
        {
            string sql = "select * from ThuongHieu where MaTH = '"+th.MaTH+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TTSP()
        {
            string sql = "select MaSP,TenSP,Gia from SanPham";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TT_ThuongHieu()
        {
            string sql = "select maTh,TenTH from ThuongHieu";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TTThongtinTH()
        {
            string sql = "select * from ThuongHieu";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable MaSP_MAX()
        {
            string sql = "select top 1 MaSP from SanPham order by  MaSP desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TTSP_MaSP(SanPhamDTO sp)
        {
            string sql = "select MaSP,TenSP,Gia from SanPham where MaSP = '"+sp.MaSP+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TTSP_MaTH(SanPhamDTO sp)
        {
            string sql = "select MaSP,TenSP,Gia from SanPham where MaTH = '" + sp.MaTH + "'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TimSPTheoMa(SanPhamDTO sp)
        {
            string sql = "select * from SanPham where MaSP like '%"+sp.MaSP+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TimSPTheoTen(SanPhamDTO sp)
        {
            string sql = "select * from SanPham where TenSP like '%"+sp.TenSP+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable SPMUA_NhieuNhat()
        {
            string sql = "select top 3 SanPham.MaSP , Tensp , Gia ,SUM(SoLuong) as SL  from GioHang,SPMua,SanPham where SPMua.MaGH = GioHang.MaGH and SPMua.MaSP = SanPham.MaSP group by SanPham.MaSP,TenSP,Gia order by SL desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static void ThemSP(SanPhamDTO sp)
        {
            string sql = "insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('"+sp.MaSP+"', N'"+sp.TenSP+"' , "+sp.GiaSP+ " , N'" + sp.MotaSP + "' , '"+sp.MaTH+"' )";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void XoaSP(SanPhamDTO sp)
        {
            string sql = "delete from SanPham where MaSP = '"+sp.MaSP+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void CapNhatSP(SanPhamDTO sp)
        {
            string sql = "update SanPham set TenSP = N'"+sp.TenSP+"' , Gia = "+sp.GiaSP+" , MotaSP = N'"+sp.MotaSP+"' , MaTH = '"+sp.MaTH+"' where MaSP = '"+sp.MaSP+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void ThemTH(ThuongHieuDTO th)
        {
            string sql = "insert into ThuongHieu (MATH , TenTH) values ('"+th.MaTH+"' , N'"+th.TenTH+"')";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void CapNhatTH(ThuongHieuDTO th)
        {
            string sql = "update ThuongHieu set TenTH = N'"+th.TenTH+"' where MaTH = '"+th.MaTH+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void XoaTH(ThuongHieuDTO th)
        {
            string sql = "delete from ThuongHieu where Math = '"+th.MaTH+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }

    }
}
