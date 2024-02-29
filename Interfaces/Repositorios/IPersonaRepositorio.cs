using Entidades;
using Entidades.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositorios
{
    public interface IPersonaRepositorio : IBaseRepository<Persona> 
    {
        Task<string> generarIdentificador();
        Task<IPagedList<Persona>> GetAllPaged(PageInfo pageInfo);
    }
}
