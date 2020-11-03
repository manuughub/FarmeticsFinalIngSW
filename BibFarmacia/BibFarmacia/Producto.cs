using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public abstract class Producto
    {
        //Atributos
        private string nombre;
        private char tipoAlmacenamiento;

        //Constructor
        public Producto(string nombre, char tipoAlmacenamiento)
        {
            this.nombre = nombre;
            this.tipoAlmacenamiento = tipoAlmacenamiento;
        }

        //Accesores
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(Nombre) || string.IsNullOrWhiteSpace(Nombre))
                    {
                        nombre = "error";
                    }
                    else
                    {
                        nombre = value;
                    }
                }
                catch (Exception)
                {
                    nombre = "error";
                }
                
            }
        }
        public char TipoAlmacenamiento { get => tipoAlmacenamiento; }
    }
}
