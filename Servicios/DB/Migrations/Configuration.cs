using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.DB.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration() 
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Servicios.Db.AppDbContext";
        }

        
        protected override void Seed(AppDbContext db)
        {
            if (db.Productos.Any())
                return;

            #region Productos Seed

            db.Productos.AddOrUpdate(new Producto() { Descripcion = "Producto 1 Prueba", Precio = 200, Disponible = "SI" });
            db.Productos.AddOrUpdate(new Producto() { Descripcion = "Producto 2 Prueba", Precio = 120, Disponible = "SI" });

            db.SaveChanges();

            var producto1 = db.Productos.FirstOrDefault(x => x.Descripcion == "Prodcuto 1 Prueba");
            var producto2 = db.Productos.FirstOrDefault(x => x.Descripcion == "Prodcuto 2 Prueba");

            #endregion

            #region Proveedores Seed

            db.Proveedores.AddOrUpdate(new Proveedor() { Descripcion = "Acme", Direccion = "Calle Falsa 123", Mail = "contacto@acme.com.ar", Telefono = "23428625", FechaAlta = new DateTime(2019, 6, 1), Disponible = "SI" });
            db.Proveedores.AddOrUpdate(new Proveedor() { Descripcion = "Cañon", Direccion = "Camino General Chamizo 3452", Mail = "ventas@cañon.com.ar", Telefono = "72927834", FechaAlta = new DateTime(2019, 5, 23), Disponible = "SI" });

            db.SaveChanges();

            var proveedro1 = db.Proveedores.FirstOrDefault(x => x.Descripcion == "Acme");
            var proveedro2 = db.Proveedores.FirstOrDefault(x => x.Descripcion == "Cañon");

            #endregion

            #region Empleados Seed

            db.Empleados.AddOrUpdate(new Empleado() { Legajo = 2125, Nombre = "Cosme", Apellido = "Fulanito" });
            db.Empleados.AddOrUpdate(new Empleado() { Legajo = 6542, Nombre = "Bernard", Apellido = "Bernoulli" });

            db.SaveChanges();

            var empleado1 = db.Empleados.FirstOrDefault(x => x.Legajo == 2125);
            var empleado2 = db.Empleados.FirstOrDefault(x => x.Legajo == 6542);

            #endregion

            #region Stock Seed

            db.Stocks.AddOrUpdate(new Stock() { Producto = producto1, Cantidad = 80 });
            db.Stocks.AddOrUpdate(new Stock() { Producto = producto2, Cantidad = 55 });

            db.SaveChanges();

            #endregion

            #region Catalogo Seed

            db.Catalogos.AddOrUpdate(new Catalogo() { Proveedor = proveedro1, Producto = producto1 });
            db.Catalogos.AddOrUpdate(new Catalogo() { Proveedor = proveedro1, Producto = producto2 });
            db.Catalogos.AddOrUpdate(new Catalogo() { Proveedor = proveedro2, Producto = producto2 });

            db.SaveChanges();

            #endregion

            #region Orden de Compra Seed

            db.OrdenesCompras.AddOrUpdate(new OrdenCompra() { Empleado = empleado1, Producto = producto1, Cantidad = 50, FechaEntrega = new DateTime(2019, 6, 20), Proveedor = proveedro1, Estado = "Concretada" });
            db.OrdenesCompras.AddOrUpdate(new OrdenCompra() { Empleado = empleado1, Producto = producto2, Cantidad = 20, FechaEntrega = new DateTime(2019, 6, 20), Proveedor = proveedro1, Estado = "Cancelada" });
            db.OrdenesCompras.AddOrUpdate(new OrdenCompra() { Empleado = empleado2, Producto = producto2, Cantidad = 35, FechaEntrega = new DateTime(2019, 7, 01), Proveedor = proveedro2, Estado = "Concretada" });
            db.OrdenesCompras.AddOrUpdate(new OrdenCompra() { Empleado = empleado2, Producto = producto2, Cantidad = 30, FechaEntrega = new DateTime(2019, 7, 16), Proveedor = proveedro2, Estado = "Activa" });

            db.SaveChanges();

            #endregion
            
        }

    }
}
