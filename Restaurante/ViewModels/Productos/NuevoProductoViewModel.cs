using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.Productos
{
    public class NuevoProductoViewModel
    {
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int StockInicial { get; set; }
        public string Disponible { get; set; }

        public NuevoProductoViewModel()
        {

        }
    }
}