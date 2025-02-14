using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visiotech.domain.Entities;

namespace visiotech.infrastructure.Config
{
    public class VisioTechContext : DbContext
    {
        public VisioTechContext()
        {
        }

        public VisioTechContext(DbContextOptions<VisioTechContext> options) : base(options)
        {
        }

        public DbSet<Grape> grape { get; set; }
        public DbSet<Manager> manager { get; set; }
        public DbSet<Parcel> parcel { get; set; }
        public DbSet<Vineyard> vineyard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
