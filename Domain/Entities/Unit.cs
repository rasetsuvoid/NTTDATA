using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Unit : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Rank { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Longitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Latitude { get; set; }
    }
}
