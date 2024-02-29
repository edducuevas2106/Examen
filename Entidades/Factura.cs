using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Factura")]
    public class Factura: BaseEntity
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int IdPersona { get; set; }
    }
}
