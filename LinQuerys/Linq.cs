using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferreteria.Clases;

namespace Ferreteria.LinQuerys
{
    public class Linq
    {
        List<Productos> ProductosList = new List<Productos>()
        {
            new Productos(){Id = 1, Nombre ="Clavos", PrecioUnitario = 1500, Cantidad = 50, StockMaximo = 100, StockMinimo = 5},
            new Productos(){Id = 1, Nombre ="Serrucho", PrecioUnitario = 25000, Cantidad = 80, StockMaximo = 150, StockMinimo = 10},
            new Productos(){Id = 1, Nombre ="Bloques", PrecioUnitario = 1900, Cantidad = 500, StockMaximo = 1000, StockMinimo = 250},
            new Productos(){Id = 1, Nombre ="Martillos", PrecioUnitario = 20000, Cantidad = 30, StockMaximo = 100, StockMinimo = 10}
        };


        //MAIN.
        public void MainMenu()
        {
            Console.WriteLine("FERRETERIA CAMPUSLANDS.");
            Console.WriteLine("Ingrese la opcion que deseas realizar.");
            Console.WriteLine("1. Productos de inventario.");
            Console.WriteLine("2. Productos a punto de agotarse.");
            Console.WriteLine("3. Productos a comprar y cantidades.");
            Console.WriteLine("4. Total facturas del mes de enero 2023.");
            Console.WriteLine("5. Productos vendidos de una determinada factura.");
            Console.WriteLine("6. Valor total de inventario.");
            string opcion = Console.ReadLine();
            

        }
    }
}