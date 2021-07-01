using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlaloPE.Domain.Models;

namespace ControlaloPE.Domain.Interfaces.Queries{
    public interface IEmpresaQueries: IRead<Empresa>{
        Task<Empresa> Obtener(Guid id, Guid id_Persona);
        Task<IEnumerable<Empresa>> ObtenerPorPersona(Guid id);
    }
}