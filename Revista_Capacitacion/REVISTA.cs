//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Revista_Capacitacion
{
    using System;
    using System.Collections.Generic;
    
    public partial class REVISTAS
    {
        public int ID_REV { get; set; }
        public string TITULO_REV { get; set; }
        public string CB { get; set; }
        public string FECHA_CIRCULACION { get; set; }
        public int ID_CAT { get; set; }
        public string ROW_CREATE { get; set; }
        public int PRECIO { get; set; }
    
        public virtual M_CATEGORIAS M_CATEGORIAS { get; set; }
    }
}
