using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_EMPLEADOS_IT.Models.ViewModel
{
    public class EmpleadoVM
    {
        public Empleado oEmpleado { get; set; }
        public List<SelectListItem> oListaCargo { get; set; }

    }
}
