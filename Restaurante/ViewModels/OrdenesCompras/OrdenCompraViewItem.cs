using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.OrdenesCompras
{
    public class OrdenCompraViewItem
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Proveedor Proveedor { get; set; }
        public String Estado { get; set; }

        public OrdenCompraViewItem()
        {

        }

        public OrdenCompraViewItem(OrdenCompra ordenCompra)
        {
            Id = ordenCompra.Id;
            Empleado = ordenCompra.Empleado;
            Producto = ordenCompra.Producto;
            Cantidad = ordenCompra.Cantidad;
            FechaEntrega = ordenCompra.FechaEntrega;
            Proveedor = ordenCompra.Proveedor;
            Estado = ordenCompra.Estado;
        }
    }
}