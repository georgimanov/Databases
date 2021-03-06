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
    
    public partial class Employees
    {
        public Employees()
        {
            this.Employees1 = new HashSet<Employees>();
            this.ProjectsEmployees = new HashSet<ProjectsEmployees>();
            this.Reports = new HashSet<Reports>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal YearSalary { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public int DepartmentId { get; set; }
    
        public virtual Departments Departments { get; set; }
        public virtual ICollection<Employees> Employees1 { get; set; }
        public virtual Employees Employees2 { get; set; }
        public virtual ICollection<ProjectsEmployees> ProjectsEmployees { get; set; }
        public virtual ICollection<Reports> Reports { get; set; }
    }
}
