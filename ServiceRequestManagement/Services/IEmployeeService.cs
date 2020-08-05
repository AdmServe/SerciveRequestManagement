using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public interface IEmployeeService
    {
       List<Employee> GetAllEmployees();
       Employee GetEmployeeDetail(int Id);
       List<Employee> GetEmployeeByDept(int DeptId);
    }
}
