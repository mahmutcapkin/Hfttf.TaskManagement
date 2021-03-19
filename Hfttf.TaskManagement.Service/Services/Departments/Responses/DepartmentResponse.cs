﻿using Hfttf.TaskManagement.Core.Entities;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Departments.Responses
{
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        //public IList<DepartmentManager> DepartmentManagers { get; set; }
    }
}
