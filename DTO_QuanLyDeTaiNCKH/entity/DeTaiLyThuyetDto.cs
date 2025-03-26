using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeTai1
{
    public class NghienCuuLyThuyet : DeTaiDto
    {
        private Boolean apDungThucTe;

        public NghienCuuLyThuyet(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien, string hoTenGiangVien, bool apDungThucTe)
     : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc, hoTenSinhVien, hoTenGiangVien)
        {
            this.apDungThucTe = apDungThucTe;
            this.kinhPhi = TinhToanKinhPhi();
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