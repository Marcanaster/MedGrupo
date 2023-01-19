using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MedGrupo.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MedGrupoContext>
    {
        public MedGrupoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedGrupoContext>();
            optionsBuilder.UseSqlServer("Server= MARCANASTER\\SQLEXPRESS; Initial Catalog = MedGrupo; Persist Security Info = True; User ID = marcanaster; Password = f0d@s481521; MultipleActiveResultSets = True");
            return new MedGrupoContext(optionsBuilder.Options);
        }
    }
}
