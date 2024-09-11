using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSistema.Models
{
    public class Empleado
    {
        public int IdEmpleado{ get; set; }
        
        public string NumeroDocumento{ get; set; }

        public string NombreCompleto{   get; set; }

        public int Sueldo { get; set; }
    }
}