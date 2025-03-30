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
                Console.Write("Chọn 0...7: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear(); 

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
                        //SearchDeTai();
                        break;
                    case 5:
                       _quanLyDeTaiNCKH_bll.XuatDanhSachTimKiemTheoGiangVien();
                        break;
                    case 6:
                        //UpdateKinhPhi();
                        break;
                    case 7:
                        //ExportDeTaiAbove10Trieu();
                        break;
                    case 8:
                        _quanLyDeTaiNCKH_bll.GetSecret();
                        break;
                    case 0:
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
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║              CHƯƠNG TRÌNH QUẢN LÝ ĐỀ TÀI           ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Đọc danh sách các đề tài từ file XML            ║");
            Console.WriteLine("║ 2. Thêm mới 1 đề tài từ bàn phím                   ║");
            Console.WriteLine("║ 3. Xuất danh sách các đề tài                       ║");
            Console.WriteLine("║ 4. Tìm kiếm đề tài theo tên/mã số/người hướng dẫn  ║");
            Console.WriteLine("║ 5. Xuất danh sách đề tài theo giảng viên hướng dẫn ║");
            Console.WriteLine("║ 6. Cập nhật kinh phí đề tài tăng 10%               ║");
            Console.WriteLine("║ 7. Xuất danh sách đề tài có kinh phí trên 10 triệu ║");
            Console.WriteLine("║ 8. Secret                                          ║");
            Console.WriteLine("║ 0. Thoát                                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.Write("Chọn một tùy chọn: ");
        }
    }
}
