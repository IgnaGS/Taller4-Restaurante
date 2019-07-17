﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.ViewModels.Catalogos
{
    public class CatalogosViewModel
    {
        public int IdProveedor { get; set; }
        public IEnumerable<CatalogoViewItem> Catalogos { get; set; }

        public CatalogosViewModel()
        {
            Catalogos = Enumerable.Empty<CatalogoViewItem>();
        }
    }
}