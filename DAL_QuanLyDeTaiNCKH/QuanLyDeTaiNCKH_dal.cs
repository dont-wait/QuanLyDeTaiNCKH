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


        //public DeTaiDto AddDeTaiDTO()
        //{
        //    Console.InputEncoding = Encoding.UTF8;
        //    Console.Write("Nhập lĩnh vực của đề tài: ");
        //    string typeNguyenCuu = Console.ReadLine();
        //    DeTaiDto deTai = util.NewObjectByClassName(typeNguyenCuu);
        //    Console.Write("Nhập mã đề tài: ");
        //    deTai.MaDeTai = Console.ReadLine();
        //    Console.Write("Nhập tên đề tài: ");
        //    deTai.TenDeTai = Console.ReadLine();
        //    Console.Write("Nhập thời gian bắt đầu: ");
        //    deTai.ThoiGianBatDau = DateTime.Parse(Console.ReadLine());
        //    Console.Write("Nhập thời gian kết thúc: ");
        //    deTai.ThoiGianKetThuc = DateTime.Parse(Console.ReadLine());

        //    return deTai;
        //}

        public List<SinhVienDto> DocDeTaiNCKH(string fileName)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            XmlDocument read = new XmlDocument();
            read.Load(fileName);

            XmlNodeList sinhviens = read.SelectNodes("/DanhSachSinhVien/SinhVien");
            foreach(XmlNode sv in sinhviens)
            {
                SinhVienDto sinhvien = new SinhVienDto();
                sinhvien.MaSinhVien = sv["MaSinhVien"].InnerText;
                sinhvien.HoTen = sv["HoTen"].InnerText;
                sinhvien.Lop = sv["Lop"].InnerText;
                List<DeTaiDto> deTais = new List<DeTaiDto>();
                
                XmlNodeList detais = sv.SelectNodes("DeTai");
                foreach(XmlNode dt in detais)
                {
                    string typeNguyenCuu = dt.Attributes["linhVuc"].Value;
                    DeTaiDto deTai = util.NewObjectByClassName(typeNguyenCuu);
                    deTai.MaDeTai = dt["MaDeTai"].InnerText;                 
                    deTai.TenDeTai = dt["TenDeTai"] .InnerText;
                    
                    deTai.ThoiGianBatDau = DateTime.Parse(dt["ThoiGianBatDau"].InnerText);
                    deTai.ThoiGianKetThuc = DateTime.Parse(dt["ThoiGianKetThuc"].InnerText);
                    deTai.HoTenGiangVien = dt["TenGiangVien"].InnerText;
                    deTais.Add(deTai);
                }
                sinhvien.DanhSachDeTai = deTais;
                listSinhVien.Add(sinhvien);
            }

            return listSinhVien;
        }

    }
}
