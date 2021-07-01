using System;

namespace ControlaloPE.Domain.Commands.EmpresaCommands{
    public class CrearEmpresaCommand : EmpresaCommand{
        public CrearEmpresaCommand(Guid id_Persona, string nombre, string ruc):base(id_Persona, nombre, ruc)
        {
            Id_Empresa = Guid.NewGuid();
        }
       
        public override bool IsValid()
        {
            ValidationResult = new CrearEmpresaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
      
    }
    public class CrearEmpresaValidation:EmpresaValidation<CrearEmpresaCommand>{
        public CrearEmpresaValidation()
        {
            ValidarNombre();
        }
    }
}