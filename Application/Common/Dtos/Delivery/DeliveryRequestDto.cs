using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos.Delivery
{
    public class DeliveryRequestDto
    {
        public double DestinationLongitude { get; set; }
        public double DestinationLatitude { get; set; }
        public DateTime CurrentDate { get; set; }
        public string CurrentTime { get; set; }
        public string WeatherType { get; set; }
        public int UnitCount { get; set; }


    }


}
