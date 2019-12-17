using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioCatalogo
    {
        IEnumerable<Catalogo> ObtenerCatalogosPorProveedor(int idProveedor);

        IEnumerable<Catalogo> ObtenerCatalogosPorProducto(int idProducto);

        Catalogo ObtenerCatalogo(int idProveedor, int idProducto);

        Catalogo ObtenerCatalogo(int id);

        IEnumerable<Producto> ObtenerProductosFueraDeCatalogoProveedor(int idProveedor);

        void AddCatalogo(int idProveedor, int idProducto);

        void DeleteCatalogo(int idCatalogo);
    }
}
