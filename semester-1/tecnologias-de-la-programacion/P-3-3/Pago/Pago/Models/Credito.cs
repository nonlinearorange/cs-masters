// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo


using System;

namespace Pago.Models
{
    public class Credito : Pago
    {
        public int NumTarjeta { get; set; }

        public string Titular { get; set; }

        public float Saldo { get; set; }

        public Credito()
        {
            Saldo = 0;
        }

        public float Balance()
        {
            return Saldo;
        }

        public float CargarSaldo(float valor)
        {
            Saldo -= valor;
            return Saldo;
        }

        public override float CalcularTipo()
        {
            throw new NotImplementedException();
        }

        public override void Imprimir()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Credito");
            Console.WriteLine();
            Console.WriteLine($"Moneda: {Moneda}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Cantidad: ${Cantidad}");
            Console.WriteLine();
            Console.WriteLine($"Número de Tarjeta: {NumTarjeta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: ${Saldo}");
        }
    }
}