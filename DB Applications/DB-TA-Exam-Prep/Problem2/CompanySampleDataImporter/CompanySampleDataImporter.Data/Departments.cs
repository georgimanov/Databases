//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanySampleDataImporter.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Departments
    {
        public Departments()
        {
            this.Employees = new HashSet<Employees>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
