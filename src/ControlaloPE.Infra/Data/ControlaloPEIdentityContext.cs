using ControlaloPE.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlaloPE.Infra.Data{
    public class ControlaloPEIdentityContext:IdentityDbContext {
        public ControlaloPEIdentityContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole(RolesConst.ADMINISTRADOR){
                    NormalizedName = RolesConst.ADMINISTRADOR
                },
                new IdentityRole(RolesConst.USUARIO){
                    NormalizedName = RolesConst.USUARIO
                });

            
            base.OnModelCreating(builder);
        }
    }
}