using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Inventario
    {
        //atributos
        private List<Movimiento> registroMovimientos;
        private uint saldo;

        //Constructor
        public Inventario(List<Movimiento> registroMovimientos, uint saldo)
        {
            this.registroMovimientos = registroMovimientos;
            this.saldo = saldo;
        }

        //Accesores
        public uint Saldo { get => saldo; set => saldo = value; }
        internal List<Movimiento> RegistroMovimientos { get => registroMovimientos; set => registroMovimientos = value; }

        //Metodos
        public List<Movimiento> ConsultarInventario(List<Movimiento> listaEntradas, List<Movimiento> listaSalidas)
        {

            try
            {
                foreach (Movimiento elemento in listaEntradas)
                {
                    RegistroMovimientos.Add(elemento);
                }
                foreach (Movimiento elemento in listaSalidas)
                {
                    RegistroMovimientos.Add(elemento);
                }

                return RegistroMovimientos;
            }
            catch (Exception)
            {
                throw new Exception("Error consultando inventario");
            }
        }

        public List<Producto> ConsultarInventario(List<Movimiento> listaEntradas, List<Movimiento> listaSalidas, char tipoProducto)
        {
            try
            {
                List<Producto> ProductosMovimiento = new List<Producto>();

                foreach (Movimiento elemento in registroMovimientos)
                {
             
                        if (tipoProducto.ToString().ToUpper().Equals("M"))
                        {
                            if (elemento.Producto.GetType() == typeof(Medicamento))
                            {
                                ProductosMovimiento.Add(elemento.Producto);
                            }
                        }
                        else if (tipoProducto.ToString().ToUpper().Equals("C"))
                        {
                            if (elemento.Producto.GetType() == typeof(Cosmetico))
                            {
                                ProductosMovimiento.Add(elemento.Producto);
                            }
                        }
                        else
                        {
                            if (elemento.Producto.GetType() == typeof(Bebida))
                            {
                                ProductosMovimiento.Add(elemento.Producto);
                            }
                        }
                    
                }

                return ProductosMovimiento;
            }
            catch (Exception)
            {
                throw new Exception("Error consultando inventario por tipo de producto");
            }
        }
    }
}
