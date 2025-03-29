using DTO_QuanLyDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DeTai1
{
    public class DeTaiKinhTeDto : DeTaiDto, IPhiHoTroNghienCuu
    {
        private int soCauHoiKhaoSat;
        public DeTaiKinhTeDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int soCauHoiKhaoSat) : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc)
        {
            this.soCauHoiKhaoSat = soCauHoiKhaoSat;
        }

        public double TinhPhiHoTroNghienCuu()
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


        public override double TinhKinhPhi()
        {
            double tinhPhiHoTro = TinhPhiHoTroNghienCuu();
            if (soCauHoiKhaoSat > 100)
                return 12000000 - tinhPhiHoTro;
           return 7000000 - tinhPhiHoTro;
        }
        public override string ToString()
        {
            return base.ToString() + $"{soCauHoiKhaoSat}";

        }
    }
}