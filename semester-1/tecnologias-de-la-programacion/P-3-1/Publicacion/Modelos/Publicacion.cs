// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace Publicacion.Modelos
{
    public abstract class Publicacion
    {
        public int NumPag { get; set; }
        public string Titulo { get; set; }
        public float Precio { get; set; }

        protected Publicacion(int numPag, string titulo, float precio)
        {
            NumPag = numPag;
            Titulo = titulo;
            Precio = precio;
        }

        public abstract void Imprime();
    }
}