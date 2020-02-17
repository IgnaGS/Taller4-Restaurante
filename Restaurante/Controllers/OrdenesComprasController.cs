using System;
using System.Linq;
using Servicios;
using Servicios.Interfaces;
using System.Web.Mvc;
using Restaurante.ViewModels.OrdenesCompras;

namespace Restaurante.Controllers
{
    public class OrdenesComprasController : Controller
    {
        #region Attributes

        private readonly IServicioOrdenCompra _ServicioOrdenCompra;
        private readonly IServicioProducto _ServicioProducto;
        private readonly IServicioEmpleado _ServicioEmpleado;
        private readonly IServicioStock _ServicioStock;

        #endregion

        #region Constructors

        public OrdenesComprasController()
        {
            _ServicioOrdenCompra = new ServicioOrdenCompra();
            _ServicioProducto = new ServicioProducto();
            _ServicioEmpleado = new ServicioEmpleado();
            _ServicioStock = new ServicioStock();
        }

        #endregion

        #region Index

        [HttpGet]
        [Route(Name = "OrdenesCompras_Index")]
        public ActionResult Index()
        {
            var model = new OrdenesComprasViewModel()
            {
                OrdenesCompras = _ServicioOrdenCompra.ObtenerOrdenesCompras().Select(x => new OrdenCompraViewItem(x))
            };

            return View(model);
        }

        #endregion

        #region Nueva OrdenCompra

        [HttpGet]
        [Route("Nueva", Name = "OrdenesCompras_Nueva")]
        public ActionResult Nueva()
        {
            var model = new NuevaOrdenCompraViewModel() 
            {
                Productos = new SelectList(_ServicioProducto.ObtenerProductos(), "Id", "Descripcion"),
                Empleados = new SelectList(_ServicioEmpleado.ObtenerEmpleados(), "Id", "Nombre")
            }

            return View(model);
        }

        [HttpPost]
        [Route("Nueva", Name = "OrdenesCompras_Nueva_Post")]
        public ActionResult Nueva(NuevaOrdenCompraViewModel model)
        {
            //if (string.IsNullOrWhiteSpace(model.Descripcion))
            //    ModelState.AddModelError("Descripción", "Debe ingresar la descripción del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Direccion))
            //    ModelState.AddModelError("Direccion", "Debe ingresar la dirección del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Mail))
            //    ModelState.AddModelError("Mail", "Debe ingresar el correo electrónico del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Telefono))
            //    ModelState.AddModelError("Telefono", "Debe ingresar el teléfono del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Disponible))
            //    ModelState.AddModelError("Disponible", "Debe seleccionar si el OrdenCompra estará disponible o no.");

            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("NuevaOrdenConProducto", new { model.IdEmpleado, model.IdProducto, model.Cantidad });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [HttpGet]
        [Route("NuevaOrdenConProducto", Name = "OrdenesCompras_NuevaConProducto")]
        public ActionResult NuevaOrdenConProducto(int IdEmpleado, int IdProducto, int Cantidad)
        {
            var model = new NuevaOrdenCompraViewModel()
            {
                Productos = new SelectList(_ServicioProducto.ObtenerProductos(), "Id", "Descripcion"),
                Empleados = new SelectList(_ServicioEmpleado.ObtenerEmpleados(), "Id", "Nombre")
            }

            return View(model);
        }

        [HttpPost]
        [Route("NuevaOrdenConProducto", Name = "OrdenesCompras_Nueva_Post")]
        public ActionResult NuevaOrdenConProducto(NuevaOrdenCompraViewModel model)
        {
            //if (string.IsNullOrWhiteSpace(model.Descripcion))
            //    ModelState.AddModelError("Descripción", "Debe ingresar la descripción del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Direccion))
            //    ModelState.AddModelError("Direccion", "Debe ingresar la dirección del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Mail))
            //    ModelState.AddModelError("Mail", "Debe ingresar el correo electrónico del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Telefono))
            //    ModelState.AddModelError("Telefono", "Debe ingresar el teléfono del proveedor.");

            //if (string.IsNullOrWhiteSpace(model.Disponible))
            //    ModelState.AddModelError("Disponible", "Debe seleccionar si el OrdenCompra estará disponible o no.");

            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("NuevaOrdenConProducto", new { model.IdEmpleado, model.IdProducto, model.Cantidad });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        #endregion

        #region Concretar OrdenCompra

        [HttpGet]
        [Route("Concretar")]
        public ActionResult Concretar(int idOrdenCompra)
        {
            var ordenCompra = _ServicioOrdenCompra.ObtenerOrdenCompra(idOrdenCompra);
            return View(new OrdenCompraViewItem(ordenCompra));
        }

        [HttpPost]
        [Route("Concretar", Name = "OrdenCompra_Concretar")]
        public ActionResult Concretar(OrdenCompraViewItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioStock.UpdateStock(idProducto: model.IdProducto, cantidad: model.Cantidad);
                    _ServicioOrdenCompra.ContretarOrdenCompra(idOrdenCompra: model.Id);

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

        #region Cancelar OrdenCompra

        [HttpGet]
        [Route("Cancelar")]
        public ActionResult Cancelar(int idOrdenCompra)
        {
            var ordenCompra = _ServicioOrdenCompra.ObtenerOrdenCompra(idOrdenCompra);
            return View(new OrdenCompraViewItem(ordenCompra));
        }

        [HttpPost]
        [Route("Cancelar", Name = "OrdenCompra_Cancelar")]
        public ActionResult Cancelar(OrdenCompraViewItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioOrdenCompra.CancelarOrdenCompra(idOrdenCompra: model.Id);

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