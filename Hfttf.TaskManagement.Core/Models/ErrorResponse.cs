using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Models
{
    public class ErrorResponse
    {

        public List<String> Errors { get; private set; } = new List<string>();

        public bool IsShow { get; private set; }

        public ErrorResponse(string error, bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorResponse(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
