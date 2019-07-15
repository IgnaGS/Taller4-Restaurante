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
    public class ServicioStock : IServicioStock
    {
        public Stock ObtenerStock(Producto producto)
        {
            using (var db = new AppDbContext())
            {
                return db
                    .Stocks.Where(s => s.Producto = producto)
                    //.Select(s => s.Producto)
                    //.Where(p => p.Id = idProducto)
                    ;
            }
        }
    }
}
