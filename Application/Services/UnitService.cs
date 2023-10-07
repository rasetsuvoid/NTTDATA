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
    public class UnitService : GenericService<Unit>, IUnitService
    {
        private readonly IRepository<Unit> _repository;

        public UnitService(IRepository<Unit> repository) : base(repository)
        {
        }

        
    }
}
