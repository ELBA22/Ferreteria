using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Clases
{
    public class Factura
    {
        public int NumeroFactura { get; set; }
        public DateTime Fecha {get; set;}

        public int IdCliente {get; set;}
        public int TotalFactura {get; set;}
    }
}