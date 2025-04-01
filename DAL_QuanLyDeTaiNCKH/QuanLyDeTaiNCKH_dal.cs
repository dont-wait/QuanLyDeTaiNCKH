using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DeTai1;
using DTO_QuanLyDeTaiNCKH.entity;
namespace DAL_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_dal
    {
        private Util util = new Util();
        private List<SinhVienDto> listSinhVien = new List<SinhVienDto>();

        public List<SinhVienDto> ListSinhVien 
        { get => listSinhVien; set => listSinhVien = value; }


        public void ThemDeTaiChoSinhVien(string maSinhVien)
        {
            Console.InputEncoding = Encoding.UTF8;

            // Tìm sinh viên theo mã
            SinhVienDto sinhVien = listSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);

            if (sinhVien != null)
            {
                // Nếu tìm thấy sinh viên, thêm đề tài
                Console.WriteLine($"Đã tìm thấy sinh viên {sinhVien.HoTen}. Nhập thông tin đề tài mới:");
                DeTaiDto deTai = AddDeTaiDTO();
                sinhVien.DanhSachDeTai.Add(deTai);
                Console.WriteLine("Đã thêm đề tài thành công!");
            }
            else
            {
                // Nếu không tìm thấy, thông báo hoặc xử lý tùy yêu cầu
                Console.WriteLine($"Không tìm thấy sinh viên với mã {maSinhVien}.");
                Console.Write("Bạn có muốn thêm sinh viên mới không? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    sinhVien = AddInfoSVDeTail();
                    listSinhVien.Add(sinhVien);
                    Console.WriteLine("Đã thêm sinh viên và đề tài thành công!");
                }
                else
                {
                    Console.WriteLine("Hủy thao tác thêm đề tài.");
                }
            }
        }

        public SinhVienDto AddInfoSVDeTail()
        {
            Console.InputEncoding = Encoding.UTF8;  

            SinhVienDto sinhVien = new SinhVienDto();
            Console.Write("Nhập mã sinh viên: ");
            sinhVien.MaSinhVien = Console.ReadLine();
            Console.Write("Nhập họ tên sinh viên: ");
            sinhVien.HoTen = Console.ReadLine();
            Console.Write("Nhập lớp: ");
            sinhVien.Lop = Console.ReadLine();
            Console.Write("Nhập số lượng đề tài: ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++) 
            {
                Console.WriteLine($"Nhập thông tin đề tài thứ #{i+1}");
                sinhVien.DanhSachDeTai.Add(AddDeTaiDTO());
            }
            return sinhVien;
        }

        private DeTaiDto AddDeTaiDTO()
        {
            Console.InputEncoding = Encoding.UTF8;
            DeTaiDto deTai = null;
            do
            {
                Console.Write("Nhập lĩnh vực của đề tài (CongNghe/KinhTe/LyThuyet): ");
                string typeNguyenCuu = Console.ReadLine();
                deTai = util.NewObjectByClassName(typeNguyenCuu);
                if (deTai == null)
                {
                    Console.WriteLine("Lĩnh vực không hợp lệ! Vui lòng nhập lại.");
                }
            } while (deTai == null);

            Console.Write("Nhập mã đề tài: ");
            deTai.MaDeTai = Console.ReadLine();
            Console.Write("Nhập tên đề tài: ");
            deTai.TenDeTai = Console.ReadLine();
            while (true)
            {
                Console.Write("Nhập thời gian bắt đầu (dd/MM/yyyy): ");
                string inputBatDau = Console.ReadLine();
                if (DateTime.TryParseExact(inputBatDau, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime thoiGianBatDau))
                {
                    deTai.ThoiGianBatDau = thoiGianBatDau;
                    break; // Thoát vòng lặp nếu nhập đúng
                }
                else
                {
                    Console.WriteLine("Định dạng không đúng! Vui lòng nhập lại theo kiểu dd/MM/yyyy (ví dụ: 25/12/2023).");
                }
            }

            // Nhập thời gian kết thúc với định dạng dd/MM/yyyy
            while (true)
            {
                Console.Write("Nhập thời gian kết thúc (dd/MM/yyyy): ");
                string inputKetThuc = Console.ReadLine();
                if (DateTime.TryParseExact(inputKetThuc, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime thoiGianKetThuc))
                {
                    deTai.ThoiGianKetThuc = thoiGianKetThuc;
                    break; // Thoát vòng lặp nếu nhập đúng
                }
                else
                {
                    Console.WriteLine("Định dạng không đúng! Vui lòng nhập lại theo kiểu dd/MM/yyyy (ví dụ: 30/12/2023).");
                }
            }
            deTai.NhapThongTinDacThu();
            Console.Write("Nhập tên giảng viên hướng dẫn: ");
            deTai.HoTenGiangVien = Console.ReadLine();

            return deTai;
        }

        public List<SinhVienDto> DocDeTaiNCKH(string fileName)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            XmlDocument read = new XmlDocument();
            read.Load(fileName);

            XmlNodeList sinhviens = read.SelectNodes("/DanhSachSinhVien/SinhVien");
            foreach (XmlNode sv in sinhviens)
            {
                SinhVienDto sinhvien = new SinhVienDto();
                sinhvien.MaSinhVien = sv["MaSinhVien"].InnerText;
                sinhvien.HoTen = sv["HoTen"].InnerText;
                sinhvien.Lop = sv["Lop"].InnerText;

                List<DeTaiDto> deTais = new List<DeTaiDto>();
                XmlNodeList detais = sv.SelectNodes("DeTai");
                foreach (XmlNode dt in detais)
                {
                    string typeNguyenCuu = dt.Attributes["linhVuc"].Value;
                    DeTaiDto deTai = util.NewObjectByClassName(typeNguyenCuu);

                    deTai.MaDeTai = dt["MaDeTai"].InnerText;
                    deTai.TenDeTai = dt["TenDeTai"].InnerText;
                    deTai.ThoiGianBatDau = DateTime.Parse(dt["ThoiGianBatDau"].InnerText);
                    deTai.ThoiGianKetThuc = DateTime.Parse(dt["ThoiGianKetThuc"].InnerText);
                    deTai.HoTenGiangVien = dt["TenGiangVien"].InnerText;

                    // Đọc thuộc tính riêng theo từng loại đề tài
                    if (typeNguyenCuu == "LyThuyet" && dt["ApDungThucTe"] != null)
                    {
                        ((DeTaiLyThuyetDto)deTai).ApDungThucTe = Boolean.Parse(dt["ApDungThucTe"].InnerText);
                    }
                    else if (typeNguyenCuu == "KinhTe" && dt["SoCauHoiKhaoSat"] != null)
                    {
                        ((DeTaiKinhTeDto)deTai).SoCauHoiKhaoSat = int.Parse(dt["SoCauHoiKhaoSat"].InnerText);
                    }
                    else if (typeNguyenCuu == "CongNghe" && dt["MoiTruong"] != null)
                    {
                        ((DeTaiCongNgheDto)deTai).MoiTruongThucHien = dt["MoiTruong"].InnerText;
                    }

                    deTais.Add(deTai);
                }

                sinhvien.DanhSachDeTai = deTais;
                listSinhVien.Add(sinhvien);
            }

            return listSinhVien;
        }
       


    }
}
