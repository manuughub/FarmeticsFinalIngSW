using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Bodega
    {
        //Atributos
        private List<Movimiento> movIngresos;

        //Constructor
        public Bodega(List<Movimiento> movIngresos)
        {
            this.movIngresos = movIngresos;
        }

        //Accesores
        public List<Movimiento> MovIngresos { get => movIngresos; set => movIngresos = value; }

        //Metodos
        public List <Movimiento> RegistrarProductos (List< Producto> articulos, ushort cantidadProducto)
        {
            try
            {
                foreach (Producto elemento in articulos)
                {
                    Movimiento IngresoProductos = new Movimiento(elemento, cantidadProducto, 'I', DateTime.Today);
                    movIngresos.Add(IngresoProductos);
                }
               
                return movIngresos;
            }
            catch (Exception)
            {
                throw new Exception("Error registrando productos en bodega");
            }
        }
    }
}
