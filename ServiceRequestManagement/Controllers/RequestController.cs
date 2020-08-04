using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceRequestManagement.Models;
using ServiceRequestManagement.Services;

namespace ServiceRequestManagement.Controllers
{
    // api/request
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private readonly IRequestService _service;
             
        public RequestController(IRequestService service)
        {
            _service = service;
        }
        // api/request/getallrequests

        [HttpGet("[action]")]
        public IActionResult GetAllRequests()
        {
            var allRequest = _service.GetAllRequests();
            return Ok(allRequest);
        }

        // api/request/singlerequest/1

        [HttpGet("SingleRequest/{id}")]
        public IActionResult SingleRequest(int id)
        {
            var request = _service.GetRequestDetail(id);
            return Ok(request);
        }

        // api/request/updaterequest/1
        [HttpPut("UpdateRequest/{id}")]
        public IActionResult UpdateRequest(int id, [FromBody] Request request)
        {
            _service.UpdateRequest(id, request);

            return Ok(request);

        }
    }
}
