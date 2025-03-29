using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyDeTaiNCKH;
using DTO_QuanLyDeTaiNCKH.entity;
namespace BLL_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_bll
    {
        private QuanLyDeTaiNCKH_dal dal = new QuanLyDeTaiNCKH_dal();
        private List<DeTaiDto> danhSachDeTai;
        public QuanLyDeTaiNCKH_bll()
        {
           
        }
        public List<DeTaiDto> timKiemDeTai(string tuKhoa)
        {
            return danhSachDeTai.Where(dt => dt.MaDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 || dt.TenDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 || dt.HoTenGiangVien.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        public List<DeTaiDto> timKiemDeTaiTheoGiangVien(string tenGiangVien)
        {
            return danhSachDeTai.Where(dt => dt.HoTenGiangVien.IndexOf(tenGiangVien, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void capNhatVaXuatKinhPhi()
        {
            foreach (var dt in danhSachDeTai)
            {
                double kinhPhiMoi = dt.TinhKinhPhi() + (dt.TinhKinhPhi() * 0.1); // Tăng 10%
                Console.WriteLine(dt);
            }
        }

        public List<SinhVienDto> readSinhVienInfoDetail()
        {
            return dal.DocDeTaiNCKH("../../../Data/Data.xml");
        }

        public void PrintHeader()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("╔════════════╦══════════════════════╦════════════╦══════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Mã SV      ║ Họ Tên               ║ Lớp        ║ Mã ĐT  Tên Đề Tài                           Loại ĐT    TG BĐ       TG KT      GVHD               ║");
            Console.WriteLine("╚════════════╧══════════════════════╧════════════╧══════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }

        public void XuatTTSinhVien()
        {
            if(dal.ListSinhVien.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên rỗng!");
                return;
            }
            PrintHeader();
            foreach (var sv in dal.ListSinhVien)
            {
                Console.WriteLine(sv);
            }
        }

        public void GetSecret()
        {
            Console.WriteLine(@"Từ ấy trong tôi bừng code gạo,
Màn hình code đỏ cứa con tim.
Hồn tôi ngập tràn do-for-while,
Rất nhị phân và đầy tiếng đô-la.
                                Từ ấy");
        }
    }
}
