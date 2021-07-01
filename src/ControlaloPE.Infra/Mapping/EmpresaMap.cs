using ControlaloPE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlaloPE.Infra.Mapping{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x=>x.Id_Empresa);

            builder.Property(x=>x.Nombre)
            .HasColumnType("Varchar(50)");

            builder.Property(x=>x.Logo)
            .HasColumnType("NVarchar(250)");
            
            builder.Property(x=>x.Ruc)
            .HasColumnType("NVarchar(20)");

            builder.HasOne(x=>x.Persona)
            .WithMany(x=>x.Empresa)
            .HasForeignKey(x=>x.Id_Persona);
        }
    }
}