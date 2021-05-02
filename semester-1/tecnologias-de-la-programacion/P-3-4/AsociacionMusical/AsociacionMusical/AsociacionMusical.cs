// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

using System;
using System.Collections.Generic;

// using System.Linq;

namespace AsociacionMusical
{
    public class AsociacionMusical
    {
        private string Nombre { get; }

        private int NumMiembrosCoro { get; set; }

        private int NumMiembrosOrquesta { get; set; }

        private List<Musico> Musicos { get; }

        public AsociacionMusical(string nombre)
        {
            Nombre = nombre;
            Musicos = new List<Musico>();
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Asociación: {Nombre}");
            Console.WriteLine($"Miembros del Coro: {NumMiembrosCoro}");
            Console.WriteLine($"Miembros del Miembros de la Orquesta: {NumMiembrosOrquesta}");

            foreach (Musico musico in Musicos)
            {
                musico.ImprimirDatos();
            }
        }

        public void AnadirMiembros(Musico musico)
        {
            ActualizarConteo(musico);
            Musicos.Add(musico);
        }

        private void ActualizarConteo(Musico musico)
        {
            switch (musico)
            {
                case Coros _:
                    NumMiembrosCoro += 1;
                    break;
                case Instrumentista _:
                    NumMiembrosOrquesta += 1;
                    break;
            }
        }

        // Para fines de la práctica.
        // private void ContarMusicos()
        // {
        //     foreach (IQuienEs musico in Musicos.Cast<IQuienEs>())
        //     {
        //         if (musico.SiCantas())
        //         {
        //             NumMiembrosCoro += 1;
        //         }
        //         else
        //         {
        //             NumMiembrosOrquesta += 1;
        //         }
        //     }
        // }
    }
}