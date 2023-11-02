using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Clases
{
    public class Factura
    {
        public int NumeroFactura { get; set; }
        public DateOnly Fecha {get; set;}

        public int IdCliente {get; set;}
    }
}