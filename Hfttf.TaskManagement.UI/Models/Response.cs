using System;
using System.Text.Json.Serialization;

namespace Hfttf.TaskManagement.UI.Models
{
    public class Response
    {
        public Object Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public ErrorResponse Fail { get; private set; }

        public static Response Success(Object data, int statusCode)
        {
            return new Response { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response Success(int statusCode)
        {
            return new Response { Data = null, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response UnSuccess(ErrorResponse errorDto, int statusCode)
        {
            return new Response
            {
                Fail = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response UnSuccess(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorResponse(errorMessage, isShow);

            return new Response { Fail = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
