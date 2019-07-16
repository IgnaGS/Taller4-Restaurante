using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Servicios;
using Servicios.Interfaces;

namespace Restaurante.ViewModels.Productos
{
    public class ProductoViewItem
    {
        private IServicioStock _ServicioStock = new ServicioStock();

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
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

            var stock = _ServicioStock.ObtenerStock(producto.Id);

            if (stock != null)
                StockActual = stock.Cantidad;
            else
                StockActual = 0;

        }
    }
}