using System;

namespace ControlaloPE.Application.ViewModels{
    public class PersonaViewModel{
        public Guid Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Estado { get; set; }
    }
    public class CrearPersonaViewModel {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}