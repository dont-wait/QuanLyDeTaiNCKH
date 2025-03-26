using DTO_QuanLyDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DeTai1
{
    public class DeTaiKinhTeDto : DeTaiDto, IPhiNghienCuu
    {
        private int soCauHoiKhaoSat;
        public DeTaiKinhTeDto(string maDeTai, string tenDeTai, double kinhPhi, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien, string hoTenGiangVien, int soCauHoiKhaoSat)
        : base(maDeTai, tenDeTai, kinhPhi, thoiGianBatDau, thoiGianKetThuc, hoTenSinhVien, hoTenGiangVien)
        {
            this.soCauHoiKhaoSat = soCauHoiKhaoSat;
        }

        public override double TinhToanKinhPhi()
        {
            if(soCauHoiKhaoSat > 100)
            {
                kinhPhi = 12000000;
            }    
            else
            {
                kinhPhi = 7000000;
            }    
            return kinhPhi;
        }
        public double TinhPhiNghienCuu()
        {
            if(soCauHoiKhaoSat > 100)
            {
                return soCauHoiKhaoSat * 550;
            }
            else
            {
                return soCauHoiKhaoSat * 450;
            }
        }
    }
}