using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlaloPE.Application.ViewModels;
using FluentValidation.Results;

namespace ControlaloPE.Application.Interfaces{
    public interface IEmpresaAppService{
        Task<IEnumerable<EmpresaViewModel>> Obtener();
        Task<EditarEmpresaViewModel> Obtener(Guid id);
        Task<ValidationResult> Crear(CrearEmpresaViewModel model);
        Task<ValidationResult> Editar(EditarEmpresaViewModel model);
        Task<ValidationResult> Eliminar(Guid id);

    }
}