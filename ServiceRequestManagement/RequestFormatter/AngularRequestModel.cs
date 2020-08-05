using ServiceRequestManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
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


        public  void CopyData(Request request)
        {
            SRMContext context = new SRMContext();


            this.RequestId = request.Id.ToString();
            this.Title = request.Title;

            this.RequestStatus = context.Status.FirstOrDefault(n => n.Id == request.StatusId).Status1;
            this.RequestType = context.RequestType.FirstOrDefault(n => n.Id == request.RequestTypeId).RequestType1;
            this.RequestDepartment = context.Department.FirstOrDefault(n => n.Id == request.DepartmentId).Name;
            this.RequestCategory = context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Name;
            this.RequestSubCategory = context.Category.FirstOrDefault(n => n.Id == request.CategoryId).Name;
            //this.RequestStatus  = Enum.GetName( typeof(StatusRef), request.StatusId);
            // this.RequestType = Enum.GetName(typeof(RequestTypeRef),request.RequestTypeId);
            //this.RequestDepartment = Enum.GetName(typeof(DepartmentRef),request.DepartmentId);
            // this.RequestCategory = Enum.GetName(typeof(CategoryRef), request.CategoryId);
            //this.RequestSubCategory = Enum.GetName(typeof(SubCategoryRef),request.SubCategoryId);

            this.RequestSummary = request.Summary;
            this.Title = request.Title;
            this.CreatedOn = request.CreatedOn;
            this.LastModifiedOn = request.LastModifiedOn;
            this.CreatedEmpId = request.CreatedEmpId;
            this.AssignedEmpId = request.AssignedEmpId;
            this.LastModifiedBy = request.LastModifiedBy;

        }

        public Request SendData()
        {
            Request request = new Request();
            SRMContext context = new SRMContext();

            request.Id = Int32.Parse(this.RequestId);
            request.Title = this.Title;


            request.StatusId = context.Status.FirstOrDefault(n => n.Status1 == this.RequestStatus).Id;
            request.RequestTypeId = context.RequestType.FirstOrDefault(n => n.RequestType1 == this.RequestType).Id;
            request.DepartmentId = context.Department.FirstOrDefault(n => n.Name == this.RequestDepartment).Id;
            request.CategoryId = context.Category.FirstOrDefault(n => n.Name == this.RequestCategory).Id;
            request.SubCategoryId = context.Category.FirstOrDefault(n => n.Name == this.RequestSubCategory).Id;
            //  request.StatusId = (int)Enum.Parse(typeof(StatusRef),obj.RequestStatus);
            // request.RequestTypeId = (int)Enum.Parse(typeof(RequestTypeRef), obj.RequestType);
            // request.DepartmentId = (int)Enum.Parse(typeof(DepartmentRef), obj.RequestDepartment);
            //request.CategoryId = (int)Enum.Parse(typeof(CategoryRef), obj.RequestCategory);
            //request.SubCategoryId = (int)Enum.Parse(typeof(SubCategoryRef), obj.RequestSubCategory);

            request.Summary = this.RequestSummary;
            request.CreatedOn = this.CreatedOn;
            request.LastModifiedOn = this.LastModifiedOn;
            request.CreatedEmpId = this.CreatedEmpId;
            request.AssignedEmpId = this.AssignedEmpId;
            request.LastModifiedBy = this.LastModifiedBy;
            return request;
        }
    }

  
}
