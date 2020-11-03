using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Tableta: Medicamento
    {
        //Atributos
        private uint miligramos;
        private uint cantidadTabletas;

        //Constructor
        public Tableta(string nombre, char tipoAlmacenamiento, string laboratorio, ulong precioVenta, string fechaVencimiento,uint miligramos, uint cantidadTabletas)
            :base(nombre, tipoAlmacenamiento, laboratorio, precioVenta, fechaVencimiento)
        {
            this.miligramos = miligramos;
            this.cantidadTabletas = cantidadTabletas;
        }

        //Accesores
        public uint Miligramos
        {
            get
            {
                try
                {
                    if (miligramos > 0)
                        return miligramos;
                    else
                    {
                        miligramos = 0;
                        return miligramos;
                    }
                }
                catch (Exception)
                {
                    miligramos = 0;
                    return miligramos;
                }
                

            }
        }
        public uint CantidadTabletas
        {
            get
            {
                try
                {
                    if (cantidadTabletas > 0)
                        return cantidadTabletas;
                    else
                    {
                        cantidadTabletas = 0;
                        return cantidadTabletas;
                    }
                }
                catch (Exception)
                {
                    cantidadTabletas = 0;
                    return cantidadTabletas;
                }
                

            }
        }

        //Metodos
        public override string ToString()
        {
            return "|" + TipoAlmacenamiento + "| " + Nombre + " " + Laboratorio + " " + cantidadTabletas+ "t "+ miligramos + "mg " +" FV" + FechaVencimiento + " $" + PrecioVenta;
        }

    }
}
