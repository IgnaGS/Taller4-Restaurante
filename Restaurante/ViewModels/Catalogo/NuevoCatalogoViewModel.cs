using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Restaurante.ViewModels.Catalogos
{
    public class NuevoCatalogoViewModel
    {
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }

        public NuevoCatalogoViewModel()
        {

        }
    }
}