using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioProveedor
    {
        IEnumerable<Proveedor> ObtenerProveedores();

        void AddProveedor(string descripcion, string direccion, string mail, string telefono, DateTime fechaAlta);

        void UpdateProveedor(int id, string descripcion, string direccion, string mail, string telefono, DateTime fechaAlta);

        Proveedor ObtenerProveedor(int id);
    }
}
