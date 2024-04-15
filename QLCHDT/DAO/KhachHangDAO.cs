using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCHDT.DTO;
using System.Data;
namespace QLCHDT.DAO
{
    class KhachHangDAO
    {
        public static DataTable TT_KH()
        {
            string sql = "select MaKH from KhachHang";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_KH_TongTien()
        {
            string sql = "select KhachHang.MaKH, TenKH, DiaChi, SDT ,NgayBan ,TongTien from GioHang,HoaDon,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and TrangThai = 'Thành Công'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TT_KH_MaKH(KhachHangDTO kh)
        {
            string sql = "select * from KhachHang where MaKH = '"+kh.MaKH+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TT_KH_TheoMa(KhachHangDTO kh)
        {
            string sql = "select HoaDon.MaKH, TenKH, DiaChi, SDT ,NgayBan ,TongTien from GioHang,HoaDon,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and TrangThai = N'Thành Công' and HoaDon.MaKH like N'%"+kh.MaKH+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_KH_TheoTen(KhachHangDTO kh)
        {
            string sql = "select KhachHang.MaKH, TenKH, DiaChi, SDT ,NgayBan ,TongTien from GioHang,HoaDon,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and TrangThai = 'Thành Công' and KhachHang.TenKH like N'%"+kh.TenKH+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable MaKH_MAX()
        {
            string sql = "select top 1 MaKH from KhachHang order by  MaKH desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static void Them_MaKH(KhachHangDTO kh)
        {
            string sql = "insert into KhachHang (MaKH) values ('"+kh.MaKH+"')";
            KNCSDL.ThucThiCauTruyVan(sql);
        }

        public static void CapNhatKH(KhachHangDTO kh)
        {
            string sql = "update KhachHang set TenKH = N'"+kh.TenKH+"' , DiaChi = N'"+kh.DiaChi+"' , SDT = '"+kh.SDT+"' where MaKH = '"+kh.MaKH+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void XoaKH(KhachHangDTO kh)
        {
            string sql = "delete from KhachHang where MaKH = '"+kh.MaKH+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
    }
}
