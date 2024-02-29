using Entidades;
using Entidades.Models;
using Interfaces.Repositorios;
using Interfaces.Servicios;
using PagedList;

namespace Servicio
{
    public class DirectorioService: IDirectorioService
    {
        protected readonly IPersonaRepositorio _personaRepositorio;
        protected readonly Logs.ILogger _logger;
        public DirectorioService(IPersonaRepositorio personaRepositorio, Logs.ILogger logger)
        {
            _personaRepositorio = personaRepositorio;
            _logger = logger;
        }

        public async Task<Persona> findPersonaByIdentificacion(string identificacionId)
        {
            try
            {
                return await _personaRepositorio.GetFirstAsync(x => x.Identificacion == identificacionId);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return new Persona();
            }
        }

        public async Task<IEnumerable<Persona>> findPersonas()
        {
            try
            {
                return await _personaRepositorio.GetAllAsync();
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return new List<Persona>();
            }
        }

        public async Task<int> deletePersonaByIdentificacion(string identificacionId)
        {
            try
            {
                var person = await _personaRepositorio.GetFirstAsync(x => x.Identificacion == identificacionId);
                var result = await _personaRepositorio.DeleteAsync(person);
                if (result != null)
                    return 1;

                return 0;
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return -1;
            }
        }

        public async Task<int> storePersonas(Persona item)
        {
            try
            {
                item.Identificacion = await _personaRepositorio.generarIdentificador();
                var result = await _personaRepositorio.AddAsync(item);
                if (result != null) return 1;

                return 0;
            }
            catch(Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return 0;
            }
        }

        public async Task<IPagedList<Persona>> GetAllPaged(PageInfo pageInfo)
        {
            try
            {
                var user = await _personaRepositorio.GetAllPaged(pageInfo);
                return user;
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return null;
            }
        }
    }
}
