using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequestManagement.Models;
using ServiceRequestManagement.Services;

namespace ServiceRequestManagement.Controllers
{
    // api/employee
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // api/employee/getallemployees

        [HttpGet("[action]")]
        public IActionResult GetAllEmployees()
        {
            var allStatus = _service.GetAllEmployees();
            return Ok(allStatus);
        }

        // api/employee/employeedetail/1
        [HttpGet("[action]/{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var request = _service.GetEmployeeDetail(id);

            return Ok(request);
        }

        // api/employee/employeebydept/IT

        [HttpGet("[action]/{id}")]
        public IActionResult EmployeeByDept([FromRoute]string id)
        {
            var context = new SRMContext();
            int DeptId = context.Department.FirstOrDefault(s => s.Name.Equals(id)).Id;
            var request = _service.GetEmployeeByDept(DeptId);

            return Ok(request);
        }

    }
}
