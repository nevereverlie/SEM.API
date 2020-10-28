using System.Collections.Generic;

namespace Revisory_Control.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}