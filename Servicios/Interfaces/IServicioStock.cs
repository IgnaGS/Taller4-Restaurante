using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioStock
    {
        Stock ObtenerStock(int idProducto);

        void AddStock(int idProducto, int cantidad);

        void UpdateStock(int id, int idProducto, int cantidad);
    }
}
