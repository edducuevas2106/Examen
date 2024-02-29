using Entidades;
using Entidades.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Servicios
{
    public interface IDirectorioService
    {
        Task<Persona> findPersonaByIdentificacion(string identificacionId);
        Task<IEnumerable<Persona>> findPersonas();
        Task<int> deletePersonaByIdentificacion(string identificacionId);
        Task<int> storePersonas(Persona item);
        Task<IPagedList<Persona>> GetAllPaged(PageInfo pageInfo);
    }
}
