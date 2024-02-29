using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositorio.Configuration
{
    public class EntitiesModel: DbContext
    {
        public readonly IConfiguration _configuration;

        public EntitiesModel(DbContextOptions<EntitiesModel> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
    }
}
