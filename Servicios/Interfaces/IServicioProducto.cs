using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioProducto
    {
        IEnumerable<Producto> ObtenerProductos();

        void AddProducto(string descripcion, decimal precio, string disponible);

        void UpdateProducto(int id, string descripcion, decimal precio, string disponible);

        Producto ObtenerProducto(int id);
    }
}
