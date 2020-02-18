using System;
using System.Web.Mvc;

namespace Restaurante.ViewModels.OrdenesCompras
{
    public class NuevaOrdenCompraViewModel
    {
        public int IdEmpleado { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdProveedor { get; set; }
        public SelectList Productos { get; set; }
        public SelectList Proveedores { get; set; }
        public SelectList Empleados { get; set; }

        public NuevaOrdenCompraViewModel()
        {

        }
    }
}