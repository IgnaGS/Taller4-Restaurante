using System.Linq;
using Servicios;
using Servicios.Interfaces;
using System.Web.Mvc;
using Restaurante.ViewModels.Empleados;

namespace Restaurante.Controllers
{
    public class EmpleadosController : Controller
    {
        #region Attributes

        private readonly IServicioEmpleado _ServicioEmpleado;

        #endregion

        #region Constructors

        public EmpleadosController()
        {
            _ServicioEmpleado = new ServicioEmpleado();
        }

        #endregion

        #region Index

        [HttpGet]
        [Route(Name = "Empleados_Index")]
        public ActionResult Index()
        {
            var model = new EmpleadosViewModel()
            {
                Empleados = _ServicioEmpleado.ObtenerEmpleados().Select(x => new EmpleadoViewItem(x))
            };

            return View(model);
        }

        #endregion
    }
}