using DeTai1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyDeTaiNCKH.entity
{
    public class SinhVienDto
    {
        private string maSinhVien;
        private string hoTen;
        private string lop;
        private List<DeTaiDto> danhSachDeTai;
        public SinhVienDto()
        {
            danhSachDeTai = new List<DeTaiDto>();
        } 

        public SinhVienDto(string maSinhVien, string hoTen, string lop)
        {
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
            Lop = lop;
        }

        public string MaSinhVien { 
            get => maSinhVien;
            set {
                if (value.Length == 10 && value.All(c => Char.IsDigit(c)))
                    maSinhVien = value;
                else
                    throw new Exception("Mã sinh viên phải đủ 10 kí tự và là số");
            }
        }
        public string HoTen {
            get => hoTen;
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new Exception("Họ tên không hợp lệ");
                hoTen = value;
            } 
        }

        public string Lop
        {
            get => lop;
            set
            {
                if (value.Length == 8 &&
                    char.IsDigit(value[0]) && char.IsDigit(value[1]) &&
                    value.Substring(2, 4).All(char.IsLetter) &&
                    char.IsDigit(value[6]) && char.IsDigit(value[7]))
                {
                    lop = value;
                }
                else
                {
                    throw new Exception("Lớp không hợp lệ | Ví dụ: 14DHTH11");
                }
            }
        }

        public override string ToString()
        {
            if (DanhSachDeTai == null || DanhSachDeTai.Count == 0)
            {
                return $"│ {MaSinhVien.PadRight(11)}│ {HoTen.PadRight(21)}│ {Lop.PadRight(11)}│ {"Không có đề tài nào trong danh sách này.".PadRight(120)}│";
            }

            string firstLine = $"│ {MaSinhVien.PadRight(11)}│ {HoTen.PadRight(21)}│ {Lop.PadRight(11)}│ {DanhSachDeTai[0].MaDeTai.PadRight(6)}{DanhSachDeTai[0].TenDeTai.PadRight(37)}{DanhSachDeTai[0].GetTypeOfDeTai().PadRight(12)}{DanhSachDeTai[0].ThoiGianBatDau:dd/MM/yyyy} {DanhSachDeTai[0].ThoiGianKetThuc:dd/MM/yyyy} {DanhSachDeTai[0].HoTenGiangVien.PadRight(20)}{DanhSachDeTai[0].TinhKinhPhi(),15:N2}│";

            if (DanhSachDeTai.Count == 1)
            {
                return firstLine;
            }

            var additionalLines = DanhSachDeTai.Skip(1).Select(dt =>
                $"│ {"".PadRight(11)}│ {"".PadRight(21)}│ {"".PadRight(11)}│ {dt.MaDeTai.PadRight(6)}{dt.TenDeTai.PadRight(37)}{dt.GetTypeOfDeTai().PadRight(12)}{dt.ThoiGianBatDau:dd/MM/yyyy} {dt.ThoiGianKetThuc:dd/MM/yyyy} {dt.HoTenGiangVien.PadRight(20)}{dt.TinhKinhPhi(),15:N2}│");

            return firstLine + "\n" + string.Join("\n", additionalLines);
        }

        public List<DeTaiDto> DanhSachDeTai { get => danhSachDeTai; set => danhSachDeTai = value; }
        

    }

}
