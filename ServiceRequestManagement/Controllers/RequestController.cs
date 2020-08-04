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
            AngularRequestModel obj = new AngularRequestModel();
            
            foreach ( var request in allRequest){

                obj.RequestId = request.Id.ToString();
                obj.Title = request.Title;
                obj.RequestStatus = Enum.GetName(typeof(StatusRef), request.StatusId);
                obj.RequestType = Enum.GetName(typeof(RequestTypeRef), request.RequestTypeId);
                obj.RequestDepartment = Enum.GetName(typeof(DepartmentRef), request.DepartmentId);
                obj.RequestCategory = Enum.GetName(typeof(CategoryRef), request.CategoryId);
                obj.RequestSubCategory = Enum.GetName(typeof(SubCategoryRef), request.SubCategoryId);
                obj.RequestSummary = request.Summary;
                obj.Title = request.Title;
                obj.CreatedOn = request.CreatedOn;
                obj.LastModifiedOn = request.LastModifiedOn;
                obj.CreatedEmpId = request.CreatedEmpId;
                obj.AssignedEmpId = request.AssignedEmpId;
                obj.LastModifiedBy = request.LastModifiedBy;

                objList.Add(obj);

            }

          

            return Ok(objList);
        }

        // api/request/singlerequest/1

        [HttpGet("SingleRequest/{id}")]
        public IActionResult SingleRequest(int id)
        {
            var request = _service.GetRequestDetail(id);
            //
            AngularRequestModel obj = new AngularRequestModel();

            obj.RequestId = request.Id.ToString();
            obj.Title = request.Title;
            obj.RequestStatus  = Enum.GetName( typeof(StatusRef), request.StatusId);
            obj.RequestType = Enum.GetName(typeof(RequestTypeRef),request.RequestTypeId);
            obj.RequestDepartment = Enum.GetName(typeof(DepartmentRef),request.DepartmentId);
            obj.RequestCategory = Enum.GetName(typeof(CategoryRef), request.CategoryId);
            obj.RequestSubCategory = Enum.GetName(typeof(SubCategoryRef),request.SubCategoryId);
            obj.RequestSummary = request.Summary;
            obj.Title = request.Title;
            obj.CreatedOn = request.CreatedOn;
            obj.LastModifiedOn = request.LastModifiedOn;
            obj.CreatedEmpId = request.CreatedEmpId;
            obj.AssignedEmpId = request.AssignedEmpId;
            obj.LastModifiedBy = request.LastModifiedBy;

            return Ok(obj);
        }

        // api/request/updaterequest/1  
        [HttpPut("UpdateRequest/{id}")]
        public IActionResult UpdateRequest(int id, [FromBody] AngularRequestModel obj)
        {
            Request request = new Request();

            request.Id= Int32.Parse(obj.RequestId);
            request.Title=obj.Title;

   

            request.StatusId = (int)Enum.Parse(typeof(StatusRef),obj.RequestStatus);
            request.RequestTypeId = (int)Enum.Parse(typeof(RequestTypeRef), obj.RequestType);
            request.DepartmentId = (int)Enum.Parse(typeof(DepartmentRef), obj.RequestDepartment);
            request.CategoryId = (int)Enum.Parse(typeof(CategoryRef), obj.RequestCategory);
            request.SubCategoryId = (int)Enum.Parse(typeof(SubCategoryRef), obj.RequestSubCategory);

            request.Summary=obj.RequestSummary ;
            request.CreatedOn=obj.CreatedOn ;
            request.LastModifiedOn=obj.LastModifiedOn ;
            request.CreatedEmpId=obj.CreatedEmpId;
            request.AssignedEmpId= obj.AssignedEmpId ;
            request.LastModifiedBy = obj.LastModifiedBy;
            

            _service.UpdateRequest(id, request);

            return Ok(obj);

        }
    }
}
