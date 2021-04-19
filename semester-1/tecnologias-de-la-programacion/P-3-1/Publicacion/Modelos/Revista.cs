// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Publicacion.Modelos
{
    public class Revista : Publicacion
    {
        public int Numero { get; set; }
        public int Volumen { get; set; }
        public int Mes { get; set; }
        public string Editorial { get; set; }

        public Revista(int numPag, string titulo, float precio, int numero, int volumen, int mes, string editorial) :
            base(numPag, titulo, precio)
        {
            Numero = numero;
            Volumen = volumen;
            Mes = mes;
            Editorial = editorial;
        }

        public override void Imprime()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Datos de Revista");
            Console.WriteLine("-------------------------------------------------------------");
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            Console.WriteLine($"Datos de Publicación: {NumPag}, {Titulo}, {Precio}");
            Console.WriteLine($"Datos de Revista: {Numero}, {Volumen}, {Mes}, {Editorial}");
        }
    }
}