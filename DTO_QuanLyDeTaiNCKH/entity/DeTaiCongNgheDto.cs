using DTO_QuanLyDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeTai1
{
    public class DeTaiCongNgheDto : DeTaiDto, IPhiHoTroNghienCuu    
    {
        private string moiTruongThucHien;

        public DeTaiCongNgheDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien, string hoTenGiangVien, string moiTruongThucHien)
       : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc, hoTenSinhVien, hoTenGiangVien)
        {
            this.moiTruongThucHien = moiTruongThucHien;
            this.kinhPhi = TinhToanKinhPhi();
        }

        public double TinhPhiHoTroNghienCuu()
        {
            if (moiTruongThucHien.ToLower() == "mobie")
            {
                return 1000000;
            }
            else if (moiTruongThucHien.ToLower() == "web")
            {
                return 800000;
            }
            else if (moiTruongThucHien.ToLower() == "window")
            {
                return 500000;
            }
            else
            {
                throw new Exception("Moi Truong khong hop le!!!");
            }
        }

      

        public override double TinhToanKinhPhi()
        {
            if(moiTruongThucHien.ToLower() == "mobile" || moiTruongThucHien.ToLower() == "web")
            {
                kinhPhi = 15000000;
            }
            else if (moiTruongThucHien.ToLower() == "window")
            {
                kinhPhi = 10000000; 
            }
            else
            {
                throw new ArgumentException("moi truong khong hop le.");
            }

            return kinhPhi - TinhPhiHoTroNghienCuu();
        }
    }
}