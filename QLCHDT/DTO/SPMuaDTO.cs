using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCHDT.DTO
{
    class SPMuaDTO
    {
        private int _stt , _soluong;
        private string _MaSP, _MaGH;
        public SPMuaDTO()
        {
            this._stt = 0;
            this.Soluong = 0;
            this._MaSP = "";
            this._MaGH = "";
        }
        public SPMuaDTO(int _stt,int _soluong, string _MaSP, string _MaGH)
        {
            this._stt = _stt;
            this._soluong = _soluong;
            this._MaSP = _MaSP;
            this._MaGH = _MaGH;
        }

        public int Stt
        {
            get
            {
                return _stt;
            }

            set
            {
                _stt = value;
            }
        }

        public string MaSP
        {
            get
            {
                return _MaSP;
            }

            set
            {
                _MaSP = value;
            }
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

        public int Soluong
        {
            get
            {
                return _soluong;
            }

            set
            {
                _soluong = value;
            }
        }
    }
}
