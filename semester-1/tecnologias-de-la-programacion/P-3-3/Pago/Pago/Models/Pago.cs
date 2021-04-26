// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo


using System;

namespace Pago.Models
{
    public abstract class Pago
    {
        public string Moneda { get; set; }

        public DateTime Fecha { get; set; }

        public float Cantidad { get; set; }

        public virtual void Imprimir()
        {
        }

        public abstract float CalcularTipo();
    }
}