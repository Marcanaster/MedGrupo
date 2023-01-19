using MedGrupo.Data.Mapping;
using MedGrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGrupo.Data.Context
{
    public  class MedGrupoContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MedGrupoContext(DbContextOptions<MedGrupoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
