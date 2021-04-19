// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo


using System;
using System.Collections.Generic;
using Publicacion.Modelos;

namespace Publicacion
{
    public static class Program
    {
        public static void Main()
        {
            Libro libro = CrearLibro();
            libro.Imprime();

            AlterarLibro(libro);
            libro.Imprime();

            Periodico periodico = CrearPeriodico();
            periodico.Imprime();
            Console.WriteLine($"Se contaron {periodico.ContarSecciones()} secciones.");

            AlterarPeriodico(periodico);
            periodico.Imprime();
            Console.WriteLine($"Se contaron {periodico.ContarSecciones()} secciones.");

            Revista revista = CrearRevista();
            revista.Imprime();

            Console.WriteLine("Presione cualquier tecla para continuar . . .");
            Console.ReadKey();
        }

        private static Libro CrearLibro()
        {
            const int numPag = 10;
            const string titulo = "Cómo Acreditar la Materia";
            const float precio = (float) 500.00;
            const string tipoDePortada = "Pasta de la Cara";
            const int isbn = 2344567;
            const string autor = "Ian A. Ruiz";
            const string editorial = "Publícamelo";


            return new Libro(numPag, titulo, precio, tipoDePortada, isbn, autor, editorial);
        }

        private static void AlterarLibro(Libro libro)
        {
            libro.Autor = "Emiliano Zapata";
            libro.TipoDePortada = "Hoja";
        }

        private static Periodico CrearPeriodico()
        {
            const int numPag = 5;
            const string titulo = "La mañanera";
            const float precio = (float) 5.00;

            List<string> secciones = new()
            {
                "Las de Hoy",
                "Las Travesuras",
                "Sociales y Otras Mentiras",
                "Servicios y Otros"
            };

            return new Periodico(numPag, titulo, precio, secciones);
        }

        private static void AlterarPeriodico(Periodico periodico)
        {
            periodico.NumPag = 40;
            periodico.Precio = (float) 800.00;
            periodico.Secciones.Add("Diputados Fantásticos y Dónde Encontarlos");
            periodico.Secciones.Add("Are you some kind of politician or clown?");
        }

        private static Revista CrearRevista()
        {
            const int numPag = 5;
            const string titulo = "La mañanera";
            const float precio = (float) 5.00;
            const int numero = 98;
            const int volumen = 3;
            const int mes = 13;
            const string editorial = "No Me Creas";

            return new Revista(numPag, titulo, precio, numero, volumen, mes, editorial);
        }
    }
}