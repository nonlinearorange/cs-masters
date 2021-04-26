// ReSharper disable IdentifierTypo

namespace Pago.Converter
{
    public class DolarAPeso : BaseConversorDeDivisa
    {
        public override float Convertir(float cantidad)
        {
            return (float) (cantidad * 19.95);
        }
    }
}