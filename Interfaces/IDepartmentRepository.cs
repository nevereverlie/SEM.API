using System.Collections.Generic;
using System.Threading.Tasks;
using SEM.API.Models;

namespace SEM.API.Interfaces
{
    public interface IDepartmentRepository
    {
         Task<IEnumerable<Department>> GetDepartments();
         Task<Department> GetDepartmentById(int depId);
         Task<Department> GetDepartmentByName(string depName);
    }
}