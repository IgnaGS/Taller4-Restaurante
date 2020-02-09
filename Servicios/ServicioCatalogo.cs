using System.Collections.Generic;
using System.Linq;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Servicios
{
    public class ServicioCatalogo : IServicioCatalogo
    {
        public IEnumerable<Catalogo> ObtenerCatalogosPorProveedor(int idProveedor)
        {
            using (var db = new AppDbContext())
            {
                return db.Catalogos
                            .Include(x => x.Producto)
                            .Include(x => x.Proveedor)
                            .Where(c => c.ProveedorId == idProveedor && c.Producto.Disponible.Equals("SI"))
                            .ToList();
            }
        }

        public IEnumerable<Catalogo> ObtenerCatalogosPorProducto(int idProducto)
        {
            using (var db = new AppDbContext())
            {
                return db.Catalogos
                            .Where(c => c.Producto.Id == idProducto && c.Producto.Disponible.Equals("SI"))
                            .Include(x => x.Producto)
                            .Include(x => x.Proveedor)
                            .ToList();
            }
        }

        public Catalogo ObtenerCatalogo(int idProveedor, int idProducto)
        {
            using (var db = new AppDbContext())
            {
                return db.Catalogos
                    .Include(x => x.Producto)
                    .Include(x => x.Proveedor)
                    .FirstOrDefault(c => c.Proveedor.Id == idProveedor && c.Producto.Id == idProducto);
            }
        }

        public Catalogo ObtenerCatalogo(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Catalogos.Find(id);
            }
        }

        public IEnumerable<Producto> ObtenerProductosFueraDeCatalogoProveedor(int idProveedor)
        {
            using (var db = new AppDbContext())
            {
                return db.Productos
                            .Where(p => p.Disponible.Equals("SI"))
                            .ToList().Except(db.Catalogos
                                                    .Where(c => c.Proveedor.Id == idProveedor)
                                                    .Select(c => c.Producto)
                                                    .ToList()
                                                    );
            }
        }

        public void AddCatalogo(int idProveedor, int idProducto)
        {
            var db = new AppDbContext();
            var producto = db.Productos.Find(idProducto);
            var proveedor = db.Proveedores.Find(idProveedor);

            var catalogo = new Catalogo()
            {
                Producto = producto,
                Proveedor = proveedor
            };

            db.Catalogos.AddOrUpdate(catalogo);

            db.Productos.Attach(producto);
            db.Proveedores.Attach(proveedor);

            db.SaveChanges();
        }

        public void DeleteCatalogo(int idCatalogo)
        {
            var db = new AppDbContext();
            var catalogo = db.Catalogos.Find(idCatalogo);

            db.Catalogos.Remove(catalogo);

            db.SaveChanges();
        }

    }
}
