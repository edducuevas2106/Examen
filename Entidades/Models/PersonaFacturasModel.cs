using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class PersonaFacturasModel
    {
        public Persona Personas { get; set; }
        public IEnumerable<Factura> Facturas { get; set; }

    }
}
