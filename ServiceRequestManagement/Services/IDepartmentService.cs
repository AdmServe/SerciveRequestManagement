using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartment();
        Department GetDepartment(int Id);
    }
}
