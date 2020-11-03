using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{
    public abstract class Medicamento:Producto, I_Asegurar
    {
        //Atributos
        private string laboratorio;
        private ulong precioVenta;
        private string fechaVencimiento;

        //Constructor
        public Medicamento(string nombre, char tipoAlmacenamiento, string laboratorio, ulong precioVenta, string fechaVencimiento)
         :base (nombre,tipoAlmacenamiento)
        {
                this.laboratorio = laboratorio;
                this.precioVenta = precioVenta;
                this.fechaVencimiento = fechaVencimiento;
        }

        //Accesores
        public string Laboratorio
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(laboratorio) || string.IsNullOrWhiteSpace(laboratorio))
                    {
                        laboratorio = "error";
                        return laboratorio;
                    }
                    else
                    {
                        return laboratorio;
                    }
                }
                catch (Exception)
                {
                    laboratorio = "error";
                    return laboratorio;
                }
                }
                
            
        }
        public ulong PrecioVenta
        {
            get
            {
                try
                {
                    if (precioVenta > 0)
                        return precioVenta;
                    else
                    {
                        precioVenta = 0;
                        return precioVenta;
                    }
                }
                catch (Exception)
                {
                    precioVenta = 0;
                    return precioVenta;
                }
                
            }
        }
        public string FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }

        //Metodos
        public string Asegurar()
        {
            return "El medicamento está asegurado con chip";
        }

     
    }
}
