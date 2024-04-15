using QLCHDT.DAO;
using QLCHDT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHDT.GUI
{
    public partial class RP_CTHD : Form
    {
        public RP_CTHD()
        {
            InitializeComponent();
        }
        private string mahd;
        public RP_CTHD(string ma_hd) : this()
        {
            this.mahd = ma_hd;
        }

        private void RP_CTHD_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            HoaDonDTO hd = new HoaDonDTO();
            hd.MaHD = mahd;
            dt = HoaDonDAO.XuatHD(hd);
            Cry_CTHD cry = new Cry_CTHD();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
