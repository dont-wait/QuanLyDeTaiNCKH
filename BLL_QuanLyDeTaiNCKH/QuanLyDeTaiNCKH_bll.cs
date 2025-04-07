using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyDeTaiNCKH;
using DeTai1;
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
        
       

        //Case 1: Sang
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


        //case 2: Sang
        public bool AddNewDeTai()
        {

            while (true)
            {
                try
                {
                    Console.Write("Nhập mã sinh viên để thêm đề tài: ");
                    string maSinhVien = Console.ReadLine();
                    dal.ThemDeTaiChoSinhVien(maSinhVien);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Lỗi {e}");
                    Console.WriteLine("Vui lòng nhập lại mã số sinh viên");
                }
            }
            return true;


        }

        //case 3: Sang
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
        //case 4: Sang
        public void TinhKinhPhiChoTatCaDeTai()
        {
            Console.OutputEncoding = Encoding.UTF8;
            foreach (var sv in sinhVienDtos)
            {
                foreach (var dt in sv.DanhSachDeTai)
                {
                    if (dt.KinhPhi > 0) continue;
                    dt.KinhPhi = dt.TinhKinhPhi();
                }
            }
            Console.WriteLine("Kinh phí đã được tính cho tất cả các đề tài.");
        }


        // case 5: Hiếu
        private List<DeTaiDto> timKiemDeTai(string tuKhoa)
        {

            if (sinhVienDtos == null || sinhVienDtos.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên chưa được khởi tạo hoặc trống.");
                return new List<DeTaiDto>();
            }

            List<DeTaiDto> danhSachDeTai = new List<DeTaiDto>();
            Console.WriteLine();

            foreach (var sv in sinhVienDtos)
            {

                danhSachDeTai.AddRange(sv.DanhSachDeTai.Where(dt =>
                    dt.MaDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    dt.TenDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    dt.HoTenGiangVien.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    sv.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            return danhSachDeTai;
        }

        //case 5: Hiếu 
        public void XuatDanhSachTimKiemDeTai()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập thông tin tìm kiếm (Mã số đề tài, Tên đề tài, Tên giảng viên hoặc Tên người chủ trì): ");
            string tuKhoa = Console.ReadLine();

            List<DeTaiDto> dsDeTai = timKiemDeTai(tuKhoa);

            if (dsDeTai == null || dsDeTai.Count == 0)
            {
                Console.WriteLine("Không tìm thấy đề tài nào với thông tin '{0}'.", tuKhoa);
            }
            else
            {
                Console.WriteLine("Danh sách đề tài tìm được:");

                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Mã ĐT     │ Tên Đề Tài                │ Tên Giảng Viên           │ Tên Chủ Trì                   ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════╣");


                foreach (var dt in dsDeTai)
                {

                    string hoTenChuTri = sinhVienDtos.FirstOrDefault(sv => sv.DanhSachDeTai.Contains(dt))?.HoTen;


                    Console.WriteLine($"║ {dt.MaDeTai,-10}│ {dt.TenDeTai,-25} │ {dt.HoTenGiangVien,-25}│ {hoTenChuTri,-25}     ║");
                }

                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════╝");
            }
        }

        //case 6: Hiếu
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

                Console.WriteLine($"Danh sách đề tài của giang viên {tenGiangVien} tìm được:");

                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Mã ĐT     │ Tên Đề Tài                │ Tên Giảng Viên          │ Tên Chủ Trì                  ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════╣");


                foreach (var dt in dsDeTai)
                {

                    string hoTenChuTri = sinhVienDtos.FirstOrDefault(sv => sv.DanhSachDeTai.Contains(dt))?.HoTen;


                    Console.WriteLine($"║ {dt.MaDeTai,-10}│ {dt.TenDeTai,-25} │ {dt.HoTenGiangVien,-25}│ {hoTenChuTri,-25}   ║");
                }

                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            }
        }

        //case 7

        private void capNhatVaXuatKinhPhi()
        {
            foreach (var sv in sinhVienDtos)
            {
                for (int i = 0; i < sv.DanhSachDeTai.Count; i++)
                {
                    sv.DanhSachDeTai[i].KinhPhi *= 1.1; // Cập nhật Kinh Phi
                }
            }

        }
        public void XuatDanhSachCacDeTaiDaDuocCapNhatKinhPhi()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            capNhatVaXuatKinhPhi();

            Console.WriteLine("Danh sách đề tài sau khi cập nhật kinh phí:");
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ Mã ĐT     │ Tên Đề Tài                │ Kinh Phí (VNĐ)                     ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════╣");

            foreach (var sv in sinhVienDtos)
            {
                foreach (var dt in sv.DanhSachDeTai)
                {
                    Console.WriteLine($"║ {dt.MaDeTai,-10}│ {dt.TenDeTai,-25} │ {dt.KinhPhi,-20:N0} VNĐ           ║");
                }
            }

            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");
        }

        // case 8: Thành
        public void XuatDanhSachDeTai_CoKinhPhiHon10Trieu()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var dsDeTai = sinhVienDtos.SelectMany(sv => sv.DanhSachDeTai).Where(dt => dt.KinhPhi >= 10000000).ToList();
            
            if (!dsDeTai.Any())
            {
                Console.WriteLine("Không có đề tài nào có kinh phí trên 10 triệu.");
                return;
            }

            Console.WriteLine("Danh sách đề tài có kinh phí trên 10 triệu:");
            Console.WriteLine("╔════════════╦════════════════════════════════╦═══════════════════════╦══════════════════════╦════════════════╗");
            Console.WriteLine("║ Mã Đề Tài  ║ Tên Đề Tài                     ║ Giảng Viên Hướng Dẫn  ║ Tên Chủ Trì          ║ Kinh Phí       ║");
            Console.WriteLine("╠════════════╬════════════════════════════════╬═══════════════════════╬══════════════════════╬════════════════╣");

            foreach (var dt in dsDeTai)
            {
                string hoTenChuTri = sinhVienDtos.FirstOrDefault(sv => sv.DanhSachDeTai.Contains(dt))?.HoTen ?? "Không rõ";

                Console.WriteLine($"║ {dt.MaDeTai,-10} ║ {dt.TenDeTai,-30} ║ {dt.HoTenGiangVien,-20}  ║ {hoTenChuTri,-20} ║ {dt.KinhPhi,12:N0}   ║");
            }

            Console.WriteLine("╚════════════╩════════════════════════════════╩═══════════════════════╩══════════════════════╩════════════════╝");
        }


        //case 9: Thành
        public void XuatDanhSachDeTaiLyThuyetTrienKhai()
{
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;

                var dsDeTai = sinhVienDtos
                    .SelectMany(sv => sv.DanhSachDeTai).Where(dt => dt.GetTypeOfDeTai() == "Lý thuyết" && ((DeTaiLyThuyetDto)dt).ApDungThucTe).ToList();

                if (!dsDeTai.Any())
                {
                    Console.WriteLine("Không có đề tài nào thuộc lĩnh vực Lý thuyết và có thể triển khai thực tế.");
                    return;
                }

                Console.WriteLine("Danh sách đề tài thuộc lĩnh vực Lý thuyết và có thể triển khai thực tế:");
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║ Mã ĐT     │ Tên Đề Tài                │ Tên Giảng Viên          │ Tên Chủ Trì                  ║");
                Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════════════════╣");

                foreach (var dt in dsDeTai)
                {
                    string hoTenChuTri = sinhVienDtos.FirstOrDefault(sv => sv.DanhSachDeTai.Contains(dt))?.HoTen;
                    Console.WriteLine($"║ {dt.MaDeTai,-10}│ {dt.TenDeTai,-25} │ {dt.HoTenGiangVien,-25}│ {hoTenChuTri,-25}   ║");
                }

                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            }
        //case 10: Thành
        public void XuatDanhSachDeTaiCoCauHoiTren100()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Lọc ra các đề tài có số câu hỏi khảo sát lớn hơn 100
            var dsDeTai = sinhVienDtos.SelectMany(sv => sv.DanhSachDeTai).Where(dt => dt.GetTypeOfDeTai() == "Kinh tế" && ((DeTaiKinhTeDto)dt).SoCauHoiKhaoSat  > 100).ToList();

            if (!dsDeTai.Any())
            {
                Console.WriteLine("Không có đề tài nào có số câu hỏi khảo sát trên 100.");
                return;
            }

            // In ra danh sách các đề tài thỏa mãn điều kiện
            Console.WriteLine("Danh sách đề tài có số câu hỏi khảo sát trên 100:");
            Console.WriteLine("╔════════════╦════════════════════════════════╦═══════════════════════╦══════════════════════╦════════════════╗");
            Console.WriteLine("║ Mã Đề Tài  ║ Tên Đề Tài                     ║ Giảng Viên Hướng Dẫn  ║ Tên Chủ Trì          ║ Số Câu Hỏi     ║");
            Console.WriteLine("╠════════════╬════════════════════════════════╬═══════════════════════╬══════════════════════╬════════════════╣");

            foreach (var dt in dsDeTai)
            {
                string hoTenChuTri = sinhVienDtos.FirstOrDefault(sv => sv.DanhSachDeTai.Contains(dt))?.HoTen ?? "Không rõ";

                Console.WriteLine($"║ {dt.MaDeTai,-10} ║ {dt.TenDeTai,-30} ║ {dt.HoTenGiangVien,-20}  ║ {hoTenChuTri,-20} ║ {((DeTaiKinhTeDto)dt).SoCauHoiKhaoSat,-12}   ║");
            }

            Console.WriteLine("╚════════════╩════════════════════════════════╩═══════════════════════╩══════════════════════╩════════════════╝");
        }

        // case 11: Thành
        private int TinhSoNgay(DateTime thoiGianBatDau, DateTime thoiGianKetThuc)
        {
            return (thoiGianKetThuc - thoiGianBatDau).Days;
        }

        private double TinhSoThang(DateTime thoiGianBatDau, DateTime thoiGianKetThuc)
        {
            int soNgay = TinhSoNgay(thoiGianBatDau, thoiGianKetThuc);
            return soNgay / 30.0;
        }

        public void XuatDanhSachDeTaiThoiGianTren4Thang()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // Lọc ra các đề tài có thời gian thực hiện > 4 tháng
            var dsDeTai = sinhVienDtos
                .SelectMany(sv => sv.DanhSachDeTai)
                .Where(dt => TinhSoThang(dt.ThoiGianBatDau, dt.ThoiGianKetThuc) > 4)
                .ToList();

            if (!dsDeTai.Any())
            {
                Console.WriteLine("Không có đề tài nào có thời gian thực hiện trên 4 tháng.");
                return;
            }

            // In ra danh sách các đề tài thỏa mãn điều kiện
            Console.WriteLine("Danh sách đề tài có thời gian thực hiện trên 4 tháng:");
            Console.WriteLine("╔════════════╦════════════════════════════════╦═══════════════════════╦══════════════════════╦════════════════════╗");
            Console.WriteLine("║ Mã Đề Tài  ║ Tên Đề Tài                     ║ Giảng Viên Hướng Dẫn  ║ Tên Chủ Trì          ║ Thời Gian          ║");
            Console.WriteLine("╠════════════╬════════════════════════════════╬═══════════════════════╬══════════════════════╬════════════════════╣");

            foreach (var dt in dsDeTai)
            {
                string hoTenChuTri = sinhVienDtos.FirstOrDefault(sv => sv.DanhSachDeTai.Contains(dt))?.HoTen ?? "Không rõ";
                var thoiGianThucHien = TinhSoThang(dt.ThoiGianBatDau, dt.ThoiGianKetThuc);

                Console.WriteLine($"║ {dt.MaDeTai,-10} ║ {dt.TenDeTai,-30} ║ {dt.HoTenGiangVien,-20}  ║ {hoTenChuTri,-20} ║ {thoiGianThucHien,-12:F2} tháng ║");
            }

            Console.WriteLine("╚════════════╩════════════════════════════════╩═══════════════════════╩══════════════════════╩════════════════════╝");
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
