using System;
using Microsoft.AspNetCore.Http;

namespace ControlaloPE.Application.ViewModels{
    public class EmpresaViewModel{
        public Guid Id_Empresa { get; set; }
        public Guid Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public string Ruc { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
    public class CrearEmpresaViewModel{
        public string Nombre { get; set; }
        public IFormFile LogoFile { get; set; }
        public string Ruc { get; set; }
    }
    public class EditarEmpresaViewModel{
        public Guid Id_Empresa { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public IFormFile LogoFile { get; set; }
        public string Ruc { get; set; }
    }
}