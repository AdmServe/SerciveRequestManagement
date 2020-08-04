using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public interface IRequestService
    {
        List<Request> GetAllRequests();
        Request GetRequestDetail(int StausId);
        public void UpdateRequest(int serviceRequestId, Request serviceRequest);
    }
}
