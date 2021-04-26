// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;
using Pago.Models;

namespace Pago
{
    public static class Program
    {
        public static void Main()
        {
            Credito credito = CrearCredito();
            PagarCredito(credito);

            Efectivo efectivo = CrearEfectivo();
            PagarEfectivo(efectivo);

            Vales vales = CrearVales();
            PagarVales(vales);

            Especie especie = CrearEspecie();
            PagarEspecie(especie);
        }

        private static Credito CrearCredito()
        {
            return new Credito
            {
                NumTarjeta = 23454345,
                Fecha = DateTime.Now,
                Cantidad = 500,
                Moneda = $"{TipoDeDivisa.Dolar}",
                Titular = "Ian Ruiz",
                Saldo = (float) 900.0
            };
        }

        private static void PagarCredito(Credito credito)
        {
            credito.Imprimir();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Pago de Crédito");
            Console.WriteLine();

            Console.WriteLine($"Balance: ${credito.Balance()}");
            credito.CargarSaldo((float) 50.0);
            Console.WriteLine($"Balance: ${credito.Balance()}");
        }

        private static Efectivo CrearEfectivo()
        {
            return new Efectivo
            {
                Cantidad = (float) 100.0,
                Fecha = DateTime.Now,
                Moneda = $"{TipoDeDivisa.Peso}",
                CantEfvo = (float) 43.0,
                MonedaEfvo = $"{TipoDeDivisa.Dolar}"
            };
        }

        private static void PagarEfectivo(Efectivo efectivo)
        {
            efectivo.Imprimir();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Pago de Efectivo");
            Console.WriteLine();

            float cambio = efectivo.CalcularCambio();
            Console.WriteLine($"Cambio: ${cambio}");
        }

        private static Especie CrearEspecie()
        {
            return new Especie
            {
                Cantidad = 50,
                Descripcion = "Comida",
                Fecha = DateTime.Now,
                Moneda = $"{TipoDeDivisa.Peso}",
                Monto = (float) 75.0
            };
        }

        private static void PagarEspecie(Especie especie)
        {
            especie.Imprimir();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Pago de Especie");
            Console.WriteLine();

            float valor = especie.ExtraerValor();
            Console.WriteLine($"Valor: ${valor}");
        }

        private static Vales CrearVales()
        {
            return new Vales
            {
                Cantidad = (float) 498.0,
                Fecha = DateTime.Now,
                Folio = 345456,
                Moneda = $"{TipoDeDivisa.Peso}",
                Monto = (float) 40.0
            };
        }

        private static void PagarVales(Vales vales)
        {
            vales.Imprimir();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Pago de Vales");
            Console.WriteLine();

            float pago = vales.CalcularPago();
            Console.WriteLine($"Pago: ${pago}");
        }
    }
}