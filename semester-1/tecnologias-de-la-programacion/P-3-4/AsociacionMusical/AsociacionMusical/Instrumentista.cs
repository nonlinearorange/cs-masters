// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace AsociacionMusical
{
    public class Instrumentista : Musico, IQuienEs
    {
        public string Instrumento { set; get; }

        public Instrumentista(string nombre) : base(nombre)
        {
        }

        public bool SiCantas()
        {
            return false;
        }

        public override string ComoTeLlamas()
        {
            return Nombre;
        }

        public override void ImprimirDatos()
        {
            Console.WriteLine($"{ComoTeLlamas()} toca el {Instrumento}.");
        }
    }
}