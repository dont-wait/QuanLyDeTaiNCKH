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
                if(value.StartsWith("20") && value.Length == 10 && value.Substring(3).All(c => char.IsDigit(c)))
                    maSinhVien = value;
                throw new Exception("Mã sinh viên không hợp lệ");
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
        
        public string Lop { 
            get => lop; 
            set {
                if (char.IsDigit(value[0]) 
                    && char.IsDigit(value[1]) 
                    && value.Substring(2, 5).All(char.IsLetter) 
                    && value.Substring(6).All(c => char.IsDigit(c))
                    && value.Length == 8)
                    lop = value;
                throw new Exception("Lớp không hợp lệ");
            } 
        }
        public override string ToString() => $"{maSinhVien} {hoTen} {lop}";
        public List<DeTaiDto> DanhSachDeTai { get => danhSachDeTai; set => danhSachDeTai = value; }
        

    }

}
