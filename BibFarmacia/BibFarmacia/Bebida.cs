using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Bebida : Producto
    {
        //Atributos
        private uint cantidadCc;
        private string tipoEnvase;

        //Constructor
        public Bebida(string nombre, char tipoAlmacenamiento, uint cantidadCc, string tipoEnvase)
            : base(nombre, tipoAlmacenamiento)
        {
            this.cantidadCc = cantidadCc;
            this.tipoEnvase = tipoEnvase;
        }

        //Accesores
        public uint CantidadCc
        {
            get
            {
                try
                {
                    if (cantidadCc > 0)
                        return cantidadCc;
                    else
                    {
                        cantidadCc = 0;
                        return cantidadCc;
                    }
                }
                catch (Exception)
                {
                    cantidadCc = 0;
                    return cantidadCc;
                }

            }
        }
        public string TipoEnvase { get => tipoEnvase;}

        public override string ToString()
        {
            return "|" + TipoAlmacenamiento + "| " + Nombre + " "+cantidadCc+" cc";
        }
    }
}
