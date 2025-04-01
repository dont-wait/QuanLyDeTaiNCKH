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

        public DeTaiCongNgheDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenGiangVien, string moiTruongThucHien) : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc, hoTenGiangVien)
        {
            MoiTruongThucHien = moiTruongThucHien;
        }

        public DeTaiCongNgheDto()
        {
        }

        public string MoiTruongThucHien { 
            get => moiTruongThucHien;
            set
            {
                if(value.Equals("mobile") || value.Equals("web") || value.Equals("window"))
                    moiTruongThucHien = value;
                else
                    throw new Exception("Môi trường không hợp lệ");
            }
        }

        public double TinhPhiHoTroNghienCuu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (moiTruongThucHien.ToLower() == "mobile")
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
            kinhPhi = 0;
            if (moiTruongThucHien.ToLower() == "mobile" || moiTruongThucHien.ToLower() == "web")
                kinhPhi = 15000000;
            else if (moiTruongThucHien.ToLower() == "window")
                kinhPhi = 10000000;
            else
                throw new ArgumentException("Môi trường không hợp lệ");
            kinhPhi -= TinhPhiHoTroNghienCuu();
            return kinhPhi;
        }

        public override string ToString()
        {
            return base.ToString() + $"{moiTruongThucHien}";
        }

        public override string GetTypeOfDeTai()
        {
            return "Công nghệ";
        }

        public override void NhapThongTinDacThu()
        {
            do
            {
                Console.Write("Nhập môi trường thực hiện (mobile, window, web): ");
                string input = Console.ReadLine();
                try
                {
                    MoiTruongThucHien = input;
                    break; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
    }
}