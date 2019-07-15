using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.Proveedores
{
    public class NuevoProveedorViewModel
    {
        public string Descripcion { set; get; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Disponible { get; set; }

        public NuevoProveedorViewModel()
        {

        }
    }
}