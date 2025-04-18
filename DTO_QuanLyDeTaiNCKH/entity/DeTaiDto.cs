﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;


namespace DTO_QuanLyDeTaiNCKH.entity
{
    public abstract class DeTaiDto
    {
        protected string maDeTai;   
        protected string tenDeTai;
        protected DateTime thoiGianBatDau;
        protected DateTime thoiGianKetThuc;
        protected string hoTenGiangVien;
        protected double kinhPhi;

        public DeTaiDto() { }

        protected DeTaiDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenGiangVien)
        {
            MaDeTai = maDeTai;
            TenDeTai = tenDeTai;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianKetThuc = thoiGianKetThuc;
            HoTenGiangVien = hoTenGiangVien;
           
        }

        public double KinhPhi
        {
            get { return kinhPhi; }
            set {
               
                kinhPhi = value;
            }
        }

       public DateTime ThoiGianBatDau
       {
            get { return thoiGianBatDau; }
            set
            {
                if (value.Year < 2023) 
                {
                    throw new Exception("Thời gian phải bắt đầu từ 2023!");
                }
                else
                {
                    thoiGianBatDau = value;
                }
            }
       }

    public DateTime ThoiGianKetThuc
    {
        get { return thoiGianKetThuc; }
        set
        {
            if (value <= thoiGianBatDau) 
            {
                throw new Exception("Thời gian kết thúc phải sau thời gian bắt đầu!");
            }
            else
            {
                thoiGianKetThuc = value;
            }
        }
    }

        public string HoTenGiangVien
        {
            get { return hoTenGiangVien; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Khong Hop Le!");
                }
                else
                {
                    hoTenGiangVien = value;
                }
            }
        }

        public string MaDeTai
        {
            get { return maDeTai; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Khong Hop Le!");
                }
                else
                {
                    maDeTai = value;
                }
            }
        } 
             
        public string TenDeTai
        {
            get { return tenDeTai; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Khong Hop Le!");
                }
                else
                {
                    tenDeTai = value;
                }    
            }
        }

        public abstract string GetTypeOfDeTai();
        public abstract void NhapThongTinDacThu();

        public abstract double TinhKinhPhi();
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-20} | {2,-20} | {3,-15:dd/MM/yyyy} | {4,-15:dd/MM/yyyy} | {5, 10:N2} |",
                maDeTai, tenDeTai, GetTypeOfDeTai(),hoTenGiangVien, thoiGianBatDau, thoiGianKetThuc, kinhPhi);
        }

        public static string GetTableHeader()
        {
            return string.Format("| {0,-10} | {1,-30} | {2,-20} | {3,-15} | {4,-15} | {5,-20} | {6,15} |",
                "MaDeTai", "TenDeTai", "LoaiDeTai", "ThoiGianBatDau", "ThoiGianKetThuc", "HoTenGiangVien", "KinhPhi");
        }
    }
}