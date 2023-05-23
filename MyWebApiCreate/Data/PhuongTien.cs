using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Data
{
    [Table("PhuongTien")]
    public class PhuongTien
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Buy_Date { get; set; }
        public string Buy_Name { get; set; }
    }
}
