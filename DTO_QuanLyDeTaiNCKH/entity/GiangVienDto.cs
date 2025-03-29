using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyDeTaiNCKH.entity
{
    public class GiangVienDto
    {
        private string maGiangVien;
        private string hoTen;

        public GiangVienDto() { }
        public GiangVienDto(string maGiangVien, string hoTen) {
            MaGiangVien = maGiangVien;
            HoTen = hoTen;
        }
        public string MaGiangVien
        {
            get => maGiangVien;
            set
            {
                if (value.StartsWith("GV") && value.Length == 8 && value.Substring(2).All(c => char.IsDigit(c)))
                    maGiangVien = value;
                throw new Exception("Mã giảng viên không hợp lệ");
            }
        }

        public string HoTen
        {
            get => hoTen;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new Exception("Họ tên không hợp lệ");
                hoTen = value;
            }
        }
        public override string ToString() => $"{maGiangVien} {hoTen}";
    }
}
