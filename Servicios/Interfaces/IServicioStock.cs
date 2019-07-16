using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioStock
    {
        Stock ObtenerStock(int idProducto);

        void AddStock(Producto producto, int cantidad);

        void UpdateStock(int id, Producto producto, int cantidad);
    }
}
