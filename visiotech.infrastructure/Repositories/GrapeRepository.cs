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
    public class GrapeRepository : CommonRepository<Grape>, IGrapeRepository
    {
        private readonly DbContextFactory _contextFactory;
        public GrapeRepository(DbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

    }
}
