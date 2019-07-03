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

        public Producto ObtenerProducto(int id)
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Productos
                    .Find(id);
            }
        }

        public void AddProducto(string descripcion, decimal precio, string disponible)
        {
            using (var db = new AppDbContext())
            {
                db.Productos
                    .AddOrUpdate(new Producto()
                    {
                        Descripcion = descripcion,
                        Precio = precio,
                        Disponible = disponible
                    });

                db.SaveChanges();
            }
        }

        public void UpdateProducto(int id, string descripcion, decimal precio, string disponible)
        {
            using (var db = new AppDbContext())
            {
                var producto = db.Productos.Find(id);

                producto.Descripcion = descripcion;
                producto.Precio = precio;
                producto.Disponible = disponible;

                db.SaveChanges();
            }
        }
    }
}
