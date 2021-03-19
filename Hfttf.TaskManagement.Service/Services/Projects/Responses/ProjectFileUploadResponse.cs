using System;

namespace Hfttf.TaskManagement.Service.Services.Projects.Responses
{
    public class ProjectFileUploadResponse
    {
        public string UserId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public DateTime? Date { get; set; }
        public ulong Size { get; set; }
    }
}
