using System;
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

        public DeTaiDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string hoTenSinhVien)
        {
            MaDeTai = maDeTai;
            TenDeTai = tenDeTai;
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
        }

        protected DeTaiDto(string maDeTai, string tenDeTai, DateTime thoiGianBatDau, DateTime thoiGianKetThuc)
        {
            this.maDeTai = maDeTai;
            this.tenDeTai = tenDeTai;
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
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

        public abstract double TinhKinhPhi();
        public override string ToString() => $"{maDeTai} {tenDeTai} {thoiGianBatDau} {thoiGianKetThuc}";
    }
}