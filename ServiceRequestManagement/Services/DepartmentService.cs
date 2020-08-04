using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public class DepartmentService : IDepartmentService

    {
        public List<Department> GetAllDepartment()
        {
            var context = new SRMContext();
            return context.Department.ToList();
        }

        public Department GetDepartment(int Id)
        {
            var context = new SRMContext();

            return context.Department.FirstOrDefault(n => n.Id == Id);
        }
    }
}
