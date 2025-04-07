using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_QuanLyDeTaiNCKH;
using DTO_QuanLyDeTaiNCKH.entity;
namespace GUI_QuanLyDeTaiNCKHV2
{
    public class QuanLyDeTaiNCKH_guiV2
    {
        private readonly QuanLyDeTaiNCKH_bll _quanLyDeTaiNCKH_bll;
        public QuanLyDeTaiNCKH_guiV2()
        {
            _quanLyDeTaiNCKH_bll = new QuanLyDeTaiNCKH_bll();
        }

        public void HandleMenu()
        {
            while (true)
            {
                PrintMenu();
                Console.Write("Chọn 0...10: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _quanLyDeTaiNCKH_bll.readSinhVienInfoDetail();
                        Console.WriteLine("Đọc file thành côngg!");
                        break;
                    case 2:
                       _quanLyDeTaiNCKH_bll.AddNewDeTai();
                        break;
                    case 3:
                        _quanLyDeTaiNCKH_bll.XuatTTSinhVien();
                        break;
                    case 4:
                        _quanLyDeTaiNCKH_bll.TinhKinhPhiChoTatCaDeTai();
                        break;
                    case 5:
                        _quanLyDeTaiNCKH_bll.XuatDanhSachTimKiemDeTai();
                        break;
                    case 6:
                       _quanLyDeTaiNCKH_bll.XuatDanhSachTimKiemTheoGiangVien();
                        break;
                    case 7:
                        _quanLyDeTaiNCKH_bll.XuatDanhSachCacDeTaiDaDuocCapNhatKinhPhi();
                        break;
                    case 8:
                        _quanLyDeTaiNCKH_bll.XuatDanhSachDeTai_CoKinhPhiHon10Trieu();
                        break;
                    case 9:
                        _quanLyDeTaiNCKH_bll.XuatDanhSachDeTaiLyThuyetTrienKhai();
                        break;
                    case 10:
                        _quanLyDeTaiNCKH_bll.XuatDanhSachDeTaiCoCauHoiTren100();
                        break;
                    case 11:
                        _quanLyDeTaiNCKH_bll.XuatDanhSachDeTaiThoiGianTren4Thang();
                        break;
                    case 0:
                        Console.WriteLine("Have a gud day");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }
        private void PrintMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              CHƯƠNG TRÌNH QUẢN LÝ ĐỀ TÀI                   ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1.   Đọc danh sách các đề tài từ file XML                  ║");
            Console.WriteLine("║ 2.   Thêm mới 1 đề tài từ bàn phím                         ║");
            Console.WriteLine("║ 3.   Xuất danh sách các đề tài                             ║");
            Console.WriteLine("║ 4.   Tính kinh phí                                         ║");
            Console.WriteLine("║ 5.   Tìm kiếm đề tài theo tên/mã số/người hướng dẫn        ║");
            Console.WriteLine("║ 6.   Xuất danh sách đề tài theo giảng viên hướng dẫn       ║");
            Console.WriteLine("║ 7.   Cập nhật kinh phí đề tài tăng 10%                     ║");
            Console.WriteLine("║ 8.   Xuất danh sách đề tài có kinh phí trên 10 triệu       ║");
            Console.WriteLine("║ 9.   Xuất danh sách các đề tài thuộc lĩnh vực nghiên cứu   ║");
            Console.WriteLine("║      lý thuyết và có khả năng triển khai vào thực tế.      ║");
            Console.WriteLine("║ 10.   danh sách đề tài có số câu hỏi khảo sát trên 100 câu.║");
            Console.WriteLine("║ 11.  danh sách đề tài có thời gian thực hiện trên 4 tháng. ║");
            Console.WriteLine("║ 0.   Thoát                                                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.Write("Chọn một tùy chọn: ");
        }
    }
}
