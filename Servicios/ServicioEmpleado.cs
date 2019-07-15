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
    public class ServicioEmpleado : IServicioEmpleado
    {
        public IEnumerable<Empleado> ObtenerEmpleados()
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Empleados
                    .ToList();
            }
        }

        public Empleado ObtenerEmpleado(int id)
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Empleados
                    .Find(id);
            }
        }
    }
}
