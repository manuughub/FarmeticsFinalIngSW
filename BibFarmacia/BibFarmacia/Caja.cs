using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Caja
    {
        //Atributos
        private List<Movimiento> movSalidas;

        //Constructor
        public Caja(List<Movimiento> movSalidas)
        {
            this.movSalidas = movSalidas;
        }

        //Accesores
        internal List<Movimiento> MovSalidas { get => movSalidas; set => movSalidas = value; }


        //Metodos
        public List <Movimiento> RegistrarVentas(List<Producto> ventas, ushort cantidadProducto)
        {
            try
            {
                foreach (Producto elemento in ventas)
                {
                    Movimiento SalidaProductos = new Movimiento(elemento, cantidadProducto, 'S', DateTime.Today);
                    movSalidas.Add(SalidaProductos);
                }
                return movSalidas;
            }
            catch (Exception)
            {
                throw new Exception("Error registrando ventas en caja");
            }
        }
    }
}
