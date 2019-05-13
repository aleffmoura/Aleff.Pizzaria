using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Data.Contexts
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PizzariaDbContext>
    {
        public PizzariaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzariaDbContext>();
            optionsBuilder.UseSqlServer("Server=db,1433;Database=PizzariaContext;User=sa;Password=P4sw0rdStrong159456;",
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new PizzariaDbContext(optionsBuilder.Options);
        }
    }
}
