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
        private List<SinhVienDto> sinhVienDtos;
        public QuanLyDeTaiNCKH_bll()
        {
            sinhVienDtos = new List<SinhVienDto>();
        }
        //public List<DeTaiDto> timKiemDeTai(string tuKhoa)
        //{
        //    return danhSachDeTai.Where(dt => dt.MaDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 || dt.TenDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 || dt.HoTenGiangVien.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        //}
        
        //case 5: Hiếu
        private List<DeTaiDto> timKiemDeTaiTheoGiangVien(string tenGiangVien)
        {
            return sinhVienDtos.SelectMany(sv => sv.DanhSachDeTai)
                               .Where(dt => dt.HoTenGiangVien.IndexOf(tenGiangVien, StringComparison.OrdinalIgnoreCase) >= 0)
                               .ToList();
        }

        public void XuatDanhSachTimKiemTheoGiangVien()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập tên giảng viên cần tìm: ");
            string tenGiangVien = Console.ReadLine();
            List<DeTaiDto> dsDeTai = timKiemDeTaiTheoGiangVien(tenGiangVien);
            if (dsDeTai == null || dsDeTai.Count == 0)
            {
                Console.WriteLine("Không tìm thấy đề tài nào của giảng viên {0}", tenGiangVien);
            }
            else
            {
                Console.WriteLine("Danh sách đề tài của giảng viên {0}:", tenGiangVien);
                foreach (var dt in dsDeTai)
                {
                    Console.WriteLine(dt);
                }
            }
        }


        //public void capNhatVaXuatKinhPhi()
        //{
        //    foreach (var sv in sinhVienDtos)
        //    {
        //        double kinhPhiMoi = dt.TinhKinhPhi() + (dt.TinhKinhPhi() * 0.1); 
        //        Console.WriteLine(dt);
        //    }
        //}

        public void readSinhVienInfoDetail()
        {
            sinhVienDtos = dal.DocDeTaiNCKH("../../../Data/Data.xml");
        }

        public void PrintHeader()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("╔════════════╦══════════════════════╦════════════╦═════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Mã SV      ║ Họ Tên               ║ Lớp        ║ Mã ĐT  Tên Đề Tài                           Loại ĐT    TG BĐ      TG KT       GVHD                 Kinh Phí     ║");
            Console.WriteLine("╚════════════╧══════════════════════╧════════════╧═════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }

        //case 3
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

        //case 2
        public bool AddNewDeTai()
        {
            Console.Write("Nhập mã sinh viên để thêm đề tài: ");
            string maSinhVien = Console.ReadLine();

            if (string.IsNullOrEmpty(maSinhVien))
            {
                Console.WriteLine("Mã sinh viên không được để trống!");
                return false;
            }

            dal.ThemDeTaiChoSinhVien(maSinhVien);
            return true; 
        }

        //case 8
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
