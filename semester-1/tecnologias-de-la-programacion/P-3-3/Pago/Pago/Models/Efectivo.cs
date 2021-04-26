// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;
using System.Collections.Generic;

namespace Pago.Models
{
    public class Efectivo : Pago
    {
        public float CantEfvo { get; set; }

        public string MonedaEfvo { get; set; }

        public float CalcularCambio()
        {
            return Cantidad - CantEfvo;
        }

        public override float CalcularTipo()
        {
            IConversorDeDivisa conversor = new ConversorDeDivisa();
            return conversor.Convertir(CantEfvo, TipoATexto(MonedaEfvo), TipoATexto(Moneda));
        }

        private static TipoDeDivisa TipoATexto(string valor)
        {
            Dictionary<string, TipoDeDivisa> diccionario = new Dictionary<string, TipoDeDivisa>
            {
                {$"{TipoDeDivisa.Dolar}", TipoDeDivisa.Dolar},
                {$"{TipoDeDivisa.Peso}", TipoDeDivisa.Peso}
            };

            return diccionario[valor];
        }

        public override void Imprimir()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Efectivo");
            Console.WriteLine();
            Console.WriteLine($"Moneda: ${Moneda}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Cantidad: ${Cantidad}");
            Console.WriteLine();
            Console.WriteLine($"Moneda: {MonedaEfvo}");
            Console.WriteLine($"Cantidad de Efectivo: ${CantEfvo}");
        }
    }
}