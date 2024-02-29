using Entidades;
using Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Servicios
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        protected readonly IVentaServicio _ventaServicio;

        public VentasController(IVentaServicio ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(Factura item)
        {
            var result = await _ventaServicio.storeFactura(item);
            if (result != 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _ventaServicio.findFacturasByPerson(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
