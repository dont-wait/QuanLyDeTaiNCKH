using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeTai1
{
    public class NghienCuuLyThuyet : DeTaiDto
    {
        private Boolean apDungThucTe;

        public NghienCuuLyThuyet(string maDeTai, string tenDeTai, double kinhPhi, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien, string hoTenGiangVien, bool apDungThucTe)
     : base(maDeTai, tenDeTai, kinhPhi, thoiGianBatDau, thoiGianKetThuc, hoTenSinhVien, hoTenGiangVien)
        {
            this.apDungThucTe = apDungThucTe;
        }
        public override double TinhToanKinhPhi()
        {
            if (apDungThucTe)
            {
                return 15000000;
            }
            else
            {
                return 8000000;
            }
        }
    }
}