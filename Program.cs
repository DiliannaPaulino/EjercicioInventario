using System.Diagnostics.Tracing;
using System.Runtime.Serialization.Formatters;
using System.Linq;

namespace TiendaBarrio
{
    internal class Program
    {
        static List<string> productos = new List<string>();
        static List<int> precios = new List<int>();

        static void Main(string[] args)
        {
            int opcion = 0;

            while (opcion != 8)
            {
                Console.WriteLine("\n=== INVENTARIO DE PRODUCTOS ===");
                Console.WriteLine("1. Registrar Psroductos");
                Console.WriteLine("2. Mostrar Productos");
                Console.WriteLine("3. Buscar Producto");
                Console.WriteLine("4. Modificar Producto");
                Console.WriteLine("5. Eliminar Producto");
                Console.WriteLine("6. Estadisticas");
                Console.WriteLine("7. Ordenar Productos");
                Console.WriteLine("8. Sali");

                Console.WriteLine("Seleccione: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarProducto();
                        break;

                    case 2:
                        MostrarProducto();
                        break;

                    case 3:
                        BuscarProducto();
                        break;

                    case 4:
                        ModificarProducto();
                        break;

                    case 5:
                        EliminarProducto();
                        break;

                    case 6:
                        MostrarEstadistica();
                        break;

                    case 7:
                        OrdenarProductos();
                        break;

                    case 8:
                         Console.WriteLine("hasta pronto");;
                        break;

                         default :
     
                         Console.WriteLine("Opcion invalida");
       
     return;
                }
            }
        }

        /// Registrar el nombre y precio del producto. Evitando los precios con numeros negativos.

        static void RegistrarProducto()
        {
            string nombre;

            do
            {
                Console.WriteLine("Nombre del Producto: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacio");
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            int precio;

            do
            {
                Console.WriteLine("Precio del Producto: ");
                precio = Convert.ToInt32(Console.ReadLine());

                if (precio <= 0)
                {
                    Console.WriteLine("No se permiten precios negativos");
                }

            } while (precio <= 0);

            productos.Add(nombre);
            precios.Add(precio);

            Console.WriteLine("Poducto agregado");
        }


        /// Mostrar el nombre y precio del producto.

        static void MostrarProducto()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados");
                return;
            }

            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine(productos[i] + " - " + precios[i]);
            }
        }


        /// Buscar Producto por nombre y precio.

        static void BuscarProducto()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados para buscar");
                return;
            }

            Console.WriteLine("Insertar el nombre: ");
            string buscar = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].ToLower() == buscar.ToLower())
                {
                    Console.WriteLine("Producto: " + productos[i]);
                    Console.WriteLine("Precio:   " + precios[i]);

                    encontrado = true;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("Producto no encontrado");
            }
        }


        /// Modificar el nombre y precio del producto. Para que se guarde un producto nuevo.

        static void ModificarProducto()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados para modificar");
                return;
            }

            Console.Write("Ingrese el nombre del producto que desea modificar: ");
            string buscar = Console.ReadLine();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].ToLower() == buscar.ToLower())
                {
                    string nuevoNombre;

                    do
                    {
                        Console.Write("Nuevo nombre: ");
                        nuevoNombre = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nuevoNombre))
                        {
                            Console.WriteLine("El nombre no puede estar vacio");
                        }

                    } while (string.IsNullOrWhiteSpace(nuevoNombre));

                    int nuevoPrecio;

                    do
                    {
                        Console.Write("Nuevo precio: ");
                        nuevoPrecio = Convert.ToInt32(Console.ReadLine());

                        if (nuevoPrecio <= 0)
                        {
                            Console.WriteLine("No se permiten precios negativos");
                        }

                    } while (nuevoPrecio <= 0);

                    productos[i] = nuevoNombre;
                    precios[i] = nuevoPrecio;

                    Console.WriteLine("Producto modificado correctamente");
                    return;
                }
            }

            Console.WriteLine("No se puede modificar un proucto inexistente");
        }


        /// Eliminar prodducto.

        static void EliminarProducto()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados para eliminar");
                return;
            }

            Console.WriteLine(" producto a eliminar:  ");
            string eliminar = Console.ReadLine();

            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].ToLower() == eliminar.ToLower())
                {
                    productos.RemoveAt(i);
                    precios.RemoveAt(i);

                    Console.WriteLine("Fue eliminado correctamente");
                    return;
                }
            }

            Console.WriteLine("El producto que desea eliminar no existe lea el mandato");
        }


        /// Mostrar las estadisticas de los productos en la lista.

        static void MostrarEstadistica()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados");
                return;
            }

            double suma = 0;
            double mayor = precios[0];
            double menor = precios[0];

            int posicionMayor = 0;
            int posicionMenor = 0;

            for (int i = 0; i < precios.Count; i++)
            {
                suma += precios[i];

                if (precios[i] > mayor)
                {
                    mayor = precios[i];
                    posicionMayor = i;
                }

                if (precios[i] < menor)
                {
                    menor = precios[i];
                    posicionMenor = i;
                }
            }

            double promedio = suma / precios.Count;

            Console.WriteLine("\n=== ESTADISTICAS ===");
            Console.WriteLine("Total de PRODUCTOS: " + productos.Count);
            Console.WriteLine("Producto mas caro: " + productos[posicionMayor] + " - " + mayor);
            Console.WriteLine("Producto mas barato: " + productos[posicionMenor] + " - " + menor);
            Console.WriteLine("Promedio de los productos: " + promedio);
        }


        /// Ordenar los productos alfabeticamente utilizando Sort.

        static void OrdenarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos para ordenar");
                return;
            }

            List<int> indices = Enumerable.Range(0, productos.Count).ToList();

            indices.Sort((a, b) =>
                string.Compare(productos[a], productos[b]));

            List<string> productosOrdenados = new List<string>();
            List<int> preciosOrdenados = new List<int>();

            foreach (int i in indices)
            {
                productosOrdenados.Add(productos[i]);
                preciosOrdenados.Add(precios[i]);
            }

            productos = productosOrdenados;
            precios = preciosOrdenados;

            Console.WriteLine("Productos ordenados alfabeticamente");

            MostrarProducto();
        }

    }
}
