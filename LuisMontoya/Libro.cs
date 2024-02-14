using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    internal class Libro : ILibro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string FechaPublicacion { get; set; }
        public double Precio { get; set; }
        public bool Disponible { get; set; }

        public Libro(int codigo, string titulo, string autor, string fechaPublicacion, double precio, bool disponible)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            FechaPublicacion = fechaPublicacion;
            Precio = precio;
            Disponible = disponible;
        }

        public void Prestar()
        {
            Console.WriteLine("El libro ha sido prestado.");
        }
        public void Devolver()
        {
            Console.WriteLine("El libro ha sido devuelto.");
        }
        public void Consultar()
        {
            MostrarInformacion();
        }



 
        public void MostrarInformacion()
        {
            Console.WriteLine("**** Información del Libro ****");
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Título: " + Titulo);
            Console.WriteLine("Autor: " + Autor);
            Console.WriteLine("Fecha de Publicación: " + FechaPublicacion);
            Console.WriteLine("Precio: " + Precio.ToString("C"));
            Console.WriteLine("Disponible: " + (Disponible ? "Sí" : "No"));
        }
    }
}
