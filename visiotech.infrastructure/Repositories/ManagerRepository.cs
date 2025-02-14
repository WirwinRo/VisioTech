using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.domain.Entities;
using visiotech.domain.Interfaces;
using visiotech.infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace visiotech.infrastructure.Repositories
{
    public class ManagerRepository : CommonRepository<Manager>, IManagerRepository
    {
        private readonly DbContextFactory _contextFactory;
        public ManagerRepository(DbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private VisioTechContext CreateContext() => _contextFactory.CreateDbContext();
        public async Task<Dictionary<string, int>> GetManagerArea()
        {
            using var ctx = CreateContext();
            var managersareas = await ctx.parcel
                .Include(a => a.Manager)
                .GroupBy(g => g.Manager.Name)
                .Select(d => new
                {
                    ManagerName = d.Key,
                    TotalArea = d.Sum(i => i.Area)
                }).ToListAsync();

            return managersareas.ToDictionary(r => r.ManagerName, r => r.TotalArea);
        }
    }
}
