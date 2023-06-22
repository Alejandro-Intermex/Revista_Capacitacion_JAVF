using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Revista_Capacitacion.Models
{
    public class ClsRegistro
    {
        public string titulo { get; set; }
        public string CB { get; set; }
        public DateTime Fecha { get; set; }
        public int Cat_ID { get; set; }
        public DateTime fechaReg { get; set; }
        public float precio { get; set; }
    }
}