using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Delivery : BaseEntity
    {
        
        [ForeignKey("Coordinates")]
        public required int CoordinatesId { get; set; }

        public virtual Coordinates Coordinates { get; set; }

        
        [Column(TypeName = "decimal(9, 6)")]
        public required decimal DestinationLongitude { get; set; }

        [Column(TypeName = "decimal(9, 6)")]
        public required decimal DestinationLatitude { get; set; }

        public required DateTime DeliveryDate { get; set; }

        public TimeSpan EstimatedTime { get; set; }

        public int DeliveredQuantity { get; set; }

    }
}
