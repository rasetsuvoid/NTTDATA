using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class CoordinatesRepository : GenericRepository<Coordinates>, ICoordinatesRepository
    {
        public CoordinatesRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }

}
