﻿using System;
using System.Collections.Generic;

namespace ServiceRequestManagement.Models
{
    public partial class Status
    {
        public Status()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Status1 { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
