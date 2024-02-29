using Entidades;
using Entidades.Models;

namespace Interfaces.Repositorios
{
    public interface IFacturaRepositorio : IBaseRepository<Factura> 
    {
        Task<PersonaFacturasModel> findFacturasByPersona(string identificacion);
    }
}
