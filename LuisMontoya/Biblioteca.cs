using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    internal class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();

        //AGREGAR
        public void AgregarLibro()
        {
            Console.WriteLine("*** Ingrese los detalles del libro ***");
            Console.Write("Digite el código: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite el título: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite el nombre del autor: ");
            string autor = Console.ReadLine();
            Console.Write("Digite la fecha de publicación: ");
            string fechaPublicacion = Console.ReadLine();
            Console.Write("Digite el precio: ");
            double precio = Convert.ToDouble(Console.ReadLine());
            Console.Write("Disponible (Si/No): ");
            bool disponible = Console.ReadLine().Equals("Si", StringComparison.OrdinalIgnoreCase);

            Libro nuevoLibro = new Libro(codigo, titulo, autor, fechaPublicacion, precio, disponible);
            libros.Add(nuevoLibro);

            Console.WriteLine("Libro agregado con exito a la biblioteca.");
        }

        // ELIMINAR
        public void EliminarLibro()
        {
            Console.WriteLine("Ingrese el código del libro que desea eliminar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            Libro libroAEliminar = libros.Find(libro => libro.Codigo == codigo);
            if (libroAEliminar != null)
            {
                Console.WriteLine("El libro fue encontrado, Desea eliminar el libro? S/N");
                string si = Console.ReadLine();
                if (si == "S")
                {
                    libros.Remove(libroAEliminar);
                    Console.WriteLine("Libro eliminado exitosamente de la biblioteca.");
                }
                else
                {
                    Console.WriteLine("Libro no Eliminado.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró ningún libro con el código ingresado.");
            }
        }

        // MOSTRAR LIBROS
        public void MostrarLibros()
        {
            Console.WriteLine("************** Libros almacenados en la biblioteca **************");
            foreach (var libro in libros)
            {
                Console.WriteLine($"Código: {libro.Codigo}, Título: {libro.Titulo}, Autor: {libro.Autor}, Fecha Publicacion: {libro.FechaPublicacion}, Precio: {libro.Precio}, Disponible: {(libro.Disponible ? "Sí" : "No")}");
            }
        }

        //LIBRO MAYOR PRECIO
        public void LibroMayorPrecio()
        {
            if (libros.Count > 0)
            {
                Libro libroMayorPrecio = libros[0];
                foreach (var libro in libros)
                {
                    if (libro.Precio > libroMayorPrecio.Precio)
                    {
                        libroMayorPrecio = libro;
                    }
                }
                Console.WriteLine("Libro de mayor precio:");
                Console.WriteLine($"Código: {libroMayorPrecio.Codigo}");
                Console.WriteLine($"Título: {libroMayorPrecio.Titulo}");
                Console.WriteLine($"Autor: {libroMayorPrecio.Autor}");
                Console.WriteLine($"Fecha Publicacion: {libroMayorPrecio.FechaPublicacion}");
                Console.WriteLine($"Precio: {libroMayorPrecio.Precio:C}");
                Console.WriteLine($"Disponible: {(libroMayorPrecio.Disponible ? "Sí" : "No")}");
            }
            else
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
        }

        //LIBROS MAS BARATOS
        public void TresLibrosBaratos()
        {
            if (libros.Count > 0)
            {
                List<Libro> librosOrdenadosBarato = libros.OrderBy(libro => libro.Precio).ToList();
                Console.WriteLine("Tres libros más baratos:");
                for (int i = 0; i < Math.Min(3, librosOrdenadosBarato.Count); i++)
                {
                    Libro libro = librosOrdenadosBarato[i];
                    Console.WriteLine($"Código: {libro.Codigo}, Título: {libro.Titulo}, Autor: {libro.Autor}, Precio: {libro.Precio:C}");
                }
            }
            else
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
        }


        //ENCONTRAR LIBRO POR AUTOR

        public void BuscarPorAutor(string inicioNomAutor)
        {
            List<Libro> librosCoincidentes = libros.FindAll(libro => libro.Autor.StartsWith(inicioNomAutor, StringComparison.OrdinalIgnoreCase));
            if (librosCoincidentes.Count > 0)
            {
                Console.WriteLine($"Libros cuyo autor empieza con '{inicioNomAutor}':");
                foreach (var libro in librosCoincidentes)
                {
                    libro.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron libros en su busqueda.");
            }
        }


        //      MENU
        public void Menu()
        {
            int opcion;
            do
            {
                Console.Clear(); // Limpia la pantalla antes de mostrar el menú
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("Menú Principal");
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("1. Agregar un libro a la biblioteca");
                Console.WriteLine("2. Eliminar un libro de la biblioteca");
                Console.WriteLine("3. Mostrar todos los libros de la biblioteca");
                Console.WriteLine("4. Mostrar libro de mayor precio");
                Console.WriteLine("5. Mostrar los tres libros más baratos");
                Console.WriteLine("6. Buscar libros por inicio del nombre del autor");
                Console.WriteLine("7. Salir del programa");
                Console.WriteLine(new string('-', 30));
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    opcion = 0; // Asignar un valor que mantenga el bucle en caso de entrada inválida.
                    Console.ReadKey(); // Pausa antes de limpiar la pantalla.
                }
                else
                {
                    Console.Clear(); // Limpia la pantalla antes de ejecutar la opción.
                    switch (opcion)
                    {
                        case 1:
                            AgregarLibro();
                            break;
                        case 2:
                            EliminarLibro();
                            break;
                        case 3:
                            MostrarLibros();
                            break;
                        case 4:
                            LibroMayorPrecio();
                            break;
                        case 5:
                            TresLibrosBaratos();
                            break;
                        case 6:
                            Console.WriteLine("Ingrese el inicio del nombre del autor:");
                            string inicioNomAutor = Console.ReadLine();
                            BuscarPorAutor(inicioNomAutor);
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                            break;
                    }
                    if (opcion != 7) // No limpiar la pantalla inmediatamente si el usuario elige salir.
                    {
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            } while (opcion != 7);
        }




    }
}
