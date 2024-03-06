using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_datos_de_un_estudiante
{
    internal class Estudiante: persona
    {
        string nombre { get; set; }
        string email { get; set; }
        string curso { get; set; }
        string direccion { get; set; }
        string telefono { get; set; }
         string seccion { get; set; }

        string maetro { get; set; }


    }
}
