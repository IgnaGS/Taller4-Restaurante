using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
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
        public ActionResult Index(int idProveedor)
        {
            var model = new CatalogosViewModel()
            {
                IdProveedor = idProveedor,
                Catalogos = _ServicioCatalogo.ObtenerCatalogos(idProveedor).Select(x => new CatalogoViewItem(x))
            };

            return View(model);
        }

        #endregion

        #region Nuevo

        [HttpGet]
        [Route("Nuevo", Name = "Catalogos_Nuevo")]
        public ActionResult Nuevo(int idProveedor)
        {
            return View( new NuevoCatalogoViewModel()
            {
                IdProveedor = idProveedor
            } );
        }

        [HttpPost]
        [Route("Nuevo", Name = "Catalogos_Nuevo_Post")]
        public ActionResult Nuevo(NuevoCatalogoViewModel model)
        {
            if (model.IdProveedor <= 0)
                ModelState.AddModelError("IdProveedor", "Debe seleccionar el Proveedor del Catálogo");

            if (model.IdProducto <= 0)
                ModelState.AddModelError("IdProducto", "Debe seleccionar el Producto del Catalogo");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioCatalogo.AddCatalogo(
                        idProveedor: model.IdProveedor,
                        idProducto: model.IdProducto
                        );

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

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
        public ActionResult Eliminar(CatalogoViewItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioCatalogo.DeleteCatalogo(
                        idProveedor: model.IdProveedor,
                        idProducto: model.IdProducto
                        );

                    return RedirectToAction("Index");
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