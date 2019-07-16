using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity;
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
                ;
            }
        }

        public void AddStock(Producto producto, int cantidad)
        {
            using (var db = new AppDbContext())
            {
                db.Stocks
                    .AddOrUpdate(new Stock()
                    {
                        Producto = producto,
                        Cantidad = cantidad
                    });

                db.SaveChanges();
            }
        }

        public void UpdateStock(int id, Producto producto, int cantidad)
        {
            using (var db = new AppDbContext())
            {
                //var stock = db.Stocks.Find(id);
                var stock = ObtenerStock(producto.Id);

                stock.Cantidad += cantidad;

                db.SaveChanges();
            }
        }
    }
}
