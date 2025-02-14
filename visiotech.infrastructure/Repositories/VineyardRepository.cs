using Microsoft.EntityFrameworkCore;
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
    public class VineyardRepository :CommonRepository<Vineyard>, IVineyardRepository
    {
        private readonly DbContextFactory _contextFactory;
        public VineyardRepository(DbContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private VisioTechContext CreateContext() => _contextFactory.CreateDbContext();
        public async Task<Dictionary<string, List<string>>> GetVineyardManager()
        {
            var ctx = CreateContext();
            var vineyardManagers = await ctx.parcel
                .Include(a => a.Vineyard)
                .Include(a => a.Manager)
                .GroupBy(g => g.Vineyard.Name)
                .Select(d => new
                {
                    VineyardName = d.Key,
                    ManagerNames = d.Where(m => m.Manager != null)
                    .Select(m => m.Manager.Name).Distinct() //obtenemos los nombres de los managers el distinct evita duplicados
                    .OrderBy(name => name).ToList() //ordenamos los nombres de los managers
                }).ToListAsync();

            return vineyardManagers.ToDictionary(v => v.VineyardName, v => v.ManagerNames);
        }
    }
}
