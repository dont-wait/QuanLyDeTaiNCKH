﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_QuanLyDeTaiNCKH;
using DTO_QuanLyDeTaiNCKH.entity;
namespace GUI_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_gui
    {
        private readonly QuanLyDeTaiNCKH_bll _quanLyDeTaiNCKH_bll;

        public QuanLyDeTaiNCKH_gui()
        {
        }

        public void ShowSinhVienInfoDetail()
        {
            List<SinhVienDto> listSinhVien =  _quanLyDeTaiNCKH_bll.getSinhVienInfoDetail();
        }
    }
}
