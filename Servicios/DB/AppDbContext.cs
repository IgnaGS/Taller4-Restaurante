using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;

namespace Servicios.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("AppDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>());
        }

        public IDbSet<Catalogo> Catalogos { get; set; }
        public IDbSet<Empleado> Empleados { get; set; }
        public IDbSet<OrdenCompra> OrdenesCompras { get; set; }
        public IDbSet<Producto> Productos { get; set; }
        public IDbSet<Proveedor> Proveedores { get; set; }
        public IDbSet<Stock> Stocks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Catalogos

            modelBuilder.Entity<Catalogo>().ToTable("Catalogos").HasKey(catalogo => catalogo.Id);
            modelBuilder.Entity<Catalogo>().Property(catalogo => catalogo.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Catalogo>().HasRequired(catalogo => catalogo.Proveedor);
            modelBuilder.Entity<Catalogo>().HasRequired(catalogo => catalogo.Producto);
         
            #endregion

            #region Empleados

            modelBuilder.Entity<Empleado>().ToTable("Empleados").HasKey(empleado => empleado.Id);
            modelBuilder.Entity<Empleado>().Property(empleado => empleado.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Empleado>().Property(empleado => empleado.Legajo).IsRequired();
            modelBuilder.Entity<Empleado>().HasIndex(empleado => empleado.Legajo).IsUnique();
            modelBuilder.Entity<Empleado>().Property(empleado => empleado.Nombre).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Empleado>().Property(empleado => empleado.Apellido).IsRequired().HasMaxLength(100);

            #endregion

            #region OrdenesCompras

            modelBuilder.Entity<OrdenCompra>().ToTable("OrdenesCompras").HasKey(orden => orden.Id);
            modelBuilder.Entity<OrdenCompra>().Property(orden => orden.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<OrdenCompra>().Property(orden => orden.Cantidad).IsRequired();
            modelBuilder.Entity<OrdenCompra>().Property(orden => orden.FechaEntrega).IsRequired();
            modelBuilder.Entity<OrdenCompra>().Property(orden => orden.Estado).HasMaxLength(12);
            modelBuilder.Entity<OrdenCompra>().HasRequired(orden => orden.Empleado);
            modelBuilder.Entity<OrdenCompra>().HasRequired(orden => orden.Producto);
            modelBuilder.Entity<OrdenCompra>().HasRequired(orden => orden.Proveedor);

            #endregion

            #region Productos

            modelBuilder.Entity<Producto>().ToTable("Productos").HasKey(producto => producto.Id);
            modelBuilder.Entity<Producto>().Property(producto => producto.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Producto>().Property(producto => producto.Descripcion).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Producto>().Property(producto => producto.Precio).IsRequired();
            modelBuilder.Entity<Producto>().Property(producto => producto.Disponible).IsRequired().HasMaxLength(2);

            #endregion

            #region Proveedores

            modelBuilder.Entity<Proveedor>().ToTable("Proveedores").HasKey(proveedor => proveedor.Id);
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Descripcion).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Direccion).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Mail).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Telefono).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.FechaAlta).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Disponible).HasMaxLength(2).IsRequired();

            #endregion

            #region Stocks

            modelBuilder.Entity<Stock>().ToTable("Stocks").HasKey(stock => stock.Id);
            modelBuilder.Entity<Stock>().Property(stock => stock.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Stock>().HasRequired(stock => stock.Producto);
            modelBuilder.Entity<Stock>().Property(stock => stock.Cantidad).IsRequired();

            #endregion
        }
    }
}
