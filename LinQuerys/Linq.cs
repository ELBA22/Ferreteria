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
            new Productos(){IdProducto = 1, Nombre ="Clavos", PrecioUnitario = 1500, Cantidad = 10, StockMaximo = 50, StockMinimo = 5},
            new Productos(){IdProducto = 2, Nombre ="Serrucho", PrecioUnitario = 25000, Cantidad = 5, StockMaximo = 25, StockMinimo = 5},
            new Productos(){IdProducto = 3, Nombre ="Bloques", PrecioUnitario = 1900, Cantidad = 100, StockMaximo = 200, StockMinimo = 15},
            new Productos(){IdProducto = 4, Nombre ="Martillos", PrecioUnitario = 20000, Cantidad = 2, StockMaximo = 40, StockMinimo = 10}
        };

        List<Cliente> ClienteList = new List<Cliente>()
        {
            new Cliente(){IdCliente = 01, NombreCliente = "Elba Esther", Email = "Egarci@gmail.com" },
            new Cliente(){IdCliente = 02, NombreCliente = "Margelis Bello", Email = "Marge01@hotmail.com" },
            new Cliente(){IdCliente = 03, NombreCliente = "Isaac Garcia", Email = "IgarSal@gmail.com" },
            new Cliente(){IdCliente = 04, NombreCliente = "Jesus David", Email = "Jdavid@gmail.com" }
        };

        List<Factura> FacturaList = new List<Factura>()
        {
            new Factura(){NumeroFactura = 1, Fecha = new DateTime (2023, 10, 12), IdCliente = 01, TotalFactura = 30000 },
            new Factura(){NumeroFactura = 2, Fecha = new DateTime (2023, 05, 22), IdCliente = 02, TotalFactura = 40000 },
            new Factura(){NumeroFactura = 3, Fecha = new DateTime (2023,01,11), IdCliente = 03, TotalFactura = 8000 },
            new Factura(){NumeroFactura = 4, Fecha = new DateTime (2023, 01,  12), IdCliente = 04, TotalFactura = 15000}
        };

        List<DetalleFactura> DetalleFacturaList = new List<DetalleFactura>()
        {
            new DetalleFactura {IdDetalleFactura= 01, NumeroFactura = 1, IdProducto= 1, Cantidad =10, Valor = 1500},
            new DetalleFactura {IdDetalleFactura= 02, NumeroFactura = 2, IdProducto= 2, Cantidad =5, Valor = 25000},
            new DetalleFactura {IdDetalleFactura= 03, NumeroFactura = 3, IdProducto= 3, Cantidad =100, Valor = 1900},
            new DetalleFactura {IdDetalleFactura= 04, NumeroFactura = 4, IdProducto= 4, Cantidad =2, Valor = 20000},
        };

        public void MainMenu()
        {
            bool controlador = true;
            while (controlador)
            {
                Console.Clear();
                Console.WriteLine("------------INVENTARIO FERRETERIA CAMPUSLAND------------");
                Console.WriteLine("|              INGRESE LA OPCION A REALIZAR.            |");
                Console.WriteLine("|1.              productos de inventario                |");
                Console.WriteLine("|2.       Productos que estan a punto de agotarse       |");
                Console.WriteLine("|3.                Productos a comprar                  |");
                Console.WriteLine("|4.      Total de facturas del mes de enero del 2023    |");
                Console.WriteLine("|5.           Productos vendidos de una factura         |");
                Console.WriteLine("|6.               Valor total del inventario            |");
                Console.WriteLine("|7------                    Salir              ---------|");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        ProductosAListar();
                        Console.ReadLine();
                        break;

                    case "2":
                        ListarAgotados();
                        Console.ReadLine();
                        break;

                    case "3":
                        ListProComprar();
                        Console.ReadLine();
                        break;

                    case "4":
                        ListFacturaEnero();
                        Console.ReadLine();
                        break;

                    case "5":
                        ProductosVendidos();
                        Console.ReadLine();
                        break;

                    case "6":
                        ValorTotalInventario();
                        Console.ReadLine();
                        break;

                    case "7":
                        controlador = false;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida, presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            }
        }

        //Opcion 1, listar productos.
        public void ProductosAListar()
        {
            var ProductosInventario = from i in ProductosList
                                    select i;
            foreach (var producto in ProductosInventario)
            {
                Console.WriteLine($"Id {producto.IdProducto}, Nombre {producto.Nombre}, Cantidad {producto.Cantidad}");
            }
        }

        //Opcion 2, Listar productos agotados.
        public void ListarAgotados()
        {
            var ProductosAgotados = from i in ProductosList
                                    where i.Cantidad < i.StockMinimo
                                    select i;
            foreach (var producto in ProductosAgotados)
            {
                Console.WriteLine($" Nombre  {producto.Nombre}");
            }
        }


        //Opcion 3, Listar productos que se deben comprar.
        public void ListProComprar()
        {
            var ProductosComprar = ProductosList.Where(Productos => Productos.Cantidad < Productos.StockMaximo);
            foreach (var producto in ProductosComprar)
            {
                int cantidadComprar = producto.StockMaximo - producto.Cantidad;
                Console.WriteLine($"ID: {producto.IdProducto}, Nombre: {producto.Nombre}, Cantidad a Comprar: {producto.Cantidad}" );
            }
        }

        //Opcion 4, facturas de enero.
        public void ListFacturaEnero()
        {
                    var FacturasEnero = from i in FacturaList
                                            where i.Fecha.Year == 2023 && i.Fecha.Month == 1
                                            select i;
                        foreach (var productos in FacturasEnero)
                        {
                            Console.WriteLine($"Valor facturas del mes de enero: {productos.TotalFactura }");
                        } 
        }

        //Opcion 5, Listar productos de una factura determinada.
        public void ProductosVendidos()
        {
            Console.WriteLine("Ingrese el numero de factura que desea consultar : ");
            int numeroFactura = Int32.Parse(Console.ReadLine());
            var productos = from pro in ProductosList
                            join detfac in DetalleFacturaList
                            on pro.IdProducto equals detfac.IdProducto
                            select new
                            {
                                producto = pro.Nombre,
                                id = pro.IdProducto
                            };
            foreach (var i in productos)
            {
                Console.WriteLine($"Id {i.id}, Nombre: {i.producto}");
            }
        }

        //opcion 6,  valor total de inventario
        public void ValorTotalInventario(){
            var valortotal = from i in ProductosList
            select i.PrecioUnitario * i.Cantidad;
            double Resultadototal = valortotal.Sum();
            Console.WriteLine("El valor total del inventario es: " + Resultadototal);
        }

    }
}