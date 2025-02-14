using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

        private VisioTechContext CreateContext() => _contextFactory.CreateDbContext();
        public async Task<Dictionary<string, int>> GetGrapeByArea()
        {
            using var ctx = CreateContext();
            var grapesareas = await ctx.parcel
                .Include(a => a.Grape)
                .GroupBy(g => g.Grape.Name)
                .Select(d => new
                {
                    GrapeName = d.Key,
                    TotalArea = d.Sum(i => i.Area)
                }).ToListAsync();

            return grapesareas.ToDictionary(r => r.GrapeName, r => r.TotalArea);
        }
    }
}
