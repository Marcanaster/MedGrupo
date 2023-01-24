using MedGrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedGrupo.Data.Mapping
{
    public  class ContactMap : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Active);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.Gender);
        }
    }
}
