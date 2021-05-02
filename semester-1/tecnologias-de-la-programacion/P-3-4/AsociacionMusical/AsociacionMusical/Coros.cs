// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

using System;

namespace AsociacionMusical
{
    public class Coros : Musico, IQuienEs
    {
        public int TipoDeVoz { get; set; }

        public Coros(string nombre) : base(nombre)
        {
        }

        public bool SiCantas()
        {
            return true;
        }

        public override string ComoTeLlamas()
        {
            return Nombre;
        }

        public override void ImprimirDatos()
        {
            string tipoDeCuerda = $"{(TipoDeVoz) TipoDeVoz}".ToLower();
            Console.WriteLine($"{ComoTeLlamas()} canta en la cuerda de {tipoDeCuerda}.");
        }
    }
}