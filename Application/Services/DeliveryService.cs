using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeliveryService : GenericService<Delivery>, IDeliveryService
    {
        public DeliveryService(IRepository<Delivery> repository) : base(repository)
        {
        }

        
    }
}
