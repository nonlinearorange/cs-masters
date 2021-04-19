// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Publicacion.Modelos
{
    public class Libro : Publicacion
    {
        public string TipoDePortada { get; set; }
        
        public int Isbn { get; set; }
        
        public string Autor { get; set; }
        
        public string Editorial { get; set; }

        public Libro(int numPag, string titulo, float precio, string tipoDePortada, int isbn, string autor,
            string editorial) : base(numPag, titulo, precio)
        {
            TipoDePortada = tipoDePortada;
            Isbn = isbn;
            Autor = autor;
            Editorial = editorial;
        }

        public override void Imprime()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Datos de Libro");
            Console.WriteLine("-------------------------------------------------------------");
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            Console.WriteLine($"Datos de Publicación: {NumPag}, {Titulo}, {Precio}");
            Console.WriteLine($"Libro: {TipoDePortada}, {Isbn}, {Autor} y {Editorial}");
        }
    }
}