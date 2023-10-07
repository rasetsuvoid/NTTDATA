using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos.Delivery
{
    public class DeliveryDetailsDto
    {
        public double OriginLongitude { get; set; }
        public double OriginLatitude { get; set; }
        public DateTime DeliveryDate { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public int ProvisionsToDeliver { get; set; }
    }

}
