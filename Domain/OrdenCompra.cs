using System;

namespace Domain
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Proveedor Proveedor { get; set; }
        public String Estado { get; set; }
    }
}
