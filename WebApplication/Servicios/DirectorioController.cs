using Entidades;
using Entidades.Models;
using Interfaces.Servicios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Config;

namespace WebApplication.Servicios
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        protected readonly IDirectorioService _directorioService;

        public DirectorioController(IDirectorioService directorioService)
        {
            _directorioService = directorioService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody]Persona objPersonAdd)
        {
            var result = await _directorioService.storePersonas(objPersonAdd);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _directorioService.findPersonas();
            if (result.Count() >0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _directorioService.findPersonaByIdentificacion(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _directorioService.deletePersonaByIdentificacion(id);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("getPaged")]
        public async Task<IActionResult> GetAllPaged([FromBody] PageInfo pageInfo)
        {
            //var conditionsConvert = JsonConvert.DeserializeObject<PageInfo>(pageInfo.First.ToString());
            var users = await _directorioService.GetAllPaged(pageInfo);
            var pagination = users.ConvertClassPaginationByPagedList();
            return Ok(pagination);
        }
    }
}
