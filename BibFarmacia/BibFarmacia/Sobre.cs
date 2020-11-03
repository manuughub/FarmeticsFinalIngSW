using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Sobre: Medicamento
    {
        //Atributos
        private uint peso;

        //Constructor
        public Sobre(string nombre, char tipoAlmacenamiento, string laboratorio, ulong precioVenta, string fechaVencimiento, uint peso)
            :base (nombre, tipoAlmacenamiento,laboratorio,precioVenta,fechaVencimiento)
        {
            this.peso = peso;
        }

        //Accesores
        public uint Peso
        {
            get
            {
                try
                {
                    if (peso > 0)
                        return peso;
                    else
                    {
                        peso = 0;
                        return peso;
                    }
                }
                
                catch (Exception)
                {
                    peso = 0;
                    return peso;
                }
            }
        }

        //Metodos
        public override string ToString()
        {
            return "|"+ TipoAlmacenamiento + "| "+ Nombre + " " + Laboratorio + " "+ peso+"g " + " FV" + FechaVencimiento + " $" + PrecioVenta;
        }
    }
}
