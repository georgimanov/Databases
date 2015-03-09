namespace EntityFramework.HW
{
    using Data;
    using System.Data.Entity;

    /* Problem 7.	Employees with Corresponding Territories
        Your task is to create a class, which allows employees to access their corresponding territories as property of the type EntitySet<T> by inheriting the Employee entity class or by using a partial class.
    */

    public class ExtendedEmployee : Employee
    {
        public IDbSet<Town> Towns { get; set; }
    }
}
