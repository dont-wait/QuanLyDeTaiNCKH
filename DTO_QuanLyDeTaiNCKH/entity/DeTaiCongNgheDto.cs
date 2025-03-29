using DTO_QuanLyDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QuanLyDeTaiNCKH.entity
{
    public class DeTaiCongNgheDto : DeTaiDto, IPhiHoTroNghienCuu
    {
        private string moiTruongThucHien;

        public DeTaiCongNgheDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string moiTruongThucHien) : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc)
        {
            this.moiTruongThucHien = moiTruongThucHien;
        }


        public double TinhPhiHoTroNghienCuu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (moiTruongThucHien.ToLower() == "mobie")
                return 1000000;
            else if (moiTruongThucHien.ToLower() == "web")
                return 800000;
            else if (moiTruongThucHien.ToLower() == "window")
                return 500000;
            else
                throw new Exception("Môi trường không hợp lệ!!!");
        }

        public override double TinhKinhPhi()
        {
            double kinhPhi = 0;
            if (moiTruongThucHien.ToLower() == "mobile" || moiTruongThucHien.ToLower() == "web")
                kinhPhi = 15000000;
            else if (moiTruongThucHien.ToLower() == "window")
                kinhPhi = 10000000;
            else
                throw new ArgumentException("Môi trường không hợp lệ");
            return kinhPhi - TinhPhiHoTroNghienCuu();
        }

        public override string ToString()
        {
            return base.ToString() + $"{moiTruongThucHien}";
        }
    }
}