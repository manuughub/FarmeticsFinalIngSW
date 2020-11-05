using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Clases;
using System.IO;
using System.Windows.Forms;


namespace Farmacia
{
    class AdminArchivo
    {
        List<Movimiento> ProductosDisponibles = new List<Movimiento>();

        public List <Movimiento> CargarArchivo(string nombreArchivo)
        {
            try
            {
                Movimiento registroProductos;
                string asegurado = "";
                StreamReader leer;
                string linea="";
                string[] vectorString, vectorProducto;
                List<Producto> acum = new List<Producto>();
                leer = new StreamReader(nombreArchivo);
                linea = leer.ReadLine();
                while (linea != null)
                {
                    vectorString = linea.Split('|');
                    string tipoMov = vectorString[2];
                    vectorProducto = vectorString[0].Split('@');
                    if (vectorString[3].Equals("S"))
                    {
                        Sobre producto = new Sobre(vectorProducto[0], 'G', vectorProducto[1], ulong.Parse(vectorProducto[2]), vectorProducto[3], uint.Parse(vectorProducto[4]));
                        asegurado = producto.Asegurar();
                        registroProductos = new Movimiento(producto, ushort.Parse(vectorString[1]), tipoMov[0], DateTime.Today);
                        ProductosDisponibles.Add(registroProductos);
                    }
                    else if (vectorString[3].Equals("T"))
                    {
                        Tableta producto = new Tableta(vectorProducto[0], 'G', vectorProducto[1], ulong.Parse(vectorProducto[2]), vectorProducto[3], uint.Parse(vectorProducto[4]), uint.Parse(vectorProducto[5]));
                        asegurado = producto.Asegurar();
                        registroProductos = new Movimiento(producto, ushort.Parse(vectorString[1]), tipoMov[0], DateTime.Today);
                        ProductosDisponibles.Add(registroProductos);
                    }
                    else if (vectorString[3].Equals("L"))
                    {
                        Liquido producto = new Liquido(vectorProducto[0], 'G', vectorProducto[1], ulong.Parse(vectorProducto[2]), vectorProducto[3], uint.Parse(vectorProducto[4]));
                        asegurado = producto.Asegurar();
                        registroProductos = new Movimiento(producto, ushort.Parse(vectorString[1]), tipoMov[0], DateTime.Today);
                        ProductosDisponibles.Add(registroProductos);
                    }
                    else if (vectorString[3].Equals("C"))
                    {
                        Cosmetico producto = new Cosmetico(vectorProducto[0], 'E', vectorProducto[1], vectorProducto[2]);
                        asegurado = producto.Asegurar();
                        registroProductos = new Movimiento(producto, ushort.Parse(vectorString[1]), tipoMov[0], DateTime.Today);
                        ProductosDisponibles.Add(registroProductos);
                    }
                    else if (vectorString[3].Equals("B"))
                    {
                        Bebida producto = new Bebida(vectorProducto[0], 'N', uint.Parse(vectorProducto[1]), vectorProducto[2]);
                        registroProductos = new Movimiento(producto, ushort.Parse(vectorString[1]), tipoMov[0], DateTime.Today);
                        ProductosDisponibles.Add(registroProductos);
                    }

                    linea = leer.ReadLine();
                }

                if (asegurado.Equals("El medicamento está asegurado con chip") || asegurado.Equals("El medicamento está asegurado con botón"))
                {
                    MessageBox.Show("Los medicamentos y cosméticos quedaron asegurados.", "¡Muy bien!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return ProductosDisponibles;
            }
            catch (Exception)
            {
                throw new Exception("Error cargando archivo ");
            }
        }

    }
}
