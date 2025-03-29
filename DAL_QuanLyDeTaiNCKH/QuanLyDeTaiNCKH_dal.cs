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
        private Util util = new Util();
        private List<SinhVienDto> listSinhVien = new List<SinhVienDto>();

        public List<SinhVienDto> ListSinhVien 
        { get => listSinhVien; set => listSinhVien = value; }


        public List<SinhVienDto> DocDeTaiNCKH(string fileName)
        {
           
            XmlDocument read = new XmlDocument();
            read.Load(fileName);

            XmlNodeList sinhviens = read.SelectNodes("/DanhSachSinhVien/SinhVien");
            foreach(XmlNode sv in sinhviens)
            {
                SinhVienDto sinhvien = new SinhVienDto();
                sinhvien.MaSinhVien = sv.SelectSingleNode("MaSinhVien").InnerText;
                sinhvien.HoTen = sv.SelectSingleNode("HoTen").InnerText;
                sinhvien.Lop = sv.SelectSingleNode("Lop").InnerText;
                List<DeTaiDto> deTais = new List<DeTaiDto>();
                
                XmlNodeList detais = sv.SelectNodes("DeTai");
                foreach(XmlNode dt in detais)
                {
                    string typeNguyenCuu = dt.Attributes["linhVuc"].Value;
                    DeTaiDto deTai = util.NewObjectByClassName(typeNguyenCuu);
                    deTai.MaDeTai = dt.SelectSingleNode("MaDeTai").InnerText;
                    deTai.TenDeTai = dt.SelectSingleNode("TenDeTai").InnerText;
                    deTai.HoTenGiangVien = dt.SelectSingleNode("TenGiangVien").InnerText;
                    deTai.ThoiGianBatDau = DateTime.Parse(dt.SelectSingleNode("ThoiGianBatDau").InnerText);
                    deTai.ThoiGianKetThuc = DateTime.Parse(dt.SelectSingleNode("ThoiGianKetThuc").InnerText);
                    
                }
                listSinhVien.Add(sinhvien);
            }

            return listSinhVien;
        }

        public void XuatTTSinhVien()
        {
            foreach(SinhVienDto sv in listSinhVien)
            {
                sv.ToString();
            }
        }






    }
}
