using LuisMontoya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LuisMontoya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de Biblioteca.");
            //Libro miLibro = new Libro(1234, "El señor de los anillos", "J.R.R. Tolkien", "1954, 7, 29", 25.99, true);

            // Mostrar la información del libro

            Biblioteca biblioteca = new Biblioteca();
            biblioteca.Menu();
        }
    }
}
