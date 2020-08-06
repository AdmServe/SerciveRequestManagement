using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ServiceRequestManagement.Models;
using ServiceRequestManagement.RequestFormatter;
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
           List<AngularRequestModel> objList= new List<AngularRequestModel>();
           
            
            foreach ( var request in allRequest){

                AngularRequestModel obj = new AngularRequestModel();
                obj.CopyData(request);

                objList.Add(obj);

            }

          

            return Ok(objList);
        }

        // api/request/singlerequest/1

        [HttpGet("SingleRequest/{id}")]
        public IActionResult SingleRequest(int id)
        {
            var request = _service.GetRequestDetail(id);
           
            AngularRequestModel obj = new AngularRequestModel();
             obj.CopyData(request);

            return Ok(obj);
        }

        // api/request/updaterequest/1  
        [HttpPut("UpdateRequest/{id}")]
        public IActionResult UpdateRequest(int id, [FromBody] AngularRequestModel obj)
        {

            SRMContext context = new SRMContext();
            //string Comment = obj.Comment;
            Comments c = new Comments();
            c.Comment = obj.Comment;
            c.EmployeeId = obj.AssignedEmpId;
            c.RequestId = Int32.Parse(obj.RequestId);
            c.CreatedOn = DateTimeOffset.Now;
            c.LastModifiedOn = DateTimeOffset.Now;
            c.LogTime = DateTimeOffset.MinValue;
            c.LastModifiedBy = "MAYURESH";

            context.Comments.Add(c);

            context.SaveChanges();
            _service.UpdateRequest(id, obj.SendData());

            return Ok(obj);

        }
    }
}
