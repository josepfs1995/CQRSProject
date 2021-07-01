using AutoInject.Interfaces;
using ControlaloPE.Domain.Interfaces;
using ControlaloPE.Domain.Interfaces.Repository;
using ControlaloPE.Domain.Models;
using ControlaloPE.Infra.Data;

namespace ControlaloPE.Infra.Repository
{
    public class PersonaRepository : IPersonaRepository, IAutoDI
    {
        private readonly ControlaloPEContext _context;
        public PersonaRepository(ControlaloPEContext context)
        {
            _context = context;
        }

        public IUnitOfWork UoW => _context;
        public void Crear(Persona model)
        {
            _context.Personas.Add(model);
        }

        public void Editar(Persona model)
        {
            _context.Personas.Update(model);
        }

        public void Eliminar(Persona model)
        {
            _context.Personas.Remove(model);
        }
    }
}