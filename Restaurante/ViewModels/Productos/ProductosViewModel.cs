using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.Productos
{
    public class ProductosViewModel
    {
        public IEnumerable<ProductoViewItem> Productos { get; set; }

        public ProductosViewModel()
        {
            Productos = Enumerable.Empty<ProductoViewItem>();
        }
    }
}