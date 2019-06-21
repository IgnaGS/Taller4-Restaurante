using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Servicios;
using Servicios.Interfaces;
using System.Web.Mvc;
using Restaurante.ViewModels.Productos;

namespace Restaurante.Controllers
{
    public class ProductosController : Controller
    {
        #region Attributes

        private readonly IServicioProducto _ServicioProducto;

        #endregion

        #region Constructors

        public ProductosController()
        {
            _ServicioProducto = new ServicioProducto();
        }

        #endregion

        #region Get Methods

        [HttpGet]
        [Route(Name = "Productos_Index")]
        public ActionResult Index()
        {
            var model = new ProductosViewModel()
            {
                Productos = _ServicioProducto.ObtenerProductos().Select(x => new ProductoViewItem(x))
            };

            return View(model);
        }

        [HttpGet]
        [Route("Nuevo", Name = "Productos_Nuevo")]
        public ActionResult Nuevo()
        {
            return View( new NuevoProductoViewModel() );
        }

        [HttpPost]
        [Route("Nuevo", Name = "Productos_Nuevo_Post")]
        public ActionResult Nuevo(NuevoProductoViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Descripcion))
                ModelState.AddModelError("Descripción", "Debe ingresar la descripción del prodcuto.");

            if (model.Precio <= 0)
                ModelState.AddModelError("Precio", "Debe ingresar el precio del producto");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioProducto.AddProducto(
                        descripcion: model.Descripcion,
                        precio: model.Precio
                        );

                    return RedirectToRoute("Productos_Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        #endregion
    }
}