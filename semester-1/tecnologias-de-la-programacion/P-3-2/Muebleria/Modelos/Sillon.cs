// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Muebleria.Modelos
{
    public class Sillon : Asiento
    {
        public int CapacidadPersonas { get; set; }

        public Sillon(string fabricante, float peso, float costo, float altura, int capacidadPersonas) : base(
            fabricante, peso, costo, altura)
        {
            CapacidadPersonas = capacidadPersonas;
        }

        public override void Imprime()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Sillón");
            Console.WriteLine();

            Console.WriteLine("Datos de Mueble:");
            Console.WriteLine($"{Fabricante}, {Peso}, {Costo} y {Altura}");
            Console.WriteLine($"{CapacidadPersonas}");
        }
    }
}