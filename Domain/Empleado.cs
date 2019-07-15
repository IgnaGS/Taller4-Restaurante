using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Empleado
    {
        public int Id { get; set; }
        public int Legajo { get; set; }
        public string Nombre { set; get; }
        public string Apellido { get; set; }
    }
}
