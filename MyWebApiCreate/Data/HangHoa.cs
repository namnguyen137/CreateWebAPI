using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Data
{
    // Dinh nghia Entity
    [Table("HangHoa")]
    public class HangHoa
    {   [Key]
        public Guid MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHh { get; set; }
        public string MoTa { get; set; }
        [Range(0, double.MaxValue)]
        public string DonGia { get; set; }
        public int GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public IList<DonHangChiTiet> DonHangChiTiets { get; set; }
        public HangHoa()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }

    }
}
