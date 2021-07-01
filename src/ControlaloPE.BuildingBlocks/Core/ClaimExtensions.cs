using System.Linq;
using System;
using System.Security.Claims;

namespace ControlaloPE.BuildingBlocks.Core{
    public static class ClaimExtensions{
        public static Guid ObtenerId(this ClaimsPrincipal claimPrincipal){
            var claim = claimPrincipal.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.NameIdentifier);
            if(claim == null) throw new ArgumentException($"Claims {ClaimTypes.NameIdentifier} no existe");
            return new Guid(claim.Value);
        }
        public static string ObtenerEmail(this ClaimsPrincipal claimPrincipal){
            var claim = claimPrincipal.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.Email);
            if(claim == null) throw new ArgumentException($"Claims {ClaimTypes.Name} no existe");
            return claim.Value;
        }
         public static string ObtenerNombre(this ClaimsPrincipal claimPrincipal){
            var claim = claimPrincipal.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.Name);
            if(claim == null) throw new ArgumentException($"Claims {ClaimTypes.Name} no existe");
            return claim.Value;
        }
    }
}