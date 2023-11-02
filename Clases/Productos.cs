using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Clases
{
    public class Productos : ClassEntity
    {
        public string Nombre { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
    }
}