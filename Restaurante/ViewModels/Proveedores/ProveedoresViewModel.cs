using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.Proveedores
{
    public class ProveedoresViewModel
    {
        public IEnumerable<ProveedorViewItem> Proveedores { get; set; }

        public ProveedoresViewModel()
        {
            Proveedores = Enumerable.Empty<ProveedorViewItem>();
        }
    }
}