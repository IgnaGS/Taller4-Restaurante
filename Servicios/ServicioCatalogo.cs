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
    public class ServicioCatalogo : IServicioCatalogo
    {
        public IEnumerable<Catalogo> ObtenerCatalogos(int idProveedor)
        {
            using (var db = new AppDbContext())
            {
                return db.Catalogos.Where(c => c.Proveedor.Id == idProveedor && c.Producto.Disponible.Equals("SI")).ToList();
            }
        }

        public Catalogo ObtenerCatalogo(int idProveedor, int idProducto)
        {
            using (var db = new AppDbContext())
            {
                return db.Catalogos.FirstOrDefault(c => c.Proveedor.Id == idProveedor && c.Producto.Id == idProducto);
            }
        }

        public void AddCatalogo(int idProveedor, int idProducto)
        {
            using (var db = new AppDbContext())
            {
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
        }

        public void DeleteCatalogo(int idProveedor, int idProducto)
        {
            using (var db = new AppDbContext())
            {
                var catalogo = db.Catalogos.FirstOrDefault(c => c.Proveedor.Id == idProveedor && c.Producto.Id == idProducto);

                db.Catalogos.Remove(catalogo);

                db.SaveChanges();
            }
        }
    }
}
