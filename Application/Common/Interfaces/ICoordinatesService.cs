using Application.Common.Dtos.Coordinates;
using Application.Common.Dtos.Generic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICoordinatesService : IGenericService<Coordinates>
    {
        Task<HttpResponse<string>> CreateCoordinates(CoordinatesRequestDto request);
    }
}
