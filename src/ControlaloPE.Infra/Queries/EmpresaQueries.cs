using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoInject.Interfaces;
using ControlaloPE.Domain.Interfaces.Queries;
using ControlaloPE.Domain.Models;
using ControlaloPE.Infra.Data;
using Dapper;

namespace ControlaloPE.Infra.Queries{
    public class EmpresaQueries:Queries, IEmpresaQueries, IAutoDI{
        public EmpresaQueries(ControlaloPEContext context):base(context)
        {
        }
        public Task<IEnumerable<Empresa>> Listar()
        {
            throw new NotImplementedException();
        }
        public async Task<Empresa> Obtener(Guid id, Guid id_Persona)
        {
            const string sql = "SELECT * FROM Empresas WHERE Id_Empresa = @id AND Id_Persona = @id_Persona";
            return await ObtenerConexion().QuerySingleOrDefaultAsync<Empresa>(sql, param: new {id = id, id_Persona = id_Persona});
        }
        public Task<Empresa> Obtener(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Empresa>> ObtenerPorPersona(Guid id)
        {
            const string sql = "SELECT * FROM Empresas WHERE Id_Persona = @id";
            return await ObtenerConexion().QueryAsync<Empresa>(sql, param: new {id = id});
        }
    }
}