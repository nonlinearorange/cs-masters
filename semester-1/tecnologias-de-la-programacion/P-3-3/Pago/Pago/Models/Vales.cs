// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace Pago.Models
{
    public class Vales : Pago
    {
        public int Folio { get; set; }

        public float Monto { get; set; }

        public float CalcularPago()
        {
            return Cantidad - Monto;
        }

        public override float CalcularTipo()
        {
            throw new NotImplementedException();
        }

        public override void Imprimir()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Vales");
            Console.WriteLine();
            Console.WriteLine($"Moneda: {Moneda}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Cantidad: ${Cantidad}");
            Console.WriteLine();
            Console.WriteLine($"{Folio}");
            Console.WriteLine($"${Monto}");
        }
    }
}