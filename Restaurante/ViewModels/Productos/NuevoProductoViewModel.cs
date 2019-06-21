using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.Productos
{
    public class NuevoProductoViewModel
    {
        public string Descripcion { set; get; }
        public double Precio { set; get; }

        public NuevoProductoViewModel()
        {

        }
    }
}