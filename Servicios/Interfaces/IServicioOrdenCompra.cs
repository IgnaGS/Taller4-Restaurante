using System;
using System.Collections.Generic;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioOrdenCompra
    {
        IEnumerable<OrdenCompra> ObtenerOrdenesCompras();

        OrdenCompra ObtenerOrdenCompra(int idOrdenCompra);

        void AddOrdenCompra(int idEmpleado, int idProducto, int cantidad, DateTime fechaEntrega, int idProveedor);

        void ContretarOrdenCompra(int idOrdenCompra);

        void CancelarOrdenCompra(int idOrdenCompra);
    }
}