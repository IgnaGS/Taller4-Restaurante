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

            db.Proveedores.AddOrUpdate(new Proveedor() { Descripcion = "Acme", Direccion = "Calle Falsa 123", Mail = "contacto@acme.com.ar", Telefono = "23428625", FechaAlta = new DateTime(2019, 6, 1) });
            db.Proveedores.AddOrUpdate(new Proveedor() { Descripcion = "Cañon", Direccion = "Camino General Chamizo 3452", Mail = "ventas@cañon.com.ar", Telefono = "72927834", FechaAlta = new DateTime(2019, 5, 23) });

            db.SaveChanges();

            var proveedro1 = db.Proveedores.FirstOrDefault(x => x.Descripcion == "Acme");
            var proveedro2 = db.Proveedores.FirstOrDefault(x => x.Descripcion == "Cañon");

            #endregion

            /* Armar Seeds 
            #region Profesores Seed

            db.Profesores.AddOrUpdate(new Profesor() { Dni = 21333525, Nombre = "Juan", Apellido = "González", FechaNacimiento = new DateTime(1971, 5, 5), Legajo = 453 });
            db.Profesores.AddOrUpdate(new Profesor() { Dni = 33103227, Nombre = "Federico", Apellido = "Marchese", FechaNacimiento = new DateTime(1987, 6, 7), Legajo = 72 });
            db.Profesores.AddOrUpdate(new Profesor() { Dni = 31255262, Nombre = "Andrea", Apellido = "Ludueña", FechaNacimiento = new DateTime(1985, 1, 15), Legajo = 3 });
            db.Profesores.AddOrUpdate(new Profesor() { Dni = 16822529, Nombre = "José", Apellido = "Sand", FechaNacimiento = new DateTime(1963, 3, 20), Legajo = 99 });
            db.Profesores.AddOrUpdate(new Profesor() { Dni = 17822529, Nombre = "Micaela", Apellido = "Montero", FechaNacimiento = new DateTime(1963, 3, 20), Legajo = 15 });

            db.SaveChanges();

            db.Profesores.FirstOrDefault(x => x.Legajo == 453).Materias.Add(materia1);
            db.Profesores.FirstOrDefault(x => x.Legajo == 72).Materias.Add(materia2);
            db.Profesores.FirstOrDefault(x => x.Legajo == 3).Materias.Add(materia3);
            db.Profesores.FirstOrDefault(x => x.Legajo == 99).Materias.Add(materia4);
            db.Profesores.FirstOrDefault(x => x.Legajo == 15).Materias.Add(materia5);

            db.SaveChanges();

            #endregion

            #region Alumnos Seed

            db.Alumnos.AddOrUpdate(new Alumno() { Dni = 41123123, Nombre = "Andrés", Apellido = "Pinedo", FechaNacimiento = new DateTime(1998, 7, 3) });
            db.Alumnos.AddOrUpdate(new Alumno() { Dni = 40212223, Nombre = "Pablo", Apellido = "Romero", FechaNacimiento = new DateTime(1997, 1, 4) });
            db.Alumnos.AddOrUpdate(new Alumno() { Dni = 43133323, Nombre = "Carolina", Apellido = "Andrada", FechaNacimiento = new DateTime(1999, 12, 12) });
            db.Alumnos.AddOrUpdate(new Alumno() { Dni = 39122223, Nombre = "Macarena", Apellido = "Giménez", FechaNacimiento = new DateTime(1996, 2, 3) });
            db.Alumnos.AddOrUpdate(new Alumno() { Dni = 40123123, Nombre = "Federico", Apellido = "Ruiz", FechaNacimiento = new DateTime(1997, 3, 3) });

            db.SaveChanges();

            var alumno1 = db.Alumnos.FirstOrDefault(x => x.Dni == 41123123);
            var alumno2 = db.Alumnos.FirstOrDefault(x => x.Dni == 40212223);
            var alumno3 = db.Alumnos.FirstOrDefault(x => x.Dni == 43133323);
            var alumno4 = db.Alumnos.FirstOrDefault(x => x.Dni == 39122223);
            var alumno5 = db.Alumnos.FirstOrDefault(x => x.Dni == 40123123);

            alumno1.Materias.Add(materia1);
            alumno1.Materias.Add(materia2);
            alumno2.Materias.Add(materia2);
            alumno2.Materias.Add(materia3);
            alumno3.Materias.Add(materia3);
            alumno3.Materias.Add(materia4);
            alumno4.Materias.Add(materia4);
            alumno4.Materias.Add(materia5);
            alumno5.Materias.Add(materia5);
            alumno5.Materias.Add(materia1);

            db.SaveChanges();

            #endregion

            #region Examenes Seed

            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)8.5, Fecha = new DateTime(2018, 8, 28), Alumno = alumno1, Materia = materia1 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)2, Fecha = new DateTime(2018, 8, 29), Alumno = alumno1, Materia = materia2 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)5, Fecha = new DateTime(2018, 8, 29), Alumno = alumno2, Materia = materia2 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)9, Fecha = new DateTime(2018, 9, 22), Alumno = alumno2, Materia = materia3 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)6, Fecha = new DateTime(2018, 9, 22), Alumno = alumno3, Materia = materia3 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)10, Fecha = new DateTime(2018, 10, 2), Alumno = alumno3, Materia = materia4 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)4, Fecha = new DateTime(2018, 10, 2), Alumno = alumno4, Materia = materia4 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)7, Fecha = new DateTime(2018, 9, 1), Alumno = alumno4, Materia = materia5 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)2, Fecha = new DateTime(2018, 9, 1), Alumno = alumno5, Materia = materia5 });
            db.Examenes.AddOrUpdate(new Examen() { Nota = (decimal)8, Fecha = new DateTime(2018, 8, 28), Alumno = alumno5, Materia = materia1 });

            db.SaveChanges();

            #endregion
            */
        }

    }
}
