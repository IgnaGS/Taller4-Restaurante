using System;
using System.Linq;
using Servicios;
using Servicios.Interfaces;
using System.Web.Mvc;
using Restaurante.ViewModels.Catalogos;

namespace Restaurante.Controllers
{
    public class CatalogosController : Controller
    {
        #region Attributes

        private readonly IServicioCatalogo _ServicioCatalogo;

        #endregion

        #region Constructors

        public CatalogosController()
        {
            _ServicioCatalogo = new ServicioCatalogo();
        }

        #endregion

        #region Index

        [HttpGet]
        [Route(Name = "Catalogos_Index")]
        public ActionResult Index(int idProveedor, string proveedor)
        {
            var model = new CatalogosViewModel()
            {
                IdProveedor = idProveedor,
                Proveedor = proveedor,
                Catalogos = _ServicioCatalogo.ObtenerCatalogosPorProveedor(idProveedor).Select(x => new CatalogoViewItem(x))
            };

            return View(model);
        }

        #endregion

        #region Nuevo

        [HttpGet]
        [Route("Nuevo", Name = "Catalogos_Nuevo")]
        public ActionResult Nuevo(int idProveedor, string proveedor)
        {
            var model = new NuevoCatalogoViewModel()
            {
                IdProveedor = idProveedor,
                Proveedor = proveedor,
                Productos = new SelectList(_ServicioCatalogo.ObtenerProductosFueraDeCatalogoProveedor(idProveedor), "Id", "Descripcion")
            };

            return View(model);
        }

        [HttpPost]
        [Route("Nuevo", Name = "Catalogos_Nuevo_Post")]
        public ActionResult Nuevo(NuevoCatalogoViewModel model)
        {
            if (model.IdProducto <= 0)
                ViewBag.ErrorMessage = "Debe seleccionar un Producto de la lista";

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioCatalogo.AddCatalogo(
                        idProveedor: model.IdProveedor,
                        idProducto: model.IdProducto
                        );

                    return RedirectToAction("Index", new { idProveedor = model.IdProveedor });
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            model.Productos = new SelectList(_ServicioCatalogo.ObtenerProductosFueraDeCatalogoProveedor(model.IdProveedor), "Id", "Descripcion");

            return View(model);
        }

        #endregion

        #region Eliminar

        [HttpGet]
        [Route("Eliminar")]
        public ActionResult Eliminar(int idProveedor, int idProducto)
        {
            var catal = _ServicioCatalogo.ObtenerCatalogo(idProveedor, idProducto);
            return View(new CatalogoViewItem(catal));
        }

        [HttpPost]
        [Route("Eliminar", Name = "Catalogos_Eliminar")]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var catalogo = _ServicioCatalogo.ObtenerCatalogo(id);
                _ServicioCatalogo.DeleteCatalogo(catalogo.Id);

                return RedirectToAction("Index", new { idProveedor = catalogo.ProveedorId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }

        #endregion

    }
}