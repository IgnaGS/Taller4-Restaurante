using System.Collections.Generic;
using System.Linq;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity.Migrations;

namespace Servicios
{
    public class ServicioProducto : IServicioProducto
    {
        private IServicioStock _ServicioStock = new ServicioStock();

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Productos
                    .ToList();
            }
        }
        public IEnumerable<Producto> ObtenerProductosDisponibles()
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Productos
                    .Where(p => p.Disponible.Equals("SI"))
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

        public void AddProducto(string descripcion, decimal precio, int stockInicial, string disponible)
        {
            Producto producto;

            using (var db = new AppDbContext())
            {
                producto = new Producto
                {
                    Descripcion = descripcion,
                    Precio = precio,
                    Disponible = disponible
                };

                db.Productos.AddOrUpdate(producto);

                db.SaveChanges();
            }

            if (producto != null)
                _ServicioStock.AddStock(producto.Id, stockInicial);
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
