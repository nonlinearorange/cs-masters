// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Muebleria.Modelos
{
    public class MesaCircular : Mesa
    {
        public float Diametro { get; set; }

        public MesaCircular(string fabricante, float peso, float costo, float altura, float diametro) : base(fabricante,
            peso, costo,
            altura)
        {
            Diametro = diametro;
        }

        public override void Imprime()
        {
            Imprimir();
        }

        public float Superficie()
        {
            return (float) (Math.PI * Diametro);
        }

        private void Imprimir()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Mesa Circular");
            Console.WriteLine();

            Console.WriteLine("Datos de Mueble:");
            Console.WriteLine($"{Fabricante}, {Peso}, {Costo} y {Altura}");
            Console.WriteLine($"{Diametro}, {Superficie()}");
        }
    }
}