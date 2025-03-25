using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_QuanLyDeTaiNCKH;

namespace GUI_QuanLyDeTaiNCKH
{
    public class QuanLyDeTaiNCKH_gui
    {
        private readonly QuanLyDeTaiNCKH_bll _quanLyDeTaiNCKH_bll;

        public QuanLyDeTaiNCKH_gui(QuanLyDeTaiNCKH_bll quanLyDeTaiNCKH_bll)
        {
            _quanLyDeTaiNCKH_bll = quanLyDeTaiNCKH_bll;
        }
    }
}
