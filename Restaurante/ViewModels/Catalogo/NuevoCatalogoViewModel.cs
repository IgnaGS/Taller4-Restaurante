using System.Web.Mvc;

namespace Restaurante.ViewModels.Catalogos
{
    public class NuevoCatalogoViewModel
    {
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public int IdProducto { get; set; }
        public SelectList Productos { get; set; }

        public NuevoCatalogoViewModel()
        {

        }
    }
}