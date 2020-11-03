using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{
    public class Cosmetico:Producto, I_Asegurar
    {
        //Atributos
        private string fabricante;
        private string tipoPresentacion;

        //Constructor
        public Cosmetico(string nombre, char tipoAlmacenamiento,string fabricante, string tipoPresentacion)
            :base(nombre, tipoAlmacenamiento)
        {
            this.fabricante = fabricante;
            this.tipoPresentacion = tipoPresentacion;
        }

        //Accesores
        public string Fabricante
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(fabricante) || string.IsNullOrWhiteSpace(fabricante))
                    {
                        fabricante = "error";
                        return fabricante;
                    }
                    else
                    {
                        return fabricante;
                    }
                }
                catch (Exception)
                {
                    fabricante = "error";
                    return fabricante;
                }
                }
                
        }
        public string TipoPresentacion { get => tipoPresentacion;}

        //Metodos
        public string Asegurar()
        {
            return "El medicamento está asegurado con botón";
        }

        public override string ToString()
        {
            return "|" + TipoAlmacenamiento + "| " + Nombre + " " + fabricante + " "+tipoPresentacion;
        }
    }
}
