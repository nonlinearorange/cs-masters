// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Muebleria.Modelos
{
    public class Taburete : Asiento
    {
        public int NumPatas { get; set; }

        public Taburete(string fabricante, float peso, float costo, float altura, int numPatas) : base(fabricante, peso,
            costo,
            altura)
        {
            NumPatas = numPatas;
        }

        public override void Imprime()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Taburete");
            Console.WriteLine();

            Console.WriteLine("Datos de Mueble:");
            Console.WriteLine($"{Fabricante}, {Peso}, {Costo} y {Altura}");
            Console.WriteLine($"{NumPatas}");
        }
    }
}