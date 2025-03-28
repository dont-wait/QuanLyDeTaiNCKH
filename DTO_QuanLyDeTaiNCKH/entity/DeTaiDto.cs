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

        public DeTaiDto() { }

        protected DeTaiDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenGiangVien)
        {
            MaDeTai = maDeTai;
            TenDeTai = tenDeTai;
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
            HoTenGiangVien = hoTenGiangVien;
        }

       public DateTime ThoiGianBatDau
        {
            get { return thoiGianBatDau; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Khong Hop Le!");
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
                if (value == null)
                {
                    throw new Exception("Khong Hop Le!");
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

        public abstract double TinhKinhPhi();
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-20} | {2,-20} | {3,-15:dd/MM/yyyy} | {4,-15:dd/MM/yyyy} | {5,10:N2} |",
                maDeTai, tenDeTai, GetTypeOfDeTai(),hoTenGiangVien, thoiGianBatDau, thoiGianKetThuc, TinhKinhPhi());
        }

        public static string GetTableHeader()
        {
            return string.Format("| {0,-10} | {1,-20} | {2,-20} | {3,-15} | {4,-15} | {5,10} |",
                "MaDeTai", "TenDeTai", "HoTenGiangVien", "ThoiGianBatDau", "ThoiGianKetThuc", "KinhPhi");
        }
    }
}