using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.domain.Entities;
using visiotech.domain.Interfaces;
using visiotech.infrastructure.Config;

namespace visiotech.infrastructure.Repositories
{
    public class ManagerRepository : CommonRepository<Manager>, IManagerRepository
    {
        private readonly DbContextFactory _contextFactory;
        public ManagerRepository(DbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
