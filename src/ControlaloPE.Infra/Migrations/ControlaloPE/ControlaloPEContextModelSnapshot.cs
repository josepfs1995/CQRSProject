﻿// <auto-generated />
using System;
using ControlaloPE.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlaloPE.Infra.Migrations.ControlaloPE
{
    [DbContext(typeof(ControlaloPEContext))]
    partial class ControlaloPEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlaloPE.Domain.Models.Empresa", b =>
                {
                    b.Property<Guid>("Id_Empresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Persona")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logo")
                        .HasColumnType("NVarchar(250)");

                    b.Property<string>("Nombre")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Ruc")
                        .HasColumnType("NVarchar(20)");

                    b.HasKey("Id_Empresa");

                    b.HasIndex("Id_Persona");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ControlaloPE.Domain.Models.Persona", b =>
                {
                    b.Property<Guid>("Id_Persona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnType("Varchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id_Persona");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ControlaloPE.Domain.Models.Empresa", b =>
                {
                    b.HasOne("ControlaloPE.Domain.Models.Persona", "Persona")
                        .WithMany("Empresa")
                        .HasForeignKey("Id_Persona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ControlaloPE.Domain.Models.Persona", b =>
                {
                    b.Navigation("Empresa");
                });
#pragma warning restore 612, 618
        }
    }
}
