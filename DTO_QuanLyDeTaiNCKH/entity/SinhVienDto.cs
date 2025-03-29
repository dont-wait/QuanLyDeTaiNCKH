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
            new List<DeTaiDto>();
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
               maSinhVien = value;
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
                    throw new Exception("Lớp không hợp lệ");
                }
            }
        }
        public override string ToString()
        {
            string deTaiStr = DanhSachDeTai != null && DanhSachDeTai.Count > 0
                ? string.Join("\n  ", DanhSachDeTai.Select(dt => $"- {dt.TenDeTai} ({dt.MaDeTai})\n    GVHD: {dt.HoTenGiangVien}\n    Thời gian: {dt.ThoiGianBatDau:yyyy-MM-dd} - {dt.ThoiGianKetThuc:yyyy-MM-dd}"))
                : "Không có đề tài nào.";

            return $"Mã SV: {MaSinhVien}\nHọ Tên: {HoTen}\nLớp: {Lop}\nĐề tài:\n  {deTaiStr}";
        }

        public List<DeTaiDto> DanhSachDeTai { get => danhSachDeTai; set => danhSachDeTai = value; }
        

    }

}
