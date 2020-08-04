using System;
using System.Collections.Generic;

namespace ServiceRequestManagement.Models
{
    public partial class RequestType
    {
        public RequestType()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string RequestType1 { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
