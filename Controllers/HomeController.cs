using CRUD_EMPLEADOS_IT.Models;
using CRUD_EMPLEADOS_IT.Models.ViewModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace CRUD_EMPLEADOS_IT.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpleadosCrudContext _context;
        public HomeController(EmpleadosCrudContext DBContext )
        {
            _context = DBContext;   
        }
        public IActionResult Index()
        {
            List<Empleado> list = _context.Empleados.Include(c => c.oCargo).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Empleado_Detalle(int idEmpleado)
        {
            EmpleadoVM empleadoVM = new EmpleadoVM()
            {
                oEmpleado = new Empleado(),
                oListaCargo = _context.Cargos.Select(cargo => new SelectListItem() {
                    Text = cargo.Descripcion,
                    Value = cargo.IdCargo.ToString(),
                }).ToList()
        };
            if (idEmpleado!=0)
            {
                empleadoVM.oEmpleado = _context.Empleados.Find(idEmpleado);
            }
            return View(empleadoVM);
        }
        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM empleado)
        {
            if (empleado.oEmpleado.IdEmpleado == 0) 
            {
                _context.Empleados.Add(empleado.oEmpleado);
            }else
            {
                _context.Empleados.Update(empleado.oEmpleado);
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        
        [HttpGet]
        public IActionResult Eliminar(int idEmpleado)
        {
            Empleado oEmpleado = _context.Empleados.Find(idEmpleado);
            //Empleado empleado = _context.Empleados.Include(cargo => cargo.oCargo).Where(e => e.IdEmpleado == idEmpleado).FirstOrDefault();
                return View(oEmpleado);
        }
        [HttpPost]
        public IActionResult Eliminar(Empleado oEmpleado)
        {
            _context.Remove(oEmpleado);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}