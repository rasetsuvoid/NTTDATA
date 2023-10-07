using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RequestDelivery : BaseEntity
    {

        [Column(TypeName = "decimal(9, 6)")]
        public required decimal DestinationLongitude { get; set; }

        [Column(TypeName = "decimal(9, 6)")]
        public required decimal DestinationLatitude { get; set; }

        public required DateTime CurrentDate { get; set; }

        public required TimeSpan CurrentTime { get; set; }
        public required string WeatherType { get; set; }

        public int unitCount { get; set; }

        [ForeignKey("Delivery")]
        public required int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
