// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;
using System.Collections.Generic;

namespace Publicacion.Modelos
{
    public class Periodico : Publicacion
    {
        public List<string> Secciones { get; }

        public Periodico(int numPag, string titulo, float precio, List<string> secciones) : base(numPag, titulo, precio)
        {
            Secciones = secciones;
        }

        public override void Imprime()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Datos de Periódico");
            Console.WriteLine("-------------------------------------------------------------");
            MostrarDatos();
            Console.WriteLine("Secciones de Periódico:");
            foreach (string seccion in Secciones)
            {
                Console.WriteLine($"Sección: {seccion}");
            }
        }

        private void MostrarDatos()
        {
            Console.WriteLine($"Datos de Publicación: {NumPag}, {Titulo}, {Precio}");
        }

        public int ContarSecciones()
        {
            return Secciones.Count;
        }
    }
}