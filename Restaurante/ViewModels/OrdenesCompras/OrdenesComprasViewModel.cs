using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurante.ViewModels.OrdenesCompras
{
    public class OrdenesComprasViewModel
    {
        public IEnumerable<OrdenCompraViewItem> OrdenesCompras { get; set; }

        public IEnumerable<SelectListItem> Estados { get; set; }
        public string EstadoSeleccionado { get; set; }
        public SelectList Productos { get; set; }
        public int IdProductoSeleccionado { get; set; }

        public OrdenesComprasViewModel()
        {
            OrdenesCompras = Enumerable.Empty<OrdenCompraViewItem>();
            Estados = Enumerable.Empty<SelectListItem>();
            //Prodcutos = Enumerable.Empty<SelectListItem>();
        }
    }
}