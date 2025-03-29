using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeTai1;
using DTO_QuanLyDeTaiNCKH.entity;
namespace DAL_QuanLyDeTaiNCKH
{
    class Util
    {
        public DeTaiDto NewObjectByClassName(string linhVuc) {

            switch (linhVuc)
            {
                case "CongNghe":
                    return new DeTaiCongNgheDto();
                case "KinhTe":
                    return new DeTaiKinhTeDto();
                case "LyThuyet":
                    return new DeTaiLyThuyetDto();
                default:
                    throw new Exception("Lĩnh vực đề tài không hợp lệ!");
            }
        }

        
    }
}
