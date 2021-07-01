using System;

namespace ControlaloPE.Domain.Commands.EmpresaCommands{
    public class EliminarEmpresaCommand : EmpresaCommand{
        public EliminarEmpresaCommand(Guid id_Empresa, Guid id_Persona)
        {
            Id_Empresa = id_Empresa;
            Id_Persona = id_Persona;
        }
       
        public override bool IsValid()
        {
            ValidationResult = new EliminarEmpresaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class EliminarEmpresaValidation:EmpresaValidation<EliminarEmpresaCommand>{
        public EliminarEmpresaValidation()
        {
            ValidarId();
        }
    }
}