using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequestManagement.Services;

namespace ServiceRequestManagement.Controllers
{
    // api/department
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }
        // api/department/getdepartments
        [HttpGet("[action]")]
        public IActionResult GetDepartments()
        {
            var allDepartments = _service.GetAllDepartment();
            return Ok(allDepartments);
        }
        // api/department/department/1 
        [HttpGet("SingleDepartment/{id}")]
        public IActionResult Department(int id)
        {
            var request = _service.GetDepartment(id);
            return Ok(request);
        }
    }
}
