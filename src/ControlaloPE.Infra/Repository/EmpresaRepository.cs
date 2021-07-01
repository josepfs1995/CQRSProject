using AutoInject.Interfaces;
using ControlaloPE.Domain.Interfaces;
using ControlaloPE.Domain.Interfaces.Repository;
using ControlaloPE.Domain.Models;
using ControlaloPE.Infra.Data;

namespace ControlaloPE.Infra.Repository
{
    public class EmpresaRepository : IEmpresaRepository, IAutoDI
    {
        private readonly ControlaloPEContext _context;
        public EmpresaRepository(ControlaloPEContext context)
        {
            _context = context;
        }
        public IUnitOfWork UoW => _context;
        public void Crear(Empresa model)
        {
            _context.Empresas.Add(model);
        }

        public void Editar(Empresa model)
        {
            _context.Empresas.Update(model);
        }
        public void Eliminar(Empresa model)
        {
            model.Estado = false;
            _context.Empresas.Update(model);
        }
    }
}