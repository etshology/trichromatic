//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trichromatic.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubSection
    {
        public SubSection()
        {
            this.ProductGroups = new HashSet<ProductGroup>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SID { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
    
        public virtual ICollection<ProductGroup> ProductGroups { get; set; }
        public virtual Section Section { get; set; }
    }
}
