using System.Collections.Generic;

namespace SEM.API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Company Company { get; set; }
        public ICollection<User> Users { get; set; }
    }
}