using MedGrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedGrupo.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("_User");
            builder.HasKey(p => p.Id);
            builder.HasIndex(c => c.Login).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Login).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Senha).IsRequired().HasMaxLength(500);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(150);
            builder.Property(c => c.Ativo);

            builder.OwnsOne(c => c.Nome, nome =>
            {
                nome.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
                nome.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            });

        }
    }
}
