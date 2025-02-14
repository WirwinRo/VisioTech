﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visiotech.infrastructure.Config
{
    public class DbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public VisioTechContext CreateDbContext()
        {

            return _serviceProvider.GetRequiredService<VisioTechContext>();
        }
    }
}
