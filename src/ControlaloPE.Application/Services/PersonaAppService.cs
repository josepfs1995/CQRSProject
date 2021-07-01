using System;
using System.Threading.Tasks;
using AutoInject.Interfaces;
using ControlaloPE.Application.Interfaces;
using ControlaloPE.Application.ViewModels;
using ControlaloPE.BuildingBlocks.Core;
using ControlaloPE.Domain.Commands.PersonaCommands;
using ControlaloPE.Domain.Interfaces.Queries;
using FluentValidation.Results;
using Mapster;
using MediatR;

namespace ControlaloPE.Application.Services{
    public class PersonaAppService:IPersonaAppService,IAutoDI{
        private readonly IPersonaQueries _personaQueries;
        private readonly IMediator _mediator;
        private readonly IUserManager _userManager;
        public PersonaAppService(IPersonaQueries personaQueries, IMediator mediator, IUserManager userManager)
        {
            _personaQueries = personaQueries;
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<ValidationResult> Crear(CrearPersonaViewModel model)
        {
            var personaCommand = new CrearPersonaCommand(_userManager.Id, model.Nombre, model.ApellidoPaterno, model.ApellidoMaterno, model.FechaNacimiento);
            var response = await _mediator.Send(personaCommand);
            return response;
        }
        public async Task<PersonaViewModel> Obtener()
        {
            var response = await _personaQueries.Obtener(_userManager.Id);
            return response.Adapt<PersonaViewModel>();
        }
        public async Task<PersonaViewModel> Obtener(Guid id)
        {
            var response = await _personaQueries.Obtener(id);
            return response.Adapt<PersonaViewModel>();
        }
    }
}