using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Catalogo
    {
        public int Id { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
    }
}
