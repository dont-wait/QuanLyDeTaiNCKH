using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;


namespace DeTai1
{
    public abstract class DeTaiDto
    {
        protected string maDeTai;   
        protected string tenDeTai;
        protected double kinhPhi;
        protected DateTime thoiGianBatDau;
        protected DateTime thoiGianKetThuc;
        protected string hoTenSinhVien;
        protected string hoTenGiangVien;

        protected DeTaiDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien, string hoTenGiangVien)
        {
            this.MaDeTai = maDeTai;
            this.TenDeTai = tenDeTai;
            this.kinhPhi = TinhToanKinhPhi();
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
            this.HoTenSinhVien = hoTenSinhVien;
            this.HoTenGiangVien = hoTenGiangVien;
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

        public string HoTenSinhVien
        {
            get { return
                    hoTenSinhVien; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Khong Hop Le!");
                }
                else
                {
                    hoTenSinhVien = value;
                }
            }
        }

        public string HoTenGiangVien
        {
            get
            {
                return
                    hoTenGiangVien;
            }
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

        public double KinhPhi
        {
            get
            {
                return
                    kinhPhi;
            }
            set
            {
                kinhPhi = value;
            }
        }

        public abstract double TinhToanKinhPhi();
    }
}