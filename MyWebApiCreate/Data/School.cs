using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiCreate.Data
{
    [Table("School")]
    public class School
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
