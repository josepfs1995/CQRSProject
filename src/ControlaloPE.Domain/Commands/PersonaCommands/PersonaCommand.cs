using System;
using FluentValidation;

namespace ControlaloPE.Domain.Commands.PersonaCommands{
    public abstract class PersonaCommand:Command{
        protected PersonaCommand(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Estado = true;
        }
       public Guid Id_Persona { get; protected set; }
       public string Nombre { get; protected set; }
       public string ApellidoPaterno { get; protected set; }
       public string ApellidoMaterno { get; protected set; }
       public DateTime? FechaNacimiento { get; protected set; }
       public bool Estado { get; protected set; }
    }
    public class PersonaValidation<T>:AbstractValidator<T> where T:PersonaCommand{
        protected void ValidarNombre() {

            RuleFor(x=> x.Nombre)
                .NotEmpty().WithMessage("El Nombre no puede estar vacío");
        }
    }
}