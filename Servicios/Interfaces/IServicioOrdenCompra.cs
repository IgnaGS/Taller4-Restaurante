using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioOrdenCompra
    {
        IEnumerable<OrdenCompra> ObtenerOrdenesCompras();

        OrdenCompra ObtenerOrdenCompra(int id);

        void AddOrdenCompra(int idEmpleado, int idProducto, int cantidad, DateTime fechaEntrega, int idProveedor);

        void ContretarOrdenCompra(int idOrdenCompra);

        void CancelarOrdenCompra(int idOrdenCompra);
    }
}
