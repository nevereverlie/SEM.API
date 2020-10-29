using System.Collections.Generic;
using System.Threading.Tasks;
using Revisory_Control.API.Models;

namespace Revisory_Control.API.Interfaces
{
    public interface IDepartmentRepository
    {
         Task<IEnumerable<Department>> GetDepartments();
         Task<Department> GetDepartmentById(int depId);
         Task<Department> GetDepartmentByName(string depName);
    }
}