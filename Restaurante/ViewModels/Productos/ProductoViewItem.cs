using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.Productos
{
    public class ProductoViewItem
    {
        public string Descripcion { set; get; }
        public double Precio { set; get; }

        public ProductoViewItem(Producto producto)
        {
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
        }
    }
}