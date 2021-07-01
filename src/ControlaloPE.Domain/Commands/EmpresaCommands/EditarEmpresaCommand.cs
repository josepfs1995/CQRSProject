using System;

namespace ControlaloPE.Domain.Commands.EmpresaCommands{
    public class EditarEmpresaCommand : EmpresaCommand{
        public EditarEmpresaCommand(Guid id_Empresa, Guid id_Persona, string nombre, string ruc):base(id_Persona, nombre, ruc)
        {
            Id_Empresa = id_Empresa;
        }
       
        public override bool IsValid()
        {
            ValidationResult = new EditarEmpresaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class EditarEmpresaValidation:EmpresaValidation<EditarEmpresaCommand>{
        public EditarEmpresaValidation()
        {
            ValidarNombre();
            ValidarRUC();
        }
    }
}