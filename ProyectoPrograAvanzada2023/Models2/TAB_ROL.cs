//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoPrograAvanzada2023.Models2
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAB_ROL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAB_ROL()
        {
            this.TAB_PROFESOR = new HashSet<TAB_PROFESOR>();
            this.TAB_USER = new HashSet<TAB_USER>();
        }
    
        public int ID_ROL { get; set; }
        public string ROL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAB_PROFESOR> TAB_PROFESOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAB_USER> TAB_USER { get; set; }
    }
}