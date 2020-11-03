using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaFarmacia.Clases;

namespace Farmacia
{
    public partial class Form1 : Form
    {
        List<Movimiento> ProductosBodega;
        List<Movimiento> ProductosCaja = new List<Movimiento> ();
        List<Movimiento> ProductosDisponibles = new List<Movimiento> ();
        List<Movimiento> InventarioCompleto = new List<Movimiento>();
        List<Movimiento> InventarioxFiltro = new List<Movimiento>();
        Movimiento productoSeleccionadoBodega;
        AdminArchivo GestorArchivo = new AdminArchivo();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "";
                label5.Text = "";
                string nombreArchivo;
                OpenFileDialog archivo = new OpenFileDialog();
                ProductosBodega= new List<Movimiento>();
                archivo.Filter = "TXT|*.txt";
                
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    nombreArchivo = archivo.FileName;

                    ProductosBodega.Clear();
                    foreach (Movimiento elemento in GestorArchivo.CargarArchivo(nombreArchivo))
                    {
                        ProductosBodega.Add(elemento);
                    }
                    
                    lbInfoProductos.DataSource = null;
                    lbInfoProductos.DataSource = ProductosBodega;
                    //InventarioCompleto.AddRange(ProductosBodega);
                    InventarioCompleto = ProductosBodega;
                    label1.Text = "Productos";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifique el archivo.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "";
                label5.Text = "";

                if (!InventarioCompleto.Any())
                {
                    MessageBox.Show("No hay productos en la farmacia","",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                }
                else
                {
                    if (cbConsultas.Text=="Productos disponibles")
                    {
                        label3.Visible = false;
                        cbTipoProducto.Visible = false;
                        foreach (Movimiento elemento in InventarioCompleto)
                        {
                            if (elemento.TipoMovimiento=='I' && elemento.CantidadProductos >0)
                            {
                                ProductosDisponibles.Add(elemento);
                            }
                        }
                        lbInfoProductos.DataSource = null;
                        lbInfoProductos.DataSource = ProductosDisponibles;
                        ProductosDisponibles.Clear();
                        label1.Text = "Productos";
                    }

                    else if (cbConsultas.Text=="Inventario completo")
                    {
                        label3.Visible = false;
                        cbTipoProducto.Visible = false;
                        lbInfoProductos.DataSource = null;
                        lbInfoProductos.DataSource = InventarioCompleto;
                        label1.Text = "Ingresos y ventas";
                    }

                    else if (cbConsultas.Text == "Inventario por filtro")
                    {
                        cbTipoProducto.Visible = true;
                        label3.Visible = true;
                        label1.Text = "Ingresos y ventas";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show ("No es posible hacer la consulta","",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cbConsultas.Text == "Inventario por filtro")
                {
                    if (cbTipoProducto.Text == "Medicamentos")
                    {
                        foreach (Movimiento elemento in InventarioCompleto)
                        {
                            if (elemento.Producto.GetType() == typeof(Sobre) || elemento.Producto.GetType() == typeof(Tableta) || elemento.Producto.GetType() == typeof(Liquido))
                            {
                                InventarioxFiltro.Add(elemento);
                            }
                        }
                    }
                    else if (cbTipoProducto.Text == "Cosmeticos")
                    {
                        foreach (Movimiento elemento in InventarioCompleto)
                        {
                            if (elemento.Producto.GetType() == typeof(Cosmetico))
                            {
                                InventarioxFiltro.Add(elemento);
                            }
                        }
                    }
                    else if (cbTipoProducto.Text == "Bebidas")
                    {
                        foreach (Movimiento elemento in InventarioCompleto)
                        {
                            if (elemento.Producto.GetType() == typeof(Bebida))
                            {
                                InventarioxFiltro.Add(elemento);
                            }
                        }
                    }

                    lbInfoProductos.DataSource = null;
                    lbInfoProductos.DataSource = InventarioxFiltro;
                    InventarioxFiltro.Clear();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("No es posible hacer la consulta","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            ushort cantidadPedida = 0;
            try
            {
                label4.Text="";
                label5.Text = "";
                productoSeleccionadoBodega = (Movimiento)(lbInfoProductos.SelectedItem);
                bool encontro = false;
                try
                {
                    cantidadPedida = ushort.Parse(tbCantidadProducto.Text);
                }
                catch(Exception)
                {
                    cantidadPedida = 0;
                }

                if (cantidadPedida>0)
                {
                    if (productoSeleccionadoBodega.CantidadProductos >= cantidadPedida)
                    {
                        if (productoSeleccionadoBodega.TipoMovimiento == 'I')
                        {
                            Movimiento productoSalida;
                            foreach (Movimiento elemento in ProductosCaja)
                            {
                                if (productoSeleccionadoBodega.Producto == elemento.Producto)
                                {
                                    elemento.CantidadProductos = (ushort)(elemento.CantidadProductos + cantidadPedida);
                                    encontro = true;
                                    break;
                                }
                            }
                            if (encontro == false)
                            {
                                ProductosCaja.Add(productoSalida = new Movimiento(productoSeleccionadoBodega.Producto, cantidadPedida, 'S', DateTime.Today));
                            }


                            lbInfoProductos.DataSource = null;
                            lbInfoProductos.DataSource = InventarioCompleto;
                            lbVentas.DataSource = null;
                            lbVentas.DataSource = ProductosCaja;
                        }
                        else
                            MessageBox.Show("No se puede agregar al carrito","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("No hay producto","",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                
                    MessageBox.Show("Cantidad de producto no es válida","",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("No es posible agregar al carrito","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                bool error = false;
                List < Movimiento > prodExcedidos= new List<Movimiento>();
                if (ProductosCaja.Any())
                {
                    foreach (Movimiento elemento in ProductosCaja)
                    {
                        error = false;
                        foreach(Movimiento pBodega in InventarioCompleto)
                        {
                            if (pBodega.TipoMovimiento == 'I')
                            {
                                if (elemento.Producto == pBodega.Producto )
                                {
                                    if (elemento.CantidadProductos <= pBodega.CantidadProductos)
                                    {
                                        error = false;
                                    }
                                    else
                                    {
                                        error = true;
                                        if (pBodega.CantidadProductos>0)
                                        {
                                            elemento.CantidadProductos = pBodega.CantidadProductos;
                                        } 
                                    }
                                    pBodega.CantidadProductos = (ushort)(pBodega.CantidadProductos - elemento.CantidadProductos);
                                }
                            }
                        }
                    }

                    if (error == true)
                    {
                        MessageBox.Show("No había cantidad suficiente para completar el pedido. Se vendió lo que había disponible.", "¡Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    InventarioCompleto.AddRange(ProductosCaja);
                    lbVentas.DataSource = null;
                    lbInfoProductos.DataSource = null;
                    lbInfoProductos.DataSource = InventarioCompleto;
                    ProductosCaja.Clear();
                    label4.Text = "¡Se hizo una venta exitosa!";
                    label1.Text = "Ingresos y ventas";
                    tbCantidadProducto.Text = "";
                }
                   
                else
                    MessageBox.Show("No hay productos en el carrito de venta","",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo hacer la venta", "", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductosCaja.Any())
                {
                    label4.Text = "";
                    label5.Text = "";

                    Movimiento productoSeleccionado = (Movimiento)(lbVentas.SelectedItem);
                    ProductosCaja.Remove(productoSeleccionado);
                    lbVentas.DataSource = null;
                    lbVentas.DataSource = ProductosCaja;
                }
                else
                    MessageBox.Show("No hay elementos para borrar", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar un elemento", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbCantidadProducto_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
