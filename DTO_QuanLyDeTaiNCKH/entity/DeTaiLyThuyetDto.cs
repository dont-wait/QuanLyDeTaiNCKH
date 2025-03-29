using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QuanLyDeTaiNCKH.entity
{
    public class NghienCuuLyThuyet : DeTaiDto
    {
        private Boolean apDungThucTe;

        public NghienCuuLyThuyet(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, bool apDungThucTe)
     : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc)
        {
            this.apDungThucTe = apDungThucTe;
        }

        public override double TinhKinhPhi()
        {
            if (apDungThucTe)
                return 15000000;
            return 8000000;
        }

        public override string ToString()
        {
            return base.ToString() + $"{apDungThucTe}";
        }
    }
}