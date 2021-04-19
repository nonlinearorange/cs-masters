// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;
using Muebleria.Modelos;

namespace Muebleria
{
    public static class Program
    {
        public static void Main()
        {
            MesaCircular mesaCircular = CrearMesaCircular();
            mesaCircular.Imprime();

            AlterarMesaCircular(mesaCircular);
            mesaCircular.Imprime();

            MesaRectangular mesaRectangular = CrearMesaRectangular();
            mesaRectangular.Imprime();

            AlterarMesaRectangular(mesaRectangular);
            mesaRectangular.Imprime();

            Silla silla = CrearSilla();
            silla.Imprime();

            Sillon sillon = CrearSillon();
            sillon.Imprime();

            Taburete taburete = CrearTaburete();
            taburete.Imprime();

            Console.WriteLine("Presione cualquier tecla para continuar . . .");
            Console.ReadKey();
        }

        private static MesaCircular CrearMesaCircular()
        {
            const string fabricante = "Muebles Troncoso";
            const float peso = (float) 40.0;
            const float costo = (float) 5000.00;
            const float altura = (float) 1.5;
            const float diametro = (float) 3.0;

            return new MesaCircular(fabricante, peso, costo, altura, diametro);
        }

        private static void AlterarMesaCircular(MesaCircular mesa)
        {
            mesa.Peso = (float) 40.0;
            mesa.Diametro = (float) 100.0;
            mesa.Costo = (float) 333.00;
        }

        private static MesaRectangular CrearMesaRectangular()
        {
            const string fabricante = "Muebles Troncoso";
            const float peso = (float) 40.0;
            const float costo = (float) 20000.00;
            const float altura = (float) 1.0;
            const float ancho = (float) 40.0;
            const float alto = (float) 20.0;
            return new MesaRectangular(fabricante, peso, costo, altura, ancho, alto);
        }

        private static void AlterarMesaRectangular(MesaRectangular mesa)
        {
            mesa.Alto = (float) 75.0;
            mesa.Ancho = (float) 63.0;
            mesa.Costo = (float) 70000.0;
        }

        private static Silla CrearSilla()
        {
            const string fabricante = "La Más Barata";
            const float peso = (float) 75.0;
            const float costo = (float) 10.0;
            const float altura = (float) 1.2;
            const int numBrazos = 8;

            return new Silla(fabricante, peso, costo, altura, numBrazos);
        }

        private static Sillon CrearSillon()
        {
            const string fabricante = "El Coppel";
            const float peso = (float) 40.0;
            const float costo = (float) (400.0 * 48.0);
            const float altura = (float) 0.5;
            const int capacidadPersonas = 45;

            return new Sillon(fabricante, peso, costo, altura, capacidadPersonas);
        }

        private static Taburete CrearTaburete()
        {
            const string fabricante = "Fabricas de Farancia";
            const float peso = (float) 0.5;
            const float costo = (float) 120000000000.00;
            const float altura = (float) 0.5;
            const int numPatas = 1;
            return new Taburete(fabricante, peso, costo, altura, numPatas);
        }
    }
}