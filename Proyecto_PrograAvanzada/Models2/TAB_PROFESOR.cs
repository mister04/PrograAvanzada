//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_PrograAvanzada.Models2
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAB_PROFESOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAB_PROFESOR()
        {
            this.TAB_CURSOS = new HashSet<TAB_CURSOS>();
        }
    
        public int ID_PROFESOR { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_MAT { get; set; }
        public string APELLIDO_PAT { get; set; }
        public string CEDULA { get; set; }
        public Nullable<int> ID_ROL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAB_CURSOS> TAB_CURSOS { get; set; }
        public virtual TAB_ROL TAB_ROL { get; set; }
    }
}