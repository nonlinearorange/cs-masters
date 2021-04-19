// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace Muebleria.Modelos
{
    public abstract class Mesa : Mueble
    {
        protected Mesa(string fabricante, float peso, float costo, float altura) : base(fabricante, peso, costo, altura)
        {
        }
    }
}