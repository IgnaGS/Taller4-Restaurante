using System;
using Domain;

namespace Restaurante.ViewModels.OrdenesCompras
{
    public class OrdenCompraViewItem
    {
        public int Id { get; set; }
        public String Empleado { get; set; }
        public int IdProducto { get; set; }
        public String Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public String Proveedor { get; set; }
        public String Estado { get; set; }

        public OrdenCompraViewItem()
        {

        }

        public OrdenCompraViewItem(OrdenCompra ordenCompra)
        {
            Id = ordenCompra.Id;
            Empleado = ordenCompra.Empleado.Nombre +" "+ ordenCompra.Empleado.Nombre;
            IdProducto = ordenCompra.Producto.Id;
            Producto = ordenCompra.Producto.Descripcion;
            Cantidad = ordenCompra.Cantidad;
            FechaEntrega = ordenCompra.FechaEntrega;
            Proveedor = ordenCompra.Proveedor.Descripcion;
            Estado = ordenCompra.Estado;
        }
    }
}