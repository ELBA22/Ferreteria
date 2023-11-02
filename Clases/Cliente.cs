using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Clases
{
    public class Cliente : ClassEntity
    {
        public string NombreCliente { get; set; }
        public string Email {get; set;}

        public ICollection<Factura> Facturas {get; set;}

        
    }
}