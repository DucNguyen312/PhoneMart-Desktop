using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class ThuongHieuDTO
    {
        private string _MaTH, _TenTH;

        public ThuongHieuDTO()
        {
            this.MaTH = "";
            this.TenTH = "";
        }
        public ThuongHieuDTO(string _MaTH, string _TenTH)
        {
            this.MaTH = _MaTH;
            this.TenTH = _TenTH;
        }

        public string MaTH
        {
            get
            {
                return _MaTH;
            }

            set
            {
                _MaTH = value;
            }
        }

        public string TenTH
        {
            get
            {
                return _TenTH;
            }

            set
            {
                _TenTH = value;
            }
        }
    }
}
