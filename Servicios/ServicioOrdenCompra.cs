using System;
using System.Collections.Generic;
using System.Linq;
using Servicios.Interfaces;
using Servicios.DB;
using Domain;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace Servicios
{
    public class ServicioOrdenCompra : IServicioOrdenCompra
    {
        public IEnumerable<OrdenCompra> ObtenerOrdenesCompras()
        {
            using (var db = new AppDbContext())
            {
                return db.OrdenesCompras
                            .Include(x => x.Empleado)
                            .Include(x => x.Producto)
                            .Include(x => x.Proveedor)
                            .ToList();
            }
        }

        public IEnumerable<OrdenCompra> ObtenerOrdenesCompras(string EstadoFiltrado, int IdProductoFiltrado)
        {
            using (var db = new AppDbContext())
            {
                var model = db.OrdenesCompras
                            .Include(x => x.Empleado)
                            .Include(x => x.Producto)
                            .Include(x => x.Proveedor);

                if (!String.IsNullOrEmpty(EstadoFiltrado))
                {
                    model.Where(o => o.Estado == EstadoFiltrado);
                }

                if (IdProductoFiltrado > 0)
                {
                    model.Where(o => o.Producto.Id == IdProductoFiltrado);
                }

                model.ToList();

                return model;
            }
        }

        public OrdenCompra ObtenerOrdenCompra(int idOrdenCompra)
        {
            using (var db = new AppDbContext())
            {
                return db.OrdenesCompras
                            .Include(x => x.Empleado)
                            .Include(x => x.Producto)
                            .Include(x => x.Proveedor)
                            .FirstOrDefault(o => o.Id == idOrdenCompra);
                //return db.OrdenesCompras.Find(idOrdenCompra);
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