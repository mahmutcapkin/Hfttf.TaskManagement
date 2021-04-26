﻿using System;

namespace Hfttf.TaskManagement.UI.Models.Project
{
    public class ProjectAdd
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreateBy { get; set; }
        public int? LeaderId { get; set; }
    }
}
