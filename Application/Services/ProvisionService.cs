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
    public class ProvisionService : GenericService<Provision>, IProvisionService
    {
        public ProvisionService(IProvisionRepository repository) : base(repository)
        {
        }

        
    }
}
