using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoInject.Interfaces;
using ControlaloPE.Domain.Interfaces.Queries;
using ControlaloPE.Domain.Models;
using ControlaloPE.Infra.Data;
using Dapper;

namespace ControlaloPE.Infra.Queries
{
    public class PersonaQueries : Queries, IPersonaQueries, IAutoDI
    {
        public PersonaQueries(ControlaloPEContext context):base(context)
        {
        }
        public async Task<IEnumerable<Persona>> Listar()
        {
            const string sql = @"SELECT * FROM Personas WHERE Estado = true";
            return await ObtenerConexion().QueryAsync<Persona>(sql);
        }
        public async Task<Persona> Obtener(Guid id)
        {
            const string sql = @"SELECT * FROM Personas WHERE Id_Persona = @id";
            return await ObtenerConexion().QuerySingleOrDefaultAsync<Persona>(sql, param: new {id = id});
        }
    }
}