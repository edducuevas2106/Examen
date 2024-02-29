using Dapper;
using Entidades;
using Entidades.Models;
using Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using PagedList;
using Repositorio.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositorio
{
    public class PersonaRepositorio : BaseRepository<Persona>, IPersonaRepositorio
    {
        public PersonaRepositorio(EntitiesModel context) : base(context) { }
        public async Task<string> generarIdentificador()
        {
            var cnn = new SqlConnection(_appSettingTool.ConnectionString);
            try
            {
                using (cnn)
                {
                    await cnn.OpenAsync();
                    var query = @"sp_Generar_Codigo";
                    var results = await cnn.QueryFirstOrDefaultAsync<string>(query, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                await cnn.CloseAsync();
            }
        }

        public async Task<IPagedList<Persona>> GetAllPaged(PageInfo pageInfo)
        {
            var consulta = await Context.Set<Persona>()
                .Where(obj => obj.Nombre.Contains(pageInfo.Search) ||
                              obj.Nombre == "" ||
                              obj.Nombre == null ||
                              obj.Identificacion.Contains(pageInfo.Search) ||
                              obj.Identificacion == "" ||
                              obj.Identificacion == null)
                .ToListAsync();
            var pageList = new PagedList<Persona>(consulta, pageInfo.PageNumber, pageInfo.PageSize);
            return pageList;
        }
    }
    
}
