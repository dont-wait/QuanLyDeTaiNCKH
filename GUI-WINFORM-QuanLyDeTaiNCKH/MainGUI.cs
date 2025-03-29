using BLL_QuanLyDeTaiNCKH;
using DTO_QuanLyDeTaiNCKH.entity;

namespace GUI_WINFORM_QuanLyDeTaiNCKH
{
    public partial class MainGUI : Form
    {
        QuanLyDeTaiNCKH_bll bll = new QuanLyDeTaiNCKH_bll();
        List<SinhVienDto> listSinhVien = new List<SinhVienDto>();

        public MainGUI()
        {
            InitializeComponent();
            listSinhVien = bll.getSinhVienInfoDetail();
            dataGridView1.DataSource = listSinhVien;
        }
        private void MainGUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            List<SinhVienDto> sinhVienDtos = bll.getSinhVienInfoDetail();
            dataGridView1.DataSource = listSinhVien;
        }
    }
}
