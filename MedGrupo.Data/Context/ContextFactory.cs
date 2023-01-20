using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace MedGrupo.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MedGrupoContext>
    {
        public MedGrupoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<MedGrupoContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnetion"));
            return new MedGrupoContext(optionsBuilder.Options);
        }
    }
}
