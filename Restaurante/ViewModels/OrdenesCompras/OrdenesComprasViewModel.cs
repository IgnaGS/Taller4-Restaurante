using System.Collections.Generic;
using System.Linq;

namespace Restaurante.ViewModels.OrdenesCompras
{
    public class OrdenesComprasViewModel
    {
        public IEnumerable<OrdenCompraViewItem> OrdenesCompras { get; set; }

        public OrdenesComprasViewModel()
        {
            OrdenesCompras = Enumerable.Empty<OrdenCompraViewItem>();
        }
    }
}