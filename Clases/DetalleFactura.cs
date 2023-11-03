using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Clases
{
    public class DetalleFactura
    {
        public int IdDetalleFactura {get; set;}
        public int NumeroFactura {get; set;}
        public int IdProducto {get; set;}
        public int Cantidad {get; set;}
        public int Valor {get; set;}
    }
}