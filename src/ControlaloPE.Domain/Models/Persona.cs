using System;
using System.Collections.Generic;

namespace ControlaloPE.Domain.Models{
    public class Persona{
        public Guid Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Estado { get; set; }
        public ICollection<Empresa> Empresa { get; set; }
    }
}