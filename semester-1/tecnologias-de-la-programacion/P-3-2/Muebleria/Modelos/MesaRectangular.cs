// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Muebleria.Modelos
{
    public class MesaRectangular : Mesa
    {
        public float Ancho { get; set; }

        public float Alto { get; set; }

        public MesaRectangular(string fabricante, float peso, float costo, float altura, float ancho, float alto) :
            base(fabricante, peso, costo,
                altura)
        {
            Ancho = ancho;
            Alto = alto;
        }

        public override void Imprime()
        {
            Imprimir();
        }

        public float Superficie()
        {
            return Ancho * Alto;
        }

        private void Imprimir()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Mesa Rectangular");
            Console.WriteLine();

            Console.WriteLine("Datos de Mueble:");
            Console.WriteLine($"{Fabricante}, {Peso}, {Costo} y {Altura}");
            Console.WriteLine($"{Ancho}, {Alto}, {Superficie()}");
        }
    }
}