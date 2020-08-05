using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetAllEmployees()
        {
            var context = new SRMContext();
            return context.Employee.ToList();
        }

        public List<Employee> GetEmployeeByDept( int DeptId)
        {
            var context = new SRMContext();
            //Department deptId = context.Department.FirstOrDefault(s => s.Name.Equals(DepartmentName, StringComparison.OrdinalIgnoreCase));
            return context.Employee.Where(e => e.DepartmentId == DeptId ).ToList();
        }

        public Employee GetEmployeeDetail(int Id)
        {
            var context = new SRMContext();

            return context.Employee.FirstOrDefault(n => n.Id == Id);
        }
    }
}
