using DTO_QuanLyDeTaiNCKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO_QuanLyDeTaiNCKH.entity;
namespace DeTai1
{
    public class DeTaiKinhTeDto : DeTaiDto, IPhiHoTroNghienCuu
    {
        private int soCauHoiKhaoSat;
        public DeTaiKinhTeDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenGiangVien, int soCauHoiKhaoSat) : base(maDeTai, tenDeTai, thoiGianBatDau, thoiGianKetThuc, hoTenGiangVien)
        {
            SoCauHoiKhaoSat = soCauHoiKhaoSat;
        }

        public DeTaiKinhTeDto()
        {
        }

        public double TinhPhiHoTroNghienCuu()
        {
            if(soCauHoiKhaoSat > 100)
            {
                return soCauHoiKhaoSat * 550;
            }
            else
            {
                return soCauHoiKhaoSat * 450;
            }
        }

        public int SoCauHoiKhaoSat { 
            get => soCauHoiKhaoSat;
            set { 
                if(value < 0)
                    throw new Exception("Số câu hỏi không hợp lệ");
                soCauHoiKhaoSat = value; 
            }
        }


        public override double TinhKinhPhi()
        {

            double tinhPhiHoTro = TinhPhiHoTroNghienCuu();
            if (soCauHoiKhaoSat > 100)
                return kinhPhi = 12000000 - tinhPhiHoTro;
           return kinhPhi = 7000000 - tinhPhiHoTro;
        }
        public override string ToString()
        {
            return base.ToString() + $"{soCauHoiKhaoSat}";

        }

        public override string GetTypeOfDeTai()
        {
            return "Kinh tế";
        }

        public override void NhapThongTinDacThu()
        {
            do
            {
                Console.Write("Nhập số lượng câu hỏi khảo sát: ");
                string input = Console.ReadLine();
                try
                {
                    SoCauHoiKhaoSat = int.Parse(input);
                    if (SoCauHoiKhaoSat < 0)
                    {
                        throw new Exception("Số câu hỏi không hợp lệ! Vui lòng nhập lại.");
                    }
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Định dạng không đúng! Vui lòng nhập lại số nguyên.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
    }
}