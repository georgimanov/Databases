//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Photography
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photograph
    {
        public Photograph()
        {
            this.Albums = new HashSet<Album>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int EquipmentId { get; set; }
        public int UserId { get; set; }
        public string Link { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
