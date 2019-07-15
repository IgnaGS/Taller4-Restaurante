using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.Empleados
{
    public class EmpleadoViewItem
    {
        public int Id { get; set; }
        public int Legajo { get; set; }
        public string Nombre { set; get; }
        public string Apellido { get; set; }

        public EmpleadoViewItem()
        {

        }

        public EmpleadoViewItem(Empleado empleado)
        {
            Id = empleado.Id;
            Legajo = empleado.Legajo;
            Nombre = empleado.Nombre;
            Apellido = empleado.Apellido;
        }
    }
}