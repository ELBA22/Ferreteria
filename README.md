# Ferreteria
Ejercicio para entrega sobre una Ferreteria.
Este ejercicio es un programa de consulta en consola, usando metodos de linq.

# Carpeta Clases(Entidades)
Tenemos unas entidades de tipo clases: Cliente, DetalleFactura, Factura, Producto, las cuales
poseen unos atributos. 

# Carpeta LinQuerys
En esta carpeta encontramos los diferentes metodos que usamos para las consultas.

## Archivo Linq.
En este archivo se define un conjunto de clases y listas que representan articulos, usuarios, atributos de la ferreteria.

Dentro de cada lista, se inicializan los objetos correspondientes utilizando la sintaxis de inicialización de objetos. Esto significa que se crean instancias de los objetos y se asignan valores a sus propiedades en el momento de la creación.

![Image](<Captura de pantalla 2023-11-03 113430.png>)


## Funciones.
1. Esta funcion permite listar, mostrar los productos de la ferreteria.
Usamos el metodo from y select (LINQ) para seleccionar todos los elementos de la lista y almacenarlos en una nueva variable llamada ProductosInventario. 

```
    public void ProductosAListar()
        {
            var ProductosInventario = from i in ProductosList
                                    select i;
            foreach (var producto in ProductosInventario)
            {
                Console.WriteLine($"Id {producto.IdProducto}, Nombre {producto.Nombre}, Cantidad {producto.Cantidad}");
            }
        }
```
2. En esta funcion, se hace la consulta LINQ para seleccionar todos los elementos de la lista (ProductosList) que cumplan con una condición específica, la condición se verifica mediante where, que compara la propiedad Cantidad de cada producto con la propiedad StockMinimo, si la cantidad en stock es menor que el stock mínimo, el producto se selecciona y se almacena en la variable ProductosAgotados.

```
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
```

3. En esta funcion se utilizan los metodos de where para ver los productos que se han comprado.
```
        public void ListProComprar()
        {
            var ProductosComprar = ProductosList.Where(Productos => Productos.Cantidad < Productos.StockMaximo);
            foreach (var producto in ProductosComprar)
            {
                int cantidadComprar = producto.StockMaximo - producto.Cantidad;
                Console.WriteLine($"ID: {producto.IdProducto}, Nombre: {producto.Nombre}, Cantidad a Comprar: {producto.Cantidad}" );
            }
        }
```

4. En esta funcion se verifica el atributo Fecha de cada factura tenga un año igual a 2023 y un mes igual a 1, lo que significa que se están seleccionando las facturas del mes de enero de 2023.


```
        public void ListFacturaEnero()
        {
                    var FacturasEnero = FacturaList
                                            .Where (i => i.Fecha.Year == 2023 && i.Fecha.Month == 1)
                                            .Sum(i => i.TotalFactura);
                                            Console.WriteLine($"Valor total del mes de enero: {FacturasEnero}");
        }
```

5. En esta funcion se permite al usuario ingresar un número de factura, y luego muestra la lista de productos vendidos en la factura, extrayendo  información de dos colecciones, ProductosList y DetalleFacturaList, a través de la consulta LinQ uniendo los productos con los detalles de factura en base al identificador del producto.
La unión se realiza mediante la cláusula join que compara la propiedad IdProducto de los productos en ProductosList con la propiedad IdProducto de los detalles de factura en DetalleFacturaList.

```
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
```

6. En esta funcion se calcula el valor total de cada producto en el inventario, la consulta recorre la colección ProductosList y, para cada producto (i), calcula el valor total multiplicando el precio unitario del producto.
Se utiliza la función Sum para sumar todos los valores calculados, esto proporciona el valor total del inventario, es decir, la suma de los valores totales de todos los productos en el inventario.

```
        public void ValorTotalInventario(){
            var valortotal = from i in ProductosList
            select i.PrecioUnitario * i.Cantidad;
            double Resultadototal = valortotal.Sum();
            Console.WriteLine("El valor total del inventario es: " + Resultadototal);
        }
```

Listo, es todo hemos terminado...




