using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Revisory_Control.API.Interfaces;
using Revisory_Control.API.Models;
using RevisoryControl.API.Data;

namespace Revisory_Control.API.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartmentById(int depId)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == depId);
        }

        public async Task<Department> GetDepartmentByName(string depName)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == depName);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}