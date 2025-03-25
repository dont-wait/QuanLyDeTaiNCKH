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


        public DeTaiKinhTeDto() { }
        public DeTaiKinhTeDto(string maDeTai, string tenDeTai, int soCauHoiKhaoSat) : base(maDeTai, tenDeTai)
        {
            this.soCauHoiKhaoSat = soCauHoiKhaoSat;
        }

        public override double TinhToanKinhPhi()
        {
            return 0;
        }
        public double TinhPhiNghienCuu()
        {
            throw new NotImplementedException();
        }
    }
}