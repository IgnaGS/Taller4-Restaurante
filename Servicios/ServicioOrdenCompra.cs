using System;
using System.Collections.Generic;
using System.Linq;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity.Migrations;

namespace Servicios
{
    public class ServicioOrdenCompra : IServicioOrdenCompra
    {
        public IEnumerable<OrdenCompra> ObtenerOrdenesCompras()
        {
            using (var db = new AppDbContext())
            {
                return db.OrdenesCompras.ToList();
            }
        }

        public OrdenCompra ObtenerOrdenCompra(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.OrdenesCompras.Find(id);
            }
        }

        public void AddOrdenCompra(int idEmpleado, int idProducto, int cantidad, DateTime fechaEntrega, int idProveedor)
        {
            using (var db = new AppDbContext())
            {
                var Empleado = db.Empleados.Find(idEmpleado);
                var Producto = db.Productos.Find(idProducto);
                var Proveedor = db.Proveedores.Find(idProveedor);

                db.OrdenesCompras
                    .AddOrUpdate(new OrdenCompra()
                    {
                        Empleado = Empleado,
                        Producto = Producto,
                        Cantidad = cantidad,
                        FechaEntrega = fechaEntrega,
                        Proveedor = Proveedor,
                        Estado = "Activa"
                    });

                db.SaveChanges();
            }
        }

        public void ContretarOrdenCompra(int idOrdenCompra)
        {
            using (var db = new AppDbContext())
            {
                var OrdenCompra = db.OrdenesCompras.Find(idOrdenCompra);

                OrdenCompra.Estado = "Concretada";

                db.SaveChanges();
            }
        }

        public void CancelarOrdenCompra(int idOrdenCompra)
        {
            using (var db = new AppDbContext())
            {
                var OrdenCompra = db.OrdenesCompras.Find(idOrdenCompra);

                OrdenCompra.Estado = "Cancelada";

                db.SaveChanges();
            }
        }
    }
}
