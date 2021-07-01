using System;
using Microsoft.AspNetCore.Http;

namespace ControlaloPE.BuildingBlocks.Core{
    public interface IUserManager{
        HttpContext Context { get; }
        Guid Id { get; }
        string Email { get; }
        string Nombre { get; }
    }
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid Id => _httpContextAccessor.HttpContext.User.ObtenerId();
        public string Email =>  _httpContextAccessor.HttpContext.User.ObtenerEmail();
        public string Nombre => _httpContextAccessor.HttpContext.User.ObtenerNombre();
        public HttpContext Context => _httpContextAccessor.HttpContext;
    }
}