using System.Linq;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity.Migrations;

namespace Servicios
{
    public class ServicioStock : IServicioStock
    {
        public Stock ObtenerStock(int idProducto)
        {
            using (var db = new AppDbContext())
            {
                return db.Stocks.FirstOrDefault(s => s.Producto.Id == idProducto);
            }
        }

        public void AddStock(int idProducto, int cantidad)
        {
            using (var db = new AppDbContext())
            {
                var producto = db.Productos.Find(idProducto);

                var stock = new Stock()
                {
                    Producto = producto,
                    Cantidad = cantidad
                };

                db.Stocks.AddOrUpdate(stock);

                db.Productos.Attach(producto);

                db.SaveChanges();
            }
        }

        public void UpdateStock(int id, int idProducto, int cantidad)
        {
            using (var db = new AppDbContext())
            {
                //var stock = db.Stocks.Find(id);
                var stock = ObtenerStock(idProducto);

                stock.Cantidad += cantidad;

                db.SaveChanges();
            }
        }
    }
}
