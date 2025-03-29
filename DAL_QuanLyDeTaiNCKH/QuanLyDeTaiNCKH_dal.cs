using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeTai1;
using DTO_QuanLyDeTaiNCKH;

namespace DAL_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_dal : IDALRepository
    {
        private List<DeTaiDto> danhSachDeTai = new List<DeTaiDto>();

        public List<DeTaiDto> getDanhSachDeTai()
        {
            return danhSachDeTai;
        }

        public void DocDeTaiNCKH(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
