namespace Hfttf.TaskManagement.UI.Models
{
    public class BaseResponse<T> where T : class
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public ErrorResponse Fail { get; private set; }

    }
}
