using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.Services
{
    public class StatusService : IStatusService
    {

        public List<Status> GetAllStatus()
        {
            var context = new SRMContext();
            return context.Status.ToList();
        }

        public Status GetStatusDetail(int Id)
        {
            var context = new SRMContext();

            return context.Status.FirstOrDefault(n => n.Id == Id);
        }
    }
}
