using MedGrupo.Data.Context;
using MedGrupo.Data.Repository;
using MedGrupo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using MedGrupo.Data.Implementation;
using MedGrupo.Domain.Repository;

namespace MedGrupo.Service.DI
{
    public class ConfigureRepository
    {
        private readonly IConfiguration _Configuration;
        public ConfigureRepository(IConfiguration configuration)
        {
            this._Configuration = configuration;
        }
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            var optionsBuilder = new DbContextOptionsBuilder<MedGrupoContext>();
            serviceCollection.AddDbContext<MedGrupoContext>(
                options => options.UseSqlServer("Server= MARCANASTER\\SQLEXPRESS; Initial Catalog=MedGrupo; Persist Security Info = True; User ID=marcanaster; Password = f0d@s481521; MultipleActiveResultSets = True")
            );
        }
    }
}
