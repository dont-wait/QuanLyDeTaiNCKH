using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QuanLyDeTaiNCKH.entity
{
    public class DeTaiLyThuyetDto : DeTaiDto
    {
        private Boolean apDungThucTe;

        public DeTaiLyThuyetDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenGiangVien, Boolean apDungThucTe) : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc, hoTenGiangVien)
        {
            this.apDungThucTe = apDungThucTe;
        }
        
        public DeTaiLyThuyetDto()
        {
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