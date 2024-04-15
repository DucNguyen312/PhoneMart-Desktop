using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class GioHangDTO
    {
        private string _MaGh, _NgayBan , _MaNV, _SPMua;
        private long _TongSoLuong, _ThanhTien;

        public GioHangDTO()
        {
            this._MaGh = "";
            this._NgayBan = "";
            this._MaNV = "";
            this._SPMua = "";
            this._TongSoLuong = 0;
            this._ThanhTien = 0;
        }

        public GioHangDTO(string _MaGh, string _NgayBan, string _MaNV, string _SPMua, long _TongSoLuong, long _ThanhTien)
        {
            this._MaGh = _MaGh;
            this._NgayBan = _NgayBan;
            this._MaNV = _MaNV;
            this._SPMua = _SPMua;
            this._TongSoLuong = _TongSoLuong;
            this._ThanhTien = _ThanhTien;
        }

        public string MaGh
        {
            get
            {
                return _MaGh;
            }

            set
            {
                _MaGh = value;
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

        public string NgayBan
        {
            get
            {
                return _NgayBan;
            }

            set
            {
                _NgayBan = value;
            }
        }

        public string SPMua
        {
            get
            {
                return _SPMua;
            }

            set
            {
                _SPMua = value;
            }
        }

        public long ThanhTien
        {
            get
            {
                return _ThanhTien;
            }

            set
            {
                _ThanhTien = value;
            }
        }

        public long TongSoLuong
        {
            get
            {
                return _TongSoLuong;
            }

            set
            {
                _TongSoLuong = value;
            }
        }
    }
}
