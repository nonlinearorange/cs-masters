// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Muebleria.Modelos
{
    public class Silla : Asiento
    {
        public int NumBrazos { get; set; }

        public Silla(string fabricante, float peso, float costo, float altura, int numBrazos) : base(fabricante, peso,
            costo, altura)
        {
            NumBrazos = numBrazos;
        }

        public override void Imprime()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Silla");
            Console.WriteLine();

            Console.WriteLine("Datos de Mueble:");
            Console.WriteLine($"{Fabricante}, {Peso}, {Costo} y {Altura}");
            Console.WriteLine($"{NumBrazos}");
        }
    }
}