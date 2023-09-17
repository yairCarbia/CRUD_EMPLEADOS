using System;
using System.Collections.Generic;

namespace CRUD_EMPLEADOS_IT.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public int? IdCargo { get; set; }

    public virtual Cargo? oCargo { get; set; }
}
