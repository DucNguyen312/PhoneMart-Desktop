using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class HoaDonDTO
    {
        private string _MaHD, _MaGH, _MaNV , _TrangThai ,_MaKH;

        public HoaDonDTO()
        {
            this.MaHD = "";
            this.MaGH = "";
            this.MaNV = "";
            this.TrangThai = "";
            this.MaKH = "";
        }     

        public HoaDonDTO(string _MaHD, string _MaGH, string _MaNV, string _TrangThai, string _MaKH)
        {
            this.MaHD = _MaHD;
            this.MaGH = _MaGH;
            this.MaNV = _MaNV;
            this.TrangThai = _TrangThai;
            this.MaKH = _MaKH;
        }

        public string MaGH
        {
            get
            {
                return _MaGH;
            }

            set
            {
                _MaGH = value;
            }
        }

        public string MaHD
        {
            get
            {
                return _MaHD;
            }

            set
            {
                _MaHD = value;
            }
        }

        public string MaKH
        {
            get
            {
                return _MaKH;
            }

            set
            {
                _MaKH = value;
            }
        }

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

        public string TrangThai
        {
            get
            {
                return _TrangThai;
            }

            set
            {
                _TrangThai = value;
            }
        }
    }
}
