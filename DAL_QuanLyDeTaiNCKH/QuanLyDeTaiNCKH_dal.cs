using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DeTai1;
using DTO_QuanLyDeTaiNCKH.entity;
namespace DAL_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_dal
    {
        private List<DeTaiDto> danhSachDeTai = new List<DeTaiDto>();

        public List<DeTaiDto> getDanhSachDeTai()
        {
            return danhSachDeTai;
        }

        public List<SinhVienDto> DocDeTaiNCKH(string fileName)
        {
            XmlDocument read = new XmlDocument();
            read.Load(fileName);

        }

        
    }
}
