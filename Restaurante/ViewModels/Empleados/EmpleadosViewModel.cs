using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.Empleados
{
    public class EmpleadosViewModel
    {
        public IEnumerable<EmpleadoViewItem> Empleados { get; set; }

        public EmpleadosViewModel()
        {
            Empleados = Enumerable.Empty<EmpleadoViewItem>();
        }
    }
}