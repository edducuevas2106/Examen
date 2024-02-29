using Entidades;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Servicios
{
    public interface IVentaServicio
    {
        Task<PersonaFacturasModel> findFacturasByPerson(string id);
        Task<int> storeFactura(Factura item);
    }
}
