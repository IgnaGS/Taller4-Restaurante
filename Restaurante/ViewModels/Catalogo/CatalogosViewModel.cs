using System.Collections.Generic;
using System.Linq;

namespace Restaurante.ViewModels.Catalogos
{
    public class CatalogosViewModel
    {
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public IEnumerable<CatalogoViewItem> Catalogos { get; set; }

        public CatalogosViewModel()
        {
            Catalogos = Enumerable.Empty<CatalogoViewItem>();
        }
    }
}