using System;
using FluentValidation;

namespace ControlaloPE.Domain.Commands.EmpresaCommands{
    public abstract class EmpresaCommand:Command{
        public EmpresaCommand()
        {
            
        }
        protected EmpresaCommand(Guid id_Persona, string nombre, string ruc)
        {
            Id_Persona = id_Persona;
            Nombre = nombre;
            Ruc = ruc;
            Estado = true;
        }
        public Guid Id_Empresa { get; set; }
        public Guid Id_Persona { get; protected set; }
        public string Nombre { get; protected set; }
        public string Ruc { get; protected set; }
        public string Logo { get; protected set; }
        public DateTime FechaCreacion { get; protected set; }
        public bool Estado { get; protected set; }
        public void AgregarLogo(string logo){
            Logo = logo;
        }
    }
    public class EmpresaValidation<T>:AbstractValidator<T> where T:EmpresaCommand{
        protected void ValidarId() {

            RuleFor(x=> x.Id_Empresa)
                .NotEmpty().WithMessage("El Id_Empresa no puede estar vacío");
        }
        protected void ValidarNombre() {

            RuleFor(x=> x.Nombre)
                .NotEmpty().WithMessage("El Nombre no puede estar vacío");
        }
        protected void ValidarRUC() {

            RuleFor(x=> x.Ruc)
                .NotEmpty().WithMessage("El RUC no puede estar vacío");
        }
    }
}