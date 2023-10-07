using Application.Common.Dtos.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<Coordinates> GetCoordinates()
        {
            try
            {
                Coordinates? coordinates = await (from c in _context.Coordinates
                                         where c.Active == true && c.IsDeleted == false
                                         orderby c.Id
                                         select c)
                                    .FirstOrDefaultAsync();


                return coordinates;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}
