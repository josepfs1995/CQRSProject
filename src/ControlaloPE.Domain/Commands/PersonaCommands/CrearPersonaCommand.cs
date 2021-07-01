using System;

namespace ControlaloPE.Domain.Commands.PersonaCommands{
    public class CrearPersonaCommand : PersonaCommand{
        public CrearPersonaCommand(Guid id_Persona, string nombre, string apellidoPaterno, string apellidoMaterno):base(nombre, apellidoPaterno, apellidoMaterno)
        {
            Id_Persona = id_Persona;
        }
        public CrearPersonaCommand(Guid id_Persona, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime? fechaNacimiento):base(nombre, apellidoPaterno, apellidoMaterno)
        {
            Id_Persona = id_Persona;
            FechaNacimiento = fechaNacimiento;
        }
        public override bool IsValid()
        {
            ValidationResult = new CrearPersonaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class CrearPersonaValidation:PersonaValidation<CrearPersonaCommand>{
        public CrearPersonaValidation()
        {
            ValidarNombre();
        }
    }
}