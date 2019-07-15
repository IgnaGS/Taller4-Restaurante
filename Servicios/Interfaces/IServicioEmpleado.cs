using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioEmpleado
    {
        IEnumerable<Empleado> ObtenerEmpleados();

        Empleado ObtenerEmpleado(int id);
    }
}
