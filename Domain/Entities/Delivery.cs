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
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        [ForeignKey("Provision")]
        public int ProvisionId { get; set; }
        public Provision Provision { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal OriginLongitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal OriginLatitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal DestinationLongitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal DestinationLatitude { get; set; }

        public int EstimatedTime { get; set; }

        public int DeliveredQuantity { get; set; }
    }
}
