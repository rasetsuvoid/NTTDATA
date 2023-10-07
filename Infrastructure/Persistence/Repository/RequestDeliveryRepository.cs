using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class RequestDeliveryRepository : GenericRepository<RequestDelivery>, IRequestDeliveryRepository
    {
        public RequestDeliveryRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
