using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_QuanLyDeTaiNCKH;
using DTO_QuanLyDeTaiNCKH.entity;
namespace GUI_QuanLyDeTaiNCKHV2
{
    public class QuanLyDeTaiNCKH_guiV2
    {
        private readonly QuanLyDeTaiNCKH_bll _quanLyDeTaiNCKH_bll;

        public QuanLyDeTaiNCKH_guiV2()
        {
        }

        public void ShowSinhVienInfoDetail()
        {
            List<SinhVienDto> listSinhVien =  _quanLyDeTaiNCKH_bll.getSinhVienInfoDetail();
            foreach(SinhVienDto sv in listSinhVien)
            {
                sv.ToString();
            }
        }
    }
}
