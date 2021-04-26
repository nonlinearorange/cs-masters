// ReSharper disable IdentifierTypo

namespace Pago
{
    public interface IConversorDeDivisa
    {
        public float Convertir(float cantidad, TipoDeDivisa desde, TipoDeDivisa destino);
    }
}