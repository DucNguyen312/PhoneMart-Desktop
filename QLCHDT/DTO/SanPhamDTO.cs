using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class SanPhamDTO
    {
        private string _maSP, _tenSP, _motaSP, _maTH;
        private long _giaSP;

        public string MaSP
        {
            get
            {
                return _maSP;
            }

            set
            {
                _maSP = value;
            }
        }

        public string TenSP
        {
            get
            {
                return _tenSP;
            }

            set
            {
                _tenSP = value;
            }
        }

        public string MotaSP
        {
            get
            {
                return _motaSP;
            }

            set
            {
                _motaSP = value;
            }
        }

        public string MaTH
        {
            get
            {
                return _maTH;
            }

            set
            {
                _maTH = value;
            }
        }

        public long GiaSP
        {
            get
            {
                return _giaSP;
            }

            set
            {
                _giaSP = value;
            }
        }

       
        public SanPhamDTO()
        {
            this.MaSP = "";
            this.TenSP = "";
            this.MotaSP = "";
            this.MaTH = "";
            this.GiaSP = 0;
        }

        public SanPhamDTO(string _maSP, string _tenSP, string _motaSP, string _maTH, long _giaSP)
        {
            this.MaSP = _maSP;
            this.TenSP = _tenSP;
            this.MotaSP = _motaSP;
            this.MaTH = _maTH;
            this.GiaSP = _giaSP;
        }
    }
}
