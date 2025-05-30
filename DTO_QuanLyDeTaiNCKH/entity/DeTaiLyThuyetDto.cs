﻿using System;
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
            ApDungThucTe = apDungThucTe;
        }
        
        public DeTaiLyThuyetDto()
        {
        }
        public bool ApDungThucTe { 
            get => apDungThucTe; 
            set { 
                if(value == true || value == false)
                    apDungThucTe = value;
                else
                    throw new Exception("Không hợp lệ");
            } }

        public override double TinhKinhPhi()
        {
            if (apDungThucTe)
                 kinhPhi = 15000000;
            else kinhPhi = 8000000;
            return kinhPhi;
        }

        public override string ToString()
        {
            return base.ToString() + $"{apDungThucTe}";
        }

        public override string GetTypeOfDeTai()
        {
            return "Lý thuyết";
        }

        public override void NhapThongTinDacThu()
        {
            do
            {
                Console.Write("Đề tài có áp dụng thực tế hay không? (Yes/No): ");
                string apDung = Console.ReadLine();
                try
                {
                    if (apDung.ToLower() == "yes")
                    {
                        ApDungThucTe = true;
                        break; 
                    }
                    else if (apDung.ToLower() == "no")
                    {
                        ApDungThucTe = false;
                        break; 
                    }
                    else
                    {
                        throw new Exception("Không hợp lệ! Vui lòng nhập lại (Yes/No).");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
        public bool danhdau()
        {
            return ApDungThucTe;
        }

    }
}