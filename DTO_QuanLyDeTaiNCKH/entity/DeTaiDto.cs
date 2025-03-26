using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeTai1
{
    public abstract class DeTaiDto
    {
        protected string maDeTai;   
        protected string tenDeTai;
        protected double kinhPhi;
        protected DateTime thoiGianBatDau;
        protected DateTime thoiGianKetThuc;
        protected string hoTenSinhVien;
        protected string hoTenGiangVien;

        protected DeTaiDto(string maDeTai, string tenDeTai, double kinhPhi, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien, string hoTenGiangVien)
        {
            this.maDeTai = maDeTai;
            this.tenDeTai = tenDeTai;
            this.kinhPhi = kinhPhi;
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
            this.hoTenSinhVien = hoTenSinhVien;
            this.hoTenGiangVien = hoTenGiangVien;
        }

        public abstract double TinhToanKinhPhi();
    }
}