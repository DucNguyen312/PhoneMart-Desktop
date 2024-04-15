using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCHDT.DTO;
using System.Data;

namespace QLCHDT.DAO
{
    class GioHangDAO
    {

        public static DataTable TT_GH()
        {
            string sql = "select MaGH from GioHang";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_GH_MaGH(GioHangDTO gh)
        {
            string sql = "select * from GioHang where MaGH = '"+gh.MaGh+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable MaGH_MAX()
        {
            string sql = "select top 1 MaGH from GioHang order by  MaGH desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable DoanhThuNgay(GioHangDTO gh)
        {
            string sql = "select SUM(TongTien) as TongTien, SUM(TongSoLuong) as TongSoLuong , Count(gh.MaGH) as SLDH from GioHang gh,HoaDon hd where gh.MaGH = hd.MaGH and TrangThai = N'Thành Công' and NgayBan BETWEEN '"+gh.NgayBan+" 00:00:00' AND '" + gh.NgayBan + " 23:59:59' ";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable BieuDo(GioHangDTO gh1 , GioHangDTO gh2)
        {
            string sql = "select CAST(NgayBan as date) as NgayBan ,FORMAT(SUM(TongTien),'#,##0') as TongTien  from GioHang gh,HoaDon hd where gh.MaGH = hd.MaGH and TrangThai = N'Thành Công' and  NgayBan BETWEEN '"+gh1.NgayBan+" 00:00:00' and '"+gh2.NgayBan+ " 23:59:59' Group by CAST(NgayBan as date)";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable RP_ThongKe(GioHangDTO gh1 , GioHangDTO gh2)
        {
            string sql = "select MaHD , KhachHang.MaKH, TenKH, DiaChi, KhachHang.SDT, HoaDon.MaGH, TenSP , SoLuong , Gia , SoLuong * Gia as ThanhTien , NgayBan from GioHang , HoaDon, KhachHang, SPMua, SanPham where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and  SPMua.MaSP = SanPham.MaSP and SPMua.MaGH = GioHang.MaGH and TrangThai = N'Thành Công' and  NgayBan between '" + gh1.NgayBan+" 00:00:00' and '"+gh2.NgayBan+" 23:59:59' order by NgayBan";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static void ThemSP_GioHang(GioHangDTO gh)
        {
            string sql = "insert into GioHang ([MaGH],[NgayBan],[TongSoLuong],[TongTien]) values ('"+gh.MaGh+"','"+gh.NgayBan+"', "+gh.TongSoLuong+" ,"+gh.ThanhTien+")";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void CapNhat_GioHang(GioHangDTO gh)
        {
            string sql = "update GioHang set NgayBan ='"+gh.NgayBan+"' where MaGH = '"+gh.MaGh+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void Xoa_GioHang(GioHangDTO gh)
        {
            string sql = "delete from GioHang where MaGH = '"+gh.MaGh+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
    }
}
