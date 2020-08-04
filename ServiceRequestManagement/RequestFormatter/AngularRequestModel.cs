using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequestManagement.RequestFormatter
{
    /*enum StatusRef
    {
        Open=1,
        InProgress,
        Close
    }
    enum RequestTypeRef
    {
        Service=1,
        Issue
    }
    enum DepartmentRef
    {
        IT=1,
        Admin,
        Finance,
        Other

    }
    enum CategoryRef
    {
        Hardware=1,
        Software,
        TravelBooking,
        SalaryIssue
    }
    enum SubCategoryRef
    {
        Laptop=5,
        Mouse,
        Keyboard,
        InternationalTravelTicket,
        SalaryCalculation
    }
    */
    public class AngularRequestModel
    {
        public string RequestId { get; set; }
        public string Title { get; set; }

        public string RequestDepartment { get; set; }
        public string RequestCategory { get; set; }
        public string RequestSubCategory { get; set; }
        public string RequestStatus { get; set; }
        public string RequestSummary { get; set; }
        
        public string RequestType { get; set; }
        
        public int CreatedEmpId { get; set; }
        public int AssignedEmpId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }

        public string LastModifiedBy { get; set; }

    }
}
