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
    public partial class RP_ThongKe : Form
    {
        public RP_ThongKe()
        {
            InitializeComponent();
        }

        public string tungay, denngay;
        private void RP_ThongKe_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            GioHangDTO gh1 = new GioHangDTO();
            GioHangDTO gh2 = new GioHangDTO();

            string dttungay = DateTime.Parse(tungay).ToString("MM/dd/yyyy");
            string dtdenngay = DateTime.Parse(denngay).ToString("MM/dd/yyyy");
            gh1.NgayBan = dttungay;
            gh2.NgayBan = dtdenngay;

            dt = GioHangDAO.RP_ThongKe(gh1, gh2);
            CRY_ThongKe cys = new CRY_ThongKe();
            cys.SetDataSource(dt);
            cys.SetParameterValue("TuNgay", tungay);
            cys.SetParameterValue("DenNgay", denngay);
            crystalReportViewer1.ReportSource = cys;
        }
    }
}
