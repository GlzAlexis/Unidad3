using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class TareaInf
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string FechaDeInicio {get; set;}
        public string FechaEntrega { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }
    }
}
