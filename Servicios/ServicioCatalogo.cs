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
    public class ServicioCatalogo : IServicioCatalogo
    {
        public Catalogo ObtenerCatalogo(Proveedor proveedor)
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Catalogos.Where(c => c.Proveedor = proveedor && c.Producto.Disponible.Equals("SI"))
                    ;
            }
        }
    }
}
