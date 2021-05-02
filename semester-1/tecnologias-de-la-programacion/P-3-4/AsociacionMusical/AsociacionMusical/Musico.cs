// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace AsociacionMusical
{
    public abstract class Musico
    {
        protected string Nombre { get; }

        protected Musico(string nombre)
        {
            Nombre = nombre;
        }

        public virtual string ComoTeLlamas()
        {
            return "No Tengo Nombre";
        }

        public abstract void ImprimirDatos();
    }
}