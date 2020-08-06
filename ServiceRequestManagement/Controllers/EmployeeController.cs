using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequestManagement.Models;
using ServiceRequestManagement.RequestFormatter;
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
            var allEmployees = _service.GetAllEmployees();
            List<AngularEmployeeModel> objList = new List<AngularEmployeeModel>();
            foreach (var employee in allEmployees)
            {
                AngularEmployeeModel obj = new AngularEmployeeModel();
                obj.CopyData(employee);

                objList.Add(obj);
            }

            return Ok(objList);
        }

        // api/employee/employeedetail/1
        [HttpGet("[action]/{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var request = _service.GetEmployeeDetail(id);

            AngularEmployeeModel obj = new AngularEmployeeModel();
            obj.CopyData(request);

      
            return Ok(obj);
        }

        // api/employee/employeebydept/IT

        [HttpGet("[action]/{id}")]
        public IActionResult EmployeeByDept([FromRoute]string id)
        {
            var context = new SRMContext();
            int deptId = context.Department.FirstOrDefault(s => s.Name.Equals(id)).Id;
            var allEmployees = _service.GetEmployeeByDept(deptId);

            List<AngularEmployeeModel> objList = new List<AngularEmployeeModel>();
            foreach (var employee in allEmployees)
            {
                AngularEmployeeModel obj = new AngularEmployeeModel();
                obj.CopyData(employee);

                objList.Add(obj);
            }

            return Ok(objList);
        }

    }
}
