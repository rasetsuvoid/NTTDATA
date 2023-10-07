using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos.Coordinates
{
    public class CoordinatesRequestDto
    {
        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
