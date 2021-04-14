namespace Hfttf.TaskManagement.UI.Models.UserAssignment
{
    public class UserAssignmentUpdate
    {
        public int Id { get; set; }
        public string UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationUserId { get; set; }
        public int TaskId { get; set; }
    }
}
