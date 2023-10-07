using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class ProvisionRepository : GenericRepository<Provision>, IProvisionRepository
    {
        public ProvisionRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }

}
