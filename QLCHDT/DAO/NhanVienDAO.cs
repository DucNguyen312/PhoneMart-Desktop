using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCHDT.DTO;

namespace QLCHDT.DAO
{
    class NhanVienDAO
    {
        public static DataTable TTNhanVien()
        {
            string sql = "select * from NhanVien";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TTNhanVienQL()
        {
            string sql = "select * from NhanVien where chucvu = N'Quản Lý'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }
        public static DataTable TK_MK(NhanVienDTO nv)
        {
            string sql = "select * from NhanVien where MaNV ='"+nv.MaNV+"' and MkNV = '"+nv.MkNV+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable MaNV_MAX()
        {
            string sql = "select top 1 MaNV from NhanVien order by MaNV desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TimMaNhanVien(NhanVienDTO nv)
        {
            string sql = "SELECT MaNV, TenNV , NgaySinh , GioiTinh , DiaChi , SDT , chucvu FROM NhanVien WHERE MaNV like '%" + nv.MaNV + "%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable TimTenNhanVien(NhanVienDTO nv)
        {
            string sql = "SELECT MaNV, TenNV , NgaySinh , GioiTinh , DiaChi , SDT , chucvu FROM NhanVien WHERE TenNV like N'%" + nv.TenNV + "%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static DataTable MkCu(NhanVienDTO nv)
        {
            string sql = "select MkNV from NhanVien where MaNV = '" + nv.MaNV + "'";
            DataTable dt = new DataTable();
            dt = KNCSDL.DocDuLieu(sql);
            return dt;
        }

        public static void ThemNhanVien(NhanVienDTO nv)
        {
            string sql = "insert into NhanVien (MaNV ,MkNV, TenNV , NgaySinh , GioiTinh , DiaChi , SDT , chucvu ) values ('" + nv.MaNV + "','" + nv.MkNV + "',N'" + nv.TenNV + "','" + nv.NgaySinh + "'," + nv.GioiTinh + ",N'" + nv.DiaChi + "','" + nv.SDT + "',N'" + nv.Chucvu + "')";
            KNCSDL.ThucThiCauTruyVan(sql);
        }

        public static void XoaNhanVien(NhanVienDTO nv)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV = '"+nv.MaNV+"' and chucvu = N'Nhân Viên'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }

        public static void CapNhatNhanVien(NhanVienDTO nv)
        {
            string sql = "update NhanVien set TenNV = N'" + nv.TenNV + "' , NgaySinh = '" + nv.NgaySinh + "' , GioiTinh = " + nv.GioiTinh + " , DiaChi = N'" + nv.DiaChi + "' , SDT = '" + nv.SDT + "' where MaNV ='" + nv.MaNV + "'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }
        public static void CapNhatMKMoi(NhanVienDTO nv)
        {
            string sql = "update NhanVien set MkNV = '" + nv.MkNV + "' where MaNV = '" + nv.MaNV + "'";
            KNCSDL.ThucThiCauTruyVan(sql);
        }

    }
}
