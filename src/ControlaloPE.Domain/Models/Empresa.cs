using System;

namespace ControlaloPE.Domain.Models{
    public class Empresa{
        public Guid Id_Empresa { get; set; }
        public Guid Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public string Ruc { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public Persona Persona { get; set; }
    }
}