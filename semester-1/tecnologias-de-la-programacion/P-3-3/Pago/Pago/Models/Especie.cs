// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo


using System;

namespace Pago.Models
{
    public class Especie : Pago
    {
        public string Descripcion { get; set; }

        public float Monto { get; set; }

        public float ExtraerValor()
        {
            Monto = Descripcion switch
            {
                "Comida" => (float) 40.0,
                "Joyeria" => (float) 1000.0,
                _ => Monto
            };

            return Monto;
        }

        public override float CalcularTipo()
        {
            throw new NotImplementedException();
        }

        public override void Imprimir()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Especie");
            Console.WriteLine();
            Console.WriteLine($"Moneda: {Moneda}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Cantidad: ${Cantidad}");
            Console.WriteLine();
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Monto: ${Monto}");
        }
    }
}