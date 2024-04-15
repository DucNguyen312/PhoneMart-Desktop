using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class NhanVienDTO
    {
        private string _MaNV;
        private string _MkNV;
        private string _TenNV;
        private string _NgaySinh;
        private int _GioiTinh;
        private string _DiaChi;
        private string _SDT;
        private string _chucvu;
 
        public string MaNV
        {
            get
            {
                return _MaNV;
            }

            set
            {
                _MaNV = value;
            }
        }

        public string TenNV
        {
            get
            {
                return _TenNV;
            }

            set
            {
                _TenNV = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
            }
        }

        public int GioiTinh
        {
            get
            {
                return _GioiTinh;
            }

            set
            {
                _GioiTinh = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }

            set
            {
                _DiaChi = value;
            }
        }

        public string SDT
        {
            get
            {
                return _SDT;
            }

            set
            {
                _SDT = value;
            }
        }

        public string MkNV
        {
            get
            {
                return _MkNV;
            }

            set
            {
                _MkNV = value;
            }
        }

        public string Chucvu
        {
            get
            {
                return _chucvu;
            }

            set
            {
                _chucvu = value;
            }
        }

        public NhanVienDTO()
        {
            _MaNV = "";
            _MkNV = "";
            _TenNV = "";
            _NgaySinh = "";
            _GioiTinh = 0;
            _DiaChi = "";
            _SDT = "";
            _chucvu = "";
        }
     
        public NhanVienDTO(string _MaNV, string _MkNV, string _TenNV, string _NgaySinh, int _GioiTinh, string _DiaChi, string _SDT, string _chucvu)
        {
            this._MaNV = _MaNV;
            this._MkNV = _MkNV;
            this._TenNV = _TenNV;
            this._NgaySinh = _NgaySinh;
            this._GioiTinh = _GioiTinh;
            this._DiaChi = _DiaChi;
            this._SDT = _SDT;
            this._chucvu = _chucvu;
        }
    }
}
