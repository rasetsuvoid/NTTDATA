using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Coordinates : BaseEntity
    {
        
        [Column(TypeName = "decimal(9, 6)")]
        public required decimal Longitude { get; set; }

        
        [Column(TypeName = "decimal(9, 6)")]
        public required decimal Latitude { get; set; }
    }
}
