using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Servicios;
using Servicios.Interfaces;
using System.Web.Mvc;
using Restaurante.ViewModels.Proveedores;

namespace Restaurante.Controllers
{
    public class ProveedoresController : Controller
    {
        #region Attributes

        private readonly IServicioProveedor _ServicioProveedor;

        #endregion

        #region Constructors

        public ProveedoresController()
        {
            _ServicioProveedor = new ServicioProveedor();
        }

        #endregion

        #region Index

        [HttpGet]
        [Route(Name = "Proveedores_Index")]
        public ActionResult Index()
        {
            var model = new ProveedoresViewModel()
            {
                Proveedores = _ServicioProveedor.ObtenerProveedores().Select(x => new ProveedorViewItem(x))
            };

            return View(model);
        }

        #endregion

        #region Nuevo Proveedor

        [HttpGet]
        [Route("Nuevo", Name = "Proveedores_Nuevo")]
        public ActionResult Nuevo()
        {
            return View( new NuevoProveedorViewModel() { } );
        }

        [HttpPost]
        [Route("Nuevo", Name = "Proveedores_Nuevo_Post")]
        public ActionResult Nuevo(NuevoProveedorViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Descripcion))
                ModelState.AddModelError("Descripción", "Debe ingresar la descripción del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Direccion))
                ModelState.AddModelError("Direccion", "Debe ingresar la dirección del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Mail))
                ModelState.AddModelError("Mail", "Debe ingresar el correo electrónico del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Telefono))
                ModelState.AddModelError("Telefono", "Debe ingresar el teléfono del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Disponible))
                ModelState.AddModelError("Disponible", "Debe seleccionar si el Proveedor estará disponible o no.");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioProveedor.AddProveedor(
                        descripcion: model.Descripcion,
                        direccion: model.Direccion,
                        mail: model.Mail,
                        telefono: model.Telefono,
                        disponible: model.Disponible
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

        #region Editar Proveedor

        [HttpGet]
        [Route("Editar")]
        public ActionResult Editar(int id)
        {
            var prov = _ServicioProveedor.ObtenerProveedor(id);
            return View(new ProveedorViewItem(prov));
        }

        [HttpPost]
        [Route("Editar", Name = "Proveedor_Editar")]
        public ActionResult Editar(ProveedorViewItem model)
        {
            if (string.IsNullOrWhiteSpace(model.Descripcion))
                ModelState.AddModelError("Descripción", "Debe ingresar la descripción del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Direccion))
                ModelState.AddModelError("Direccion", "Debe ingresar la dirección del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Mail))
                ModelState.AddModelError("Mail", "Debe ingresar el correo electrónico del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Telefono))
                ModelState.AddModelError("Telefono", "Debe ingresar el teléfono del proveedor.");

            if (string.IsNullOrWhiteSpace(model.Disponible))
                ModelState.AddModelError("Disponible", "Debe seleccionar si el Proveedor estará disponible o no.");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioProveedor.UpdateProveedor(
                        id: model.Id,
                        descripcion: model.Descripcion,
                        direccion: model.Direccion,
                        mail: model.Mail,
                        telefono: model.Telefono,
                        disponible: model.Disponible
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