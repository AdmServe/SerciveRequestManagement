using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public class RequestService : IRequestService
    {
        public List<Request> GetAllRequests()
        {
            var context = new SRMContext();
            return context.Request.ToList();
        }    

        public Request GetRequestDetail(int Id)
        {
            var context = new SRMContext();
           Request request= context.Request.FirstOrDefault(n => n.Id == Id );
          //  request.Category = context.Category.FirstOrDefault(n => n.Id == request.CategoryId);
            return request;
        }

        public void UpdateRequest(int serviceRequestId, Request serviceRequest)
        {
            var context = new SRMContext();

            var oldRequest = context.Request.FirstOrDefault(n => n.Id == serviceRequestId);
            if (oldRequest != null)
            {
                //oldRequest.CategoryId = serviceRequest.CategoryId;
                oldRequest.AssignedEmpId = serviceRequest.AssignedEmpId;
               // oldRequest.DepartmentId = serviceRequest.DepartmentId;
                oldRequest.StatusId = serviceRequest.StatusId;
                oldRequest.Summary = serviceRequest.Summary;
               // oldRequest.Title = serviceRequest.Title;
               // oldRequest.Comments = serviceRequest.Comments;
                oldRequest.LastModifiedOn = serviceRequest.LastModifiedOn;
                oldRequest.LastModifiedBy = serviceRequest.LastModifiedBy;

                context.SaveChanges();

            }

        }
    }
}
