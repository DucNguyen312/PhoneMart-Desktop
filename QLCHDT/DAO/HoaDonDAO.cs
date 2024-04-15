using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCHDT.DTO;
using System.Data;
namespace QLCHDT.DAO
{
    class HoaDonDAO
    {
        public static DataTable TT_MaHD()
        {
            string sql = "select MaHD from HoaDon";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable MaHD_MAX()
        {
            string sql = "select top 1 MaHD from HoaDon order by  MaHD desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_HD()
        {
            string sql = "select MaHD, HoaDon.MaNV, TenNV , KhachHang.MaKH, TenKH, HoaDon.MaGH, TongSoLuong , TongTien ,NgayBan,TrangThai from GioHang,HoaDon,NhanVien,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and HoaDon.MaNV = NhanVien.MaNV";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TT_HD_ChiTiet(HoaDonDTO hd)
        {
            string sql = "select MaHD, HoaDon.MaNV, TenNV , KhachHang.MaKH, TenKH,KhachHang.DiaChi,KhachHang.SDT, HoaDon.MaGH, TenSP , SoLuong , Gia , TongSoLuong , TongTien ,NgayBan, TrangThai from GioHang,HoaDon,NhanVien,KhachHang,SPMua,SanPham where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and HoaDon.MaNV = NhanVien.MaNV and  SPMua.MaSP = SanPham.MaSP and SPMua.MaGH = GioHang.MaGH and MaHD = '"+hd.MaHD+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_HD_Giam(string s)
        {
            string sql = "select MaHD, HoaDon.MaNV, TenNV , KhachHang.MaKH, TenKH, HoaDon.MaGH, TongSoLuong , TongTien ,NgayBan,TrangThai from GioHang,HoaDon,NhanVien,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and HoaDon.MaNV = NhanVien.MaNV order by "+s+" desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TT_HD_Tang(string s)
        {
            string sql = "select MaHD, HoaDon.MaNV, TenNV , KhachHang.MaKH, TenKH, HoaDon.MaGH, TongSoLuong , TongTien ,NgayBan,TrangThai from GioHang,HoaDon,NhanVien,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and HoaDon.MaNV = NhanVien.MaNV order by " + s + "";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TimKiemHD(string s , string t)
        {
            string sql = "select MaHD, HoaDon.MaNV, TenNV , KhachHang.MaKH, TenKH, HoaDon.MaGH, TongSoLuong , TongTien ,NgayBan,TrangThai from GioHang,HoaDon,NhanVien,KhachHang where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and HoaDon.MaNV = NhanVien.MaNV and "+s+" like N'%"+t+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable XuatHD(HoaDonDTO hd)
        {
            string sql = "select MaHD, HoaDon.MaNV, TenNV , KhachHang.MaKH, TenKH,KhachHang.DiaChi, KhachHang.SDT, HoaDon.MaGH, TenSP , SoLuong , Gia , SoLuong * Gia as ThanhTien  ,NgayBan from GioHang , HoaDon, NhanVien, KhachHang, SPMua, SanPham where HoaDon.MaGH = GioHang.MaGH and KhachHang.MaKH = HoaDon.MaKH and HoaDon.MaNV = NhanVien.MaNV and  SPMua.MaSP = SanPham.MaSP and SPMua.MaGH = GioHang.MaGH and MaHD = '"+hd.MaHD+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static void ThemHD(HoaDonDTO hd)
        {
            string sql = "insert into HoaDon (MaHD ,MaGH , MaKH , MaNV , TrangThai ) values ('"+hd.MaHD+"','"+hd.MaGH+"','"+hd.MaKH+"','"+hd.MaNV+"',N'"+hd.TrangThai+"')";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void CapNhatHD(HoaDonDTO hd)
        {
            string sql = "update HoaDon set TrangThai = N'"+hd.TrangThai+"' where MaHD = '"+hd.MaHD+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void XoaHD(HoaDonDTO hd)
        {
            string sql = "delete from HoaDon where MaHD = '"+hd.MaHD+"'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
    }
}
