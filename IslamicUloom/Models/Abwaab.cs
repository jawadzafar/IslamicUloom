//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IslamicUloom.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Abwaab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Abwaab()
        {
            this.Pages = new HashSet<Page>();
        }
    
        public int BaabId { get; set; }
        public string BaabName { get; set; }
        public int BaabNumber { get; set; }
        public int BookId { get; set; }
        public Nullable<int> BaabPage { get; set; }
    
        public virtual Book Book { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Page> Pages { get; set; }
    }
}
