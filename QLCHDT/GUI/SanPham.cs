using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCHDT.DTO;
using QLCHDT.BUS;
using QLCHDT.DAO;
using System.IO;
namespace QLCHDT.GUI
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

        private string fN;
        private string duongdan = Environment.CurrentDirectory + @"\img_sp\";

        // load danh sách sản phẩm
        public void TT_SP()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTThongtinSP();
            int stt = dt.Rows.Count;
            for (int i = 0; i < stt; i++)
            {
                lvdssp.Items.Add(dt.Rows[i]["MaSP"].ToString());
                lvdssp.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                lvdssp.Items[i].SubItems.Add(dt.Rows[i]["MaTH"].ToString());
                lvdssp.Items[i].SubItems.Add(string.Format("{0:#,##0}", long.Parse(dt.Rows[i]["Gia"].ToString())));
                lvdssp.Items[i].SubItems.Add(dt.Rows[i]["MotaSP"].ToString());
            }
            int sosp = lvdssp.Items.Count;
            lblsl.Text = sosp.ToString();
        }

        //Load thương hiệu lên combobox
        public void TH()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTThongtinTH();
            cbbthuonghieu.DataSource = dt;
            cbbthuonghieu.ValueMember = "MaTH";
            cbbthuonghieu.DisplayMember = "TenTH";
        }

        public int KTSP(string masp)
        {
            for (int i = 0; i < lvdssp.Items.Count; i++)
            {
                if (masp == lvdssp.Items[i].SubItems[0].Text)
                    return 1;
            }
            return -1;
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            TT_SP();
            TH();

            cbbtimkiem.Items.Add("Mã SP");
            cbbtimkiem.Items.Add("Tên SP");
            cbbtimkiem.Text = "Mã SP";
        }

        private void lvdssp_Click(object sender, EventArgs e)
        {
            txtmasp.Text = lvdssp.SelectedItems[0].SubItems[0].Text;
            txttensp.Text = lvdssp.SelectedItems[0].SubItems[1].Text;
            cbbthuonghieu.SelectedValue = lvdssp.SelectedItems[0].SubItems[2].Text;
            numgia.Text = lvdssp.SelectedItems[0].SubItems[3].Text;
            txtmotasp.Text = lvdssp.SelectedItems[0].SubItems[4].Text;
            try
            {
                picsp.Load(duongdan + txtmasp.Text + ".jpg");
            }
            catch
            {
                picsp.Load(Environment.CurrentDirectory + @"\img_nv\null.jpg");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.MaSP_MAX();
            if (dt.Rows.Count == 0)
            {
                txtmasp.Text = "SP001";
            }
            else
            {
                string masp = dt.Rows[0][0].ToString();
                txtmasp.Text = (int.Parse(masp.Substring(masp.Length - 3, 3)) + 1).ToString("SP000");
                txttensp.Text = cbbthuonghieu.Text = txtmotasp.Text = "";
                numgia.Value = 0;
                picsp.Image = null;
                int sosp = lvdssp.Items.Count;
                lblsl.Text = sosp.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KTSP(txtmasp.Text) == 1)
            {
                MessageBox.Show("Sản phẫm đã tồn tại !", "Thông Báo");
            }
            else
            {
                if(txtmasp.Text == "")
                {
                    MessageBox.Show("Vui lòng nhấn nút THÊM để thêm mã sản phẩm trước khi lưu sản phẩm", "Thông Báo");
                }
                else
                {
                    if (txttensp.Text.Trim() != "" && numgia.Value != 0)
                    {
                        SanPhamDTO sp = new SanPhamDTO();
                        sp.MaSP = txtmasp.Text;
                        sp.TenSP = txttensp.Text;
                        sp.GiaSP = long.Parse(numgia.Value.ToString());
                        sp.MaTH = cbbthuonghieu.SelectedValue.ToString();
                        sp.MotaSP = txtmotasp.Text;
                        SanPhamBUS.Them_SP(sp);
                        lvdssp.Items.Clear();
                        TT_SP();
                        int sosp = lvdssp.Items.Count;
                        lblsl.Text = sosp.ToString();
                        // thêm ảnh
                        try
                        {
                            string namepic = txtmasp.Text + ".jpg";
                            File.Copy(fN, Path.Combine(duongdan, namepic), true);
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập thông sản phẩm", "Thông Báo");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmasp.Text != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa sản phẩm này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.MaSP = txtmasp.Text;
                    SanPhamBUS.Xoa_SP(sp);
                    lvdssp.Items.Clear();
                    TT_SP();
                    int sosp = lvdssp.Items.Count;
                    lblsl.Text = sosp.ToString();
                    // xóa ảnh
                    try
                    {
                        picsp.Load(Environment.CurrentDirectory + @"\img_nv\null.jpg");
                        File.Delete(duongdan + txtmasp.Text + ".jpg");
                    }
                    catch { }
                    txtmasp.Text = txttensp.Text = txtmotasp.Text = "";
                    numgia.Text = "0";
                    MessageBox.Show("Xóa sản phẩm thành công !", "Thông Báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng sản phẩm muốn xóa", "Thông Báo");
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtmasp.Text.Trim() != "")
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.MaSP = txtmasp.Text;
                sp.TenSP = txttensp.Text;
                sp.GiaSP = long.Parse(numgia.Value.ToString());
                sp.MaTH = cbbthuonghieu.SelectedValue.ToString();
                sp.MotaSP = txtmotasp.Text;
                SanPhamBUS.CapNhat_SP(sp);
                lvdssp.Items.Clear();
                TT_SP();
                MessageBox.Show("Cập nhật sản phẩm thành công !", "Thông Báo");
                try
                {
                    picsp.Load(Environment.CurrentDirectory + @"\img_nv\null.jpg");
                    string namepic = txtmasp.Text + ".jpg";
                    File.Copy(fN, Path.Combine(duongdan, namepic), true);
                    picsp.Load(duongdan + txtmasp.Text + ".jpg");
                }
                catch
                {
                    try
                    {
                        picsp.Load(duongdan + txtmasp.Text + ".jpg");
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Bạn vui lòng chọn sản phẩm muốn cập nhật", "Thông Báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            SanPhamDTO sp = new SanPhamDTO();
            DataTable dt = new DataTable();
            if (cbbtimkiem.Text == "Mã SP")
            {
                lvdssp.Items.Clear();
                sp.MaSP = txttimkiem.Text.ToUpper();
                dt = SanPhamDAO.TimSPTheoMa(sp);
                int stt = dt.Rows.Count;
                if (stt > 0)
                {
                    for (int i = 0; i < stt; i++)
                    {
                        lvdssp.Items.Add(dt.Rows[i]["MaSP"].ToString());
                        lvdssp.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                        lvdssp.Items[i].SubItems.Add(dt.Rows[i]["MaTH"].ToString());
                        lvdssp.Items[i].SubItems.Add(string.Format("{0:#,##0}", long.Parse(dt.Rows[i]["Gia"].ToString())));
                        lvdssp.Items[i].SubItems.Add(dt.Rows[i]["MotaSP"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm mà bạn tìm kiếm", "Thông báo");
                    TT_SP();
                }
            }
            else
            {
                lvdssp.Items.Clear();
                sp.TenSP = txttimkiem.Text.ToUpper();
                dt = SanPhamDAO.TimSPTheoTen(sp);
                int stt = dt.Rows.Count;
                if (stt > 0)
                {
                    for (int i = 0; i < stt; i++)
                    {
                        lvdssp.Items.Add(dt.Rows[i]["MaSP"].ToString());
                        lvdssp.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                        lvdssp.Items[i].SubItems.Add(dt.Rows[i]["MaTH"].ToString());
                        lvdssp.Items[i].SubItems.Add(string.Format("{0:#,##0}", long.Parse(dt.Rows[i]["Gia"].ToString())));
                        lvdssp.Items[i].SubItems.Add(dt.Rows[i]["MotaSP"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm mà bạn tìm kiếm", "Thông báo");
                    TT_SP();
                }
            }
            int sosp = lvdssp.Items.Count;
            lblsl.Text = sosp.ToString();
        }

        private void picsp_Click(object sender, EventArgs e)
        {
            OpenFileDialog openpic = new OpenFileDialog();
            openpic.Title = "Chọn ảnh";
            openpic.Filter = "Image Files(*.jpg) | *.JPG";
            if (openpic.ShowDialog() == DialogResult.OK)
            {
                fN = openpic.FileName;
                using (var bitmap = new Bitmap(fN))
                    picsp.Image = new Bitmap(bitmap);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lvdssp.Items.Clear();
            TT_SP();
        }
    }
}
