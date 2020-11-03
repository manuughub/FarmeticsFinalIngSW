using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Movimiento
    {
        //Atributos
        private Producto producto;
        private ushort cantidadProductos;
        private char tipoMovimiento;
        private DateTime fecha;

        //Constructor
        public Movimiento(Producto producto, ushort cantidadProductos, char tipoMovimiento, DateTime fecha)
        {
            this.producto = producto;
            this.cantidadProductos = cantidadProductos;
            this.tipoMovimiento = tipoMovimiento;
            this.fecha = fecha;
        }

        //Accesores
        public ushort CantidadProductos
        {
            get
            {
                return cantidadProductos;
            }
            set
            {
                try
                {
                    if (cantidadProductos > 0)
                        cantidadProductos = value;
                    else
                        cantidadProductos = 0;
                }
                catch (Exception)
                {
                    cantidadProductos = 0;
                }
               
            }
        }
        public DateTime Fecha { get => fecha;}

        public char TipoMovimiento { get => tipoMovimiento;}
        public Producto Producto { get => producto; set => producto = value; }

        //Metodos
        public override string ToString()
        {
            return producto +" "+ fecha.ToShortDateString() + " |" + tipoMovimiento + "| "+"|" +cantidadProductos+"|";
        }
    }
}
