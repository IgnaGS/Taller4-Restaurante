using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.OrdenesCompras
{
    public class NuevaOrdenCompraViewModel
    {
        public int IdEmpleado { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdProveedor { get; set; }

        public NuevaOrdenCompraViewModel()
        {

        }
    }
}