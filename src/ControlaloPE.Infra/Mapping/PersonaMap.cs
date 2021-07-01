using ControlaloPE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlaloPE.Infra.Mapping{
    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(x=>x.Id_Persona);

            builder.Property(x=>x.Nombre)
            .HasColumnType("Varchar(50)");

            builder.Property(x=>x.ApellidoPaterno)
            .HasColumnType("Varchar(50)");

            builder.Property(x=>x.ApellidoMaterno)
            .HasColumnType("Varchar(50)");
        }
    }
}