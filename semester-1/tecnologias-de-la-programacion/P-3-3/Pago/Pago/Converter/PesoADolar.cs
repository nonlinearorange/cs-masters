// ReSharper disable IdentifierTypo

namespace Pago.Converter
{
    public class PesoADolar : BaseConversorDeDivisa
    {
        public override float Convertir(float cantidad)
        {
            return (float) (cantidad / 19.95);
        }
    }
}