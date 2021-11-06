using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }

    public class DonHang
    {
        public Guid MaDh { get; set; }
        public DateTime NgatDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
