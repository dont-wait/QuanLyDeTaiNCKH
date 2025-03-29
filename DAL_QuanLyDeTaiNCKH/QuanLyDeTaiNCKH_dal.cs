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
        public List<SinhVienDto> DocDeTaiNCKH(string fileName)
        {
            List<SinhVienDto> listSinhVien = new List<SinhVienDto>();
            XmlDocument read = new XmlDocument();
            read.Load(fileName);

            XmlNodeList sinhviens = read.SelectNodes("DanhSachSinhVien/SinhVien");


            return null;
        }






    }
}
