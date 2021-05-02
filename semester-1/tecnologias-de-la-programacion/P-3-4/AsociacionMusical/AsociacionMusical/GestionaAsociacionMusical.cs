// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace AsociacionMusical
{
    public static class GestionaAsociacionMusical
    {
        public static void Main()
        {
            Musico m1 = new Coros("Juan")
            {
                TipoDeVoz = (int) TipoDeVoz.Sopranos
            };
            Musico m2 = new Coros("María")
            {
                TipoDeVoz = (int) TipoDeVoz.Contraalto
            };
            Musico m3 = new Coros("José")
            {
                TipoDeVoz = (int) TipoDeVoz.Tenores
            };
            Musico m4 = new Coros("Rafael")
            {
                TipoDeVoz = (int) TipoDeVoz.Bajos
            };
            Musico m5 = new Coros("Raquel")
            {
                TipoDeVoz = (int) TipoDeVoz.Sopranos
            };
            Musico m6 = new Instrumentista("Paco")
            {
                Instrumento = "Fagot"
            };
            Musico m7 = new Instrumentista("Rocío")
            {
                Instrumento = "Oboe"
            };

            AsociacionMusical asociacion = new AsociacionMusical("La Pachanga");
            asociacion.AnadirMiembros(m1);
            asociacion.AnadirMiembros(m2);
            asociacion.AnadirMiembros(m3);
            asociacion.AnadirMiembros(m4);
            asociacion.AnadirMiembros(m5);
            asociacion.AnadirMiembros(m6);
            asociacion.AnadirMiembros(m7);

            asociacion.ImprimirDatos();

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar . . .");
            Console.ReadKey();
        }
    }
}