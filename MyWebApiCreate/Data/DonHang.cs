using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Data
{
    public enum TinhTrangDonHang
    {
        New = 0, PayMent =1, Complete = 2, Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDh { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonHang TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DonHang()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>();
        }
    }
}
