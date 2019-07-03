using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.Productos
{
    public class ProductoViewItem
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Disponible { get; set; }

        public ProductoViewItem()
        {

        }

        public ProductoViewItem(Producto producto)
        {
            Id = producto.Id;
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
            Disponible = producto.Disponible;
        }
    }
}