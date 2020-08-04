using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceRequestManagement.Models;
using ServiceRequestManagement.Services;


namespace ServiceRequestManagement.Controllers
{
    //api/status
    [Route("api/[controller]")]

    public class StatusController : Controller
    {
        private readonly IStatusService _service;
        public StatusController(IStatusService service)
        {
            _service = service;
        }
       
        [HttpGet("[action]")]
        public IActionResult GetAllStatus()
        {
            var allStatus = _service.GetAllStatus();
            return Ok(allStatus);
        }
        [HttpGet("SingleStatus/{id}")]
        public IActionResult SingleStatus(int id)
        {
            var request = _service.GetStatusDetail(id);
            
            return Ok(request);
        }


    }
}
