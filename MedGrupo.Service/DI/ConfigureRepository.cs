using MedGrupo.Data.Context;
using MedGrupo.Data.Implementation;
using MedGrupo.Data.Repository;
using MedGrupo.Domain.Interfaces.Repositories;
using MedGrupo.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MedGrupo.Service.DI
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MedGrupoContext>();
            serviceCollection.AddDbContext<MedGrupoContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnetion"))
            );
        }
    }
}
