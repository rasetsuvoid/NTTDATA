using Application.Common.Dtos.Delivery;
using Application.Common.Dtos.Generic;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IDeliveryService : IGenericService<Delivery>
    {
        Task<HttpResponse<DeliveryResponseDto>> CalculateProvisionsAsync(DeliveryRequestDto request);
    }
}
