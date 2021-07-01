using System;
using System.Threading.Tasks;
using ControlaloPE.Application.ViewModels;
using FluentValidation.Results;

namespace ControlaloPE.Application.Interfaces{
    public interface IPersonaAppService{
        Task<PersonaViewModel> Obtener();
        Task<PersonaViewModel> Obtener(Guid id);
        Task<ValidationResult> Crear(CrearPersonaViewModel model);
    }
}