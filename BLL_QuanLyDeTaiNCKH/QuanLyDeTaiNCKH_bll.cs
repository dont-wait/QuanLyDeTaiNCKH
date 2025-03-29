using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyDeTaiNCKH;
using DTO_QuanLyDeTaiNCKH.entity;
namespace BLL_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_bll
    {
        private QuanLyDeTaiNCKH_dal dal = new QuanLyDeTaiNCKH_dal();
        private List<DeTaiDto> danhSachDeTai;// danh sách các đề tài nghiên cứu khoa học.
        public QuanLyDeTaiNCKH_bll()
        {
           
        }
        public List<DeTaiDto> timKiemDeTai(string tuKhoa)
        {
            return danhSachDeTai.Where(dt => dt.MaDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 || dt.TenDeTai.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 || dt.HoTenGiangVien.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        public List<DeTaiDto> timKiemDeTaiTheoGiangVien(string tenGiangVien)
        {
            return danhSachDeTai.Where(dt => dt.HoTenGiangVien.IndexOf(tenGiangVien, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void capNhatVaXuatKinhPhi()
        {
            foreach (var dt in danhSachDeTai)
            {
                double kinhPhiMoi = dt.TinhKinhPhi() + (dt.TinhKinhPhi() * 0.1); // Tăng 10%
                Console.WriteLine(dt);
            }
        }

        public List<SinhVienDto> getSinhVienInfoDetail()
        {
            return dal.DocDeTaiNCKH("E:\\project\\QuanLyDeTaiNCKH\\DTO_QuanLyDeTaiNCKH\\Data.xml");
        }
        public void XuatTTSinhVien()
        {
            dal.XuatTTSinhVien();
        }
    }
}
