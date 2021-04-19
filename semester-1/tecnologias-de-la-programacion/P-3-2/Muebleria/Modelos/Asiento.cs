// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace Muebleria.Modelos
{
    public abstract class Asiento : Mueble
    {
        protected Asiento(string fabricante, float peso, float costo, float altura) : base(fabricante, peso, costo,
            altura)
        {
        }
    }
}