using System;
using System.Linq;
using Servicios;
using Servicios.Interfaces;
using System.Web.Mvc;
using Restaurante.ViewModels.OrdenesCompras;
using System.Collections.Generic;

namespace Restaurante.Controllers
{
    public class OrdenesComprasController : Controller
    {
        #region Attributes

        private readonly IServicioOrdenCompra _ServicioOrdenCompra;
        private readonly IServicioProducto _ServicioProducto;
        private readonly IServicioEmpleado _ServicioEmpleado;
        private readonly IServicioProveedor _ServicioProveedor;
        private readonly IServicioStock _ServicioStock;

        #endregion

        #region Constructors

        public OrdenesComprasController()
        {
            _ServicioOrdenCompra = new ServicioOrdenCompra();
            _ServicioProducto = new ServicioProducto();
            _ServicioEmpleado = new ServicioEmpleado();
            _ServicioProveedor = new ServicioProveedor();
            _ServicioStock = new ServicioStock();
        }

        #endregion

        #region Index

        [HttpGet]
        [Route(Name = "OrdenesCompras_Index")]
        public ActionResult Index(string EstadoFiltrado = "", int IdProductoFiltrado = 0)
        {
            var model = new OrdenesComprasViewModel()
            {
                OrdenesCompras = _ServicioOrdenCompra.ObtenerOrdenesCompras().Select(x => new OrdenCompraViewItem(x)),

                //OrdenesCompras = _ServicioOrdenCompra.ObtenerOrdenesCompras(EstadoFiltrado, IdProductoFiltrado).Select(x => new OrdenCompraViewItem(x)),
                // Cargo los selectores desplegables para filtrar
                Estados = new List<SelectListItem> 
                {
                    new SelectListItem { Value = "Activa", Text = "Activa" },
                    new SelectListItem { Value = "Concretada", Text = "Concretada" },
                    new SelectListItem { Value = "Cancelada", Text = "Cancelada" }
                },
                Productos = new SelectList(_ServicioProducto.ObtenerProductos(), "Id", "Descripcion")
            };

            //if (!String.IsNullOrEmpty(EstadoFiltrado))
            //{
            //    model.OrdenesCompras.Where(o => o.Estado == EstadoFiltrado);
            //}

            //if (IdProductoFiltrado > 0)
            //{
            //    model.OrdenesCompras.Where(o => o.IdProducto == IdProductoFiltrado);
            //}

            return View(model);
        }

        #endregion

        #region Nueva OrdenCompra

        [HttpGet]
        [Route("NuevaOrdenSinProducto", Name = "OrdenesCompras_NuevaOrdenSinProducto")]
        public ActionResult NuevaOrdenSinProducto()
        {
            var model = new NuevaOrdenCompraViewModel()
            {
                Productos = new SelectList(_ServicioProducto.ObtenerProductosDisponibles(), "Id", "Descripcion")
            };

            return View(model);
        }

        [HttpPost]
        [Route("NuevaOrdenSinProducto", Name = "OrdenesCompras_NuevaSinProducto_Post")]
        public ActionResult NuevaOrdenSinProducto(NuevaOrdenCompraViewModel model)
        {
            if (model.IdProducto <= 0)
                ModelState.AddModelError("IdProducto", "Debe seleccionar un producto.");

            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("NuevaOrdenConProducto", new { model.IdProducto });
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
        public ActionResult NuevaOrdenConProducto(int IdProducto)
        {
            var model = new NuevaOrdenCompraViewModel()
            {
                IdProducto = IdProducto,
                Producto = _ServicioProducto.ObtenerProducto(IdProducto).Descripcion,
                Empleados = new SelectList(_ServicioEmpleado.ObtenerEmpleados(), "Id", "Nombre"),
                Proveedores = new SelectList(_ServicioProveedor.ObtenerProveedores(IdProducto), "Id", "Descripcion")
            };

            return View(model);
        }

        [HttpPost]
        [Route("NuevaOrdenConProducto", Name = "OrdenesCompras_NuevaConProducto_Post")]
        public ActionResult NuevaOrdenConProducto(NuevaOrdenCompraViewModel model)
        {
            if (model.IdProducto <= 0)
                ModelState.AddModelError("IdProducto", "Debe seleccionar un producto.");

            if (model.IdEmpleado <= 0)
                ModelState.AddModelError("IdEmpleado", "Debe seleccionar un empleado.");

            if (model.IdProveedor <= 0)
                ModelState.AddModelError("IdProveedor", "Debe seleccionar un proveedor.");

            if (model.Cantidad <= 0)
                ModelState.AddModelError("Cantidad", "La cantidad debe ser mayor a 0.");

            if (model.FechaEntrega <= System.DateTime.Now)
                ModelState.AddModelError("FechaEntrega", "La fecha de entrega debe ser posterior a hoy.");

            try
            {
                if (ModelState.IsValid)
                {
                    _ServicioOrdenCompra.AddOrdenCompra(model.IdEmpleado, model.IdProducto, model.Cantidad, model.FechaEntrega, model.IdProveedor);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            model.Empleados = new SelectList(_ServicioEmpleado.ObtenerEmpleados(), "Id", "Nombre");
            model.Proveedores = new SelectList(_ServicioProveedor.ObtenerProveedores(model.IdProducto), "Id", "Descripcion");
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