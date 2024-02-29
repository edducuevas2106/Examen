using Entidades;
using Entidades.Models;
using Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using PagedList;
using Repositorio.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class FacturaRepositorio : BaseRepository<Factura>, IFacturaRepositorio
    {
        public FacturaRepositorio(EntitiesModel context) : base(context) { }

        public async Task<PersonaFacturasModel> findFacturasByPersona(string identificacion)
        {
            var result = await (from person in Context.Personas
                                where person.Identificacion == identificacion
                                select new PersonaFacturasModel
                                {
                                    Personas = new Persona
                                    {
                                        Id = person.Id,
                                        Nombre = person.Nombre,
                                        APaterno = person.APaterno,
                                        AMaterno = person.AMaterno,
                                        Identificacion = person.Identificacion
                                    },
                                    Facturas = (from fac in Context.Facturas
                                                where fac.IdPersona == person.Id
                                                select new Factura
                                                {
                                                    Id= fac.Id,
                                                    Monto = fac.Monto,
                                                    Fecha = fac.Fecha,
                                                    IdPersona = fac.IdPersona
                                                }).ToArray(),
                                }).FirstOrDefaultAsync() 
                                ?? new PersonaFacturasModel();
            return result;
        }

    }
}
