using Entidades;
using Entidades.Models;
using Interfaces.Repositorios;
using Interfaces.Servicios;

namespace Servicio
{
    public class VentaServicio: IVentaServicio
    {
        protected readonly IFacturaRepositorio _facturaRepositorio;
        protected readonly Logs.ILogger _logger;
        public VentaServicio(IFacturaRepositorio facturaRepositorio, Logs.ILogger logger)
        {
            _facturaRepositorio = facturaRepositorio;
            _logger = logger;
        }

        public async Task<PersonaFacturasModel> findFacturasByPerson(string id)
        {
            try
            {
                return await _facturaRepositorio.findFacturasByPersona(id);
            }
            catch(Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return new PersonaFacturasModel();
            }
        }

        public async Task<int> storeFactura(Factura item)
        {
            try
            {
                var result = await _facturaRepositorio.AddAsync(item);
                if(result != null)
                {
                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(ex.Message, 1, "");
                return -1;
            }
        }
    }
}
