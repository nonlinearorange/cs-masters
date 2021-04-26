// ReSharper disable IdentifierTypo

using System;
using System.Collections.Generic;
using Pago.Converter;

namespace Pago
{
    public class ConversorDeDivisa : IConversorDeDivisa
    {
        public float Convertir(float cantidad, TipoDeDivisa desde, TipoDeDivisa destino)
        {
            BaseConversorDeDivisa baseConversor = GetConverter(desde, destino);
            return baseConversor.Convertir(cantidad);
        }

        private static BaseConversorDeDivisa GetConverter(TipoDeDivisa d1, TipoDeDivisa d2)
        {
            return d1 switch
            {
                TipoDeDivisa.Dolar when d2 == TipoDeDivisa.Peso => new DolarAPeso(),
                TipoDeDivisa.Peso when d2 == TipoDeDivisa.Dolar => new PesoADolar(),
                _ => throw new NotImplementedException()
            };
        }
    }
}