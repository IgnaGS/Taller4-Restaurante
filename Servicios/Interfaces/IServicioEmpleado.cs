using System.Collections.Generic;
using Domain;

namespace Servicios.Interfaces
{
    public interface IServicioEmpleado
    {
        IEnumerable<Empleado> ObtenerEmpleados();

        Empleado ObtenerEmpleado(int id);
    }
}
