using System.Threading.Tasks;
using ControlaloPE.Domain.Interfaces;
using ControlaloPE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlaloPE.Infra.Data{
    public class ControlaloPEContext:DbContext, IUnitOfWork{
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public ControlaloPEContext(DbContextOptions<ControlaloPEContext> options) : base(options)
        {
        }      
        protected override void OnModelCreating(ModelBuilder modelBuilder){
              modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
              base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> GuardarCambios()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}