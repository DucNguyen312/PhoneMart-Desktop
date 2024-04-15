using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class KhachHangDTO
    {
        private string _MaKH, _TenKH, _DiaChi, _SDT;

        public KhachHangDTO()
        {
            this.MaKH = "";
            this.TenKH = "";
            this.DiaChi = "";
            this.SDT = "";
        }
        public KhachHangDTO(string _MaKH, string _TenKH, string _DiaChi, string _SDT)
        {
            this.MaKH = _MaKH;
            this.TenKH = _TenKH;
            this.DiaChi = _DiaChi;
            this.SDT = _SDT;
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

        public string TenKH
        {
            get
            {
                return _TenKH;
            }

            set
            {
                _TenKH = value;
            }
        }
    }
}
