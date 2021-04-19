// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace Muebleria.Modelos
{
    public abstract class Mueble
    {
        public string Fabricante { get; set; }
        
        public float Peso { get; set; }
        
        public float Costo { get; set; }
        
        public float Altura { get; set; }

        protected Mueble(string fabricante, float peso, float costo, float altura)
        {
            Fabricante = fabricante;
            Peso = peso;
            Costo = costo;
            Altura = altura;
        }

        public abstract void Imprime();
    }
}