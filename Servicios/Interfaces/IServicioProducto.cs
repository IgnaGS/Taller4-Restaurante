using System.Collections.Generic;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioProducto
    {
        IEnumerable<Producto> ObtenerProductos();

        void AddProducto(string descripcion, decimal precio, int stockInicial, string disponible);

        void UpdateProducto(int id, string descripcion, decimal precio, string disponible);

        Producto ObtenerProducto(int id);
    }
}
