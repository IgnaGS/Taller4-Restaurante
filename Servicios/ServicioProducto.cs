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
    public class ServicioProducto : IServicioProducto
    {
        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Productos
                    .ToList();
            }
        }

        public void AddProducto(string descripcion, double precio)
        {
            using (var db = new AppDbContext())
            {
                db.Productos
                    .AddOrUpdate(new Producto()
                    {
                        Descripcion = descripcion,
                        Precio = precio
                    });

                db.SaveChanges();
            }
        }

        public void UpdateProducto(int id, string descripcion, double precio)
        {
            using (var db = new AppDbContext())
            {
                var producto = db.Productos.Find(id);

                producto.Descripcion = descripcion;
                producto.Precio = precio;

                db.SaveChanges();
            }
        }
    }
}
