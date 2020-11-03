using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Liquido: Medicamento
    {
        //Atributos
        private uint mililitros;

        //Constructor
        public Liquido(string nombre, char tipoAlmacenamiento, string laboratorio, ulong precioVenta, string fechaVencimiento,uint mililitros)
            : base (nombre, tipoAlmacenamiento, laboratorio, precioVenta, fechaVencimiento)
        {
            this.mililitros = mililitros;
        }

        //Accesores
        public uint Mililitros
        {
            get
            {
                try
                {
                    if (mililitros > 0)
                        return mililitros;
                    else
                    {
                        mililitros = 0;
                        return mililitros;
                    }

                }
                catch (Exception)
                {
                    mililitros = 0;
                    return mililitros;
                }
                }
                
        }

        //Metodos
        public override string ToString()
        {
            return "|" + TipoAlmacenamiento + "| " + Nombre + " " + Laboratorio + " " + mililitros + "ml "  + " FV" + FechaVencimiento + " $" + PrecioVenta;
        }

    }
}
