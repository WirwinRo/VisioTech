using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.domain.Interfaces;
using visiotech.infrastructure.Config;
using visiotech.infrastructure.Exceptions;


namespace visiotech.infrastructure.Repositories
{
    public class CommonRepository<E> : ICommonRepository<E> where E : class
    {
        private readonly DbContextFactory _contextFactory;

        public CommonRepository(DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private VisioTechContext CreateContext() => _contextFactory.CreateDbContext();

        public async Task<E> Create(E Entity)
        {
            using var context = CreateContext();
            context.Set<E>().Add(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using var context = CreateContext();
            var entity = await context.Set<E>().FindAsync(id)
            ?? throw new EntityNotFoundException($"El item {id} no existe en la base de datos.");

            context.Set<E>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<E> Update(E Entity)
        {
            using var context = CreateContext();
            context.Set<E>().Update(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<E> GetDataByID(int id)
        {
            using var context = CreateContext();

            return await context.Set<E>().FindAsync(id);
        }

        public async Task<List<E>> List()
        {
            using var context = CreateContext();
            return await context.Set<E>().AsNoTracking().ToListAsync();
        }

    }
}
